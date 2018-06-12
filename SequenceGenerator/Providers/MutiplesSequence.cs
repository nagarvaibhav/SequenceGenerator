using SequenceGenerator.Common;
using SequenceGenerator.Extensions;
using SequenceGenerator.Models;
using SequenceGenerator.Providers.Rules;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SequenceGenerator.Providers
{
    public class MutiplesSequence : ISequence
    {
        public SequenceType Name { get { return SequenceType.Multiples; } }
        private ArrayList _sequence;
        private readonly IRuleProvider _ruleProvider;

        public MutiplesSequence(IRuleProvider ruleProvider)
        {
            _sequence = new ArrayList();
            _ruleProvider = ruleProvider;
        }

        public ArrayList GetSequence(int value)
        {
            if (value == 0)
            {
                _sequence.Add("No Sequence Found!");
                return _sequence;
            }

            for (int iterator = 0; iterator <= value; iterator++)
            {
                PopulateSequenceForMultiples(iterator);
            }

            return _sequence;
        }

        private void PopulateSequenceForMultiples(int value)
        {
            var rules = _ruleProvider.GetRules();
            var ruleAssert = new List<MultipleRuleModel>();
            var isRulePassed = false;
            foreach (var rule in rules)
            {
                var multiples = rule.Key.Split(',');

                foreach (var item in multiples)
                {
                    int multipleRuleNumber;
                    if (int.TryParse(item, out multipleRuleNumber))
                    {
                        if (!value.IsMultipleOf(multipleRuleNumber))
                        {
                            isRulePassed = false;
                            break;
                        }
                        else
                            isRulePassed = true;
                    }
                    else {
                        throw new InvalidOperationException();
                    }
                }
                ruleAssert.Add(new MultipleRuleModel { IsRulePassed = isRulePassed, Rule = rule.Key, Priority = multiples.Length });
            }
            var passedRule = ruleAssert.Where(x => x.IsRulePassed).OrderByDescending(x => x.Priority).FirstOrDefault();
            if (passedRule != null)
            {
                _sequence.Add(rules[passedRule.Rule]);
            }
            else
            {
                _sequence.Add(value);
            }
        }

    }
}
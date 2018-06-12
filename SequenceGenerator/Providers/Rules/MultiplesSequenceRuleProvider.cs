using System.Collections.Generic;

namespace SequenceGenerator.Providers.Rules
{
    public class MultiplesSequenceRuleProvider: IRuleProvider
    {
        public Dictionary<string, string> GetRules()
        {
            var rules = new Dictionary<string, string>();
            rules.Add("3","C");
            rules.Add("5", "E");
            rules.Add("3,5", "Z");
            return rules;
        }
    }
}
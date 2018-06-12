using NSubstitute;
using NUnit.Framework;
using SequenceGenerator.Providers;
using SequenceGenerator.Providers.Rules;
using System;
using System.Collections.Generic;

namespace SequenceGenerator.Tests.Providers
{
    [TestFixture]
    public class MutipleSequenceTests
    {
        private MutiplesSequence _multipleSequence;
        private IRuleProvider _ruleProvider;

        [SetUp]
        public void SetUp()
        {
            _ruleProvider = Substitute.For<IRuleProvider>();
            _multipleSequence = new MutiplesSequence(_ruleProvider);
        }

        [Test]
        public void GetSequence_Should_Return_Formatted_Sequence()
        {
            var rules = new Dictionary<string, string>();
            rules.Add("3", "C");
            rules.Add("5", "E");
            rules.Add("3,5", "Z");
            _ruleProvider.GetRules().Returns(rules);                
            var result = _multipleSequence.GetSequence(15);
            Assert.AreEqual(result.Count, 16);
            Assert.AreEqual(result[1], 1);
            Assert.AreEqual(result[3], "C");
            Assert.AreEqual(result[5], "E");
            Assert.AreEqual(result[15], "Z");
        }

        [Test]
        public void GetSequence_Should_Throw_Exception_For_Invalid_Rule()
        {
            var rules = new Dictionary<string, string>();
            rules.Add("C", "3");
            _ruleProvider.GetRules().Returns(rules);
            Assert.Throws<InvalidOperationException>(() => _multipleSequence.GetSequence(15));
        }

        [Test]
        public void GetSequence_Should_Return_Error_Message()
        {
            var result = _multipleSequence.GetSequence(0);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], "No Sequence Found!");
        }
    }
}

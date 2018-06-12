using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using SequenceGenerator.Providers;
using SequenceGenerator.Services;
using SequenceGenerator.Providers.Rules;

namespace SequenceGenerator.Tests.Services
{
    [TestFixture]
    public class SequencesServiceTests
    {
        private IntegerSequencesService _integerSequenceService;
        private List<ISequence> _sequences;

        [SetUp]
        public void SetUp()
        {
            var ruleProvider = Substitute.For<IRuleProvider>();
            ruleProvider.GetRules().Returns(new Dictionary<string, string>());
            _sequences = new List<ISequence>();
            _sequences.Add(new EvenSequence());
            _sequences.Add(new OddSequence());
            _sequences.Add(new AllSequence());
            _sequences.Add(new MutiplesSequence(ruleProvider));
            _integerSequenceService = new IntegerSequencesService(_sequences);
        }

        [Test]
        public void GetSequences_Should_Return_Formatted_Sequences()
        {
            var result = _integerSequenceService.GetSequences(5,",");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.OddSequence);
            Assert.IsNotNull(result.EvenSequence);
            Assert.IsNotNull(result.AllSequence);
            Assert.IsNotNull(result.MultiplesSequence);
        }


        [Test]
        public void GetEvenSequence_Should_Return_Formatted_Sequences()
        {
            var result = _integerSequenceService.GetEvenSequence(5, ",");
            Assert.IsNotNull(result);
            Assert.AreEqual(result,"0,2,4");
        }


        [Test]
        public void GetOddSequence_Should_Return_Formatted_Sequences()
        {
            var result = _integerSequenceService.GetOddSequence(5, ",");
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "1,3,5");
        }
    }
}

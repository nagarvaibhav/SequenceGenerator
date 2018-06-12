using NUnit.Framework;
using SequenceGenerator.Providers;

namespace SequenceGenerator.Tests.Providers
{
    [TestFixture]
    public class AllSequenceTests
    {
        private AllSequence _allSequence;

        [SetUp]
        public void SetUp()
        {
            _allSequence = new AllSequence();
        }

        [Test]
        public void GetSequence_Should_Return_AllNumber_Sequences()
        {
            var result = _allSequence.GetSequence(5);
            Assert.AreEqual(result.Count, 6);
            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[5], 5);
        }

        [Test]
        public void GetSequence_Should_Return_Error_Message()
        {
            var result = _allSequence.GetSequence(0);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], "No Sequence Found!");
        }
    }
}

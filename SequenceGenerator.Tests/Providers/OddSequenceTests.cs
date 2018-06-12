using NUnit.Framework;
using SequenceGenerator.Providers;

namespace SequenceGenerator.Tests.Providers
{
    [TestFixture]
    public class OddSequenceTests
    {
        private OddSequence _oddSequence;

        [SetUp]
        public void SetUp()
        {
            _oddSequence = new OddSequence();
        }

        [Test]
        public void GetSequence_Should_Return_OddNumber_Sequences()
        {
            var result = _oddSequence.GetSequence(5);
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[2], 5);
        }

        [Test]
        public void GetSequence_Should_Return_Error_Message()
        {
            var result = _oddSequence.GetSequence(0);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], "No Sequence Found!");
        }
    }
}

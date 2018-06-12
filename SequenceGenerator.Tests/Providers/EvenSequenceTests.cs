using NUnit.Framework;
using SequenceGenerator.Providers;

namespace SequenceGenerator.Tests.Providers
{
    [TestFixture]
    public class EvenSequenceTests
    {
        private EvenSequence _evenSequence;

        [SetUp]
        public void SetUp()
        {
            _evenSequence = new EvenSequence();
        }

        [Test]
        public void GetSequence_Should_Return_EvenNumber_Sequences()
        {
            var result = _evenSequence.GetSequence(6);
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[3], 6);
        }

        [Test]
        public void GetSequence_Should_Return_Error_Message()
        {
            var result = _evenSequence.GetSequence(0);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], "No Sequence Found!");
        }
    }
}

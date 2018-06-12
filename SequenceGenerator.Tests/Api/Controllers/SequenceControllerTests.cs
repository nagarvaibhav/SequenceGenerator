using NSubstitute;
using NUnit.Framework;
using SequenceGenerator.Api.Controllers;
using SequenceGenerator.Dto;
using SequenceGenerator.Services;
using System.Web.Http.Results;

namespace SequenceGenerator.Tests.Api.Controllers
{
    public class SequenceControllerTests
    {
        private SequenceController _sequenceController;
        private ISequenceService _sequenceServiceMock;

        [SetUp]
        public void SetUp()
        {
            _sequenceServiceMock = Substitute.For<ISequenceService>();
            _sequenceController = new SequenceController(_sequenceServiceMock);
        }

        [Test]
        public void GetEvenSequence_Should_Return_SuccessFully_For_ValidInput()
        {
            _sequenceServiceMock.GetEvenSequence(6, ",").Returns("0,2,4,6");
            var result = _sequenceController.GetEvenSequence(6) as OkNegotiatedContentResult<SequenceResponse>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Sequence, "0,2,4,6");

        }

        [Test]
        public void GetEvenSequence_Should_Return_NotFound_If_Sequence_IsNotReturned()
        {
            var result = _sequenceController.GetEvenSequence(6) as NotFoundResult;
            Assert.IsInstanceOf<NotFoundResult>(result);
        }


        [Test]
        public void GetEvenSequence_Should_Return_BadRequest_For_Invalid_Request()
        {
            var result = _sequenceController.GetEvenSequence(0) as BadRequestResult;
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
    }
}

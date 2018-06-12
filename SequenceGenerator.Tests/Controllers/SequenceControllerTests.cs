using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SequenceGenerator.Controllers;
using SequenceGenerator.Models;
using SequenceGenerator.Services;

namespace SequenceGenerator.Tests.Controllers
{
    [TestFixture]
    public class SequenceControllerTests
    {
        private SequenceController _sequenceController;
        private ISequenceService _sequenceServiceMock;

        [SetUp]
        public void SetUp()
        {
            _sequenceServiceMock = NSubstitute.Substitute.For<ISequenceService>();
            _sequenceController = new SequenceController(_sequenceServiceMock);
        }

        [Test]
        public void Index_Get_Should_Return_View_Successfully()
        {
            ViewResult result = _sequenceController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_Post_Should_Return_Error_For_NegativeNumber()
        {
            var model = new SequenceModel { EnteredInput = -1, };
            var validations = Validate(model);
            ViewResult result = _sequenceController.Index(model) as ViewResult;
            Assert.AreEqual(validations.Count, 1);
            Assert.AreEqual(validations[0].ErrorMessage, "Please Enter a Valid Whole Number e.g 0,1..");
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_Post_Should_Return_Error_For_NullInput()
        {
            var model = new SequenceModel();
            var validations = Validate(model);
            _sequenceController.ModelState.AddModelError(validations[0].ErrorMessage, validations[0].ErrorMessage);
            ViewResult result = _sequenceController.Index(model) as ViewResult;
            Assert.AreEqual(validations.Count, 1);
            Assert.AreEqual(validations[0].ErrorMessage, "Please enter a whole number");
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_Post_Should_Return_SucessFully()
        {
            var model = new SequenceModel { EnteredInput = 20, };
            var validations = Validate(model);
            _sequenceServiceMock.GetSequences(model.EnteredInput.Value,",").Returns(new Sequences() { AllSequence = "c", OddSequence = "o" });
            ViewResult result = _sequenceController.Index(model) as ViewResult;
            Assert.AreEqual(validations.Count, 0);
            var modelSet = result.Model as SequenceModel;
            Assert.AreEqual(modelSet.EnteredInput, model.EnteredInput);
            Assert.AreEqual(validations.Count, 0);
            Assert.IsNotNull(modelSet.Sequences);
            Assert.AreEqual(modelSet.Sequences.AllSequence, "c");
            Assert.AreEqual(modelSet.Sequences.OddSequence, "o");
            Assert.IsNotNull(result);
        }


        private static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
            return results;
        }
    }
}

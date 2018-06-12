using System.Web.Mvc;
using SequenceGenerator.Models;
using SequenceGenerator.Services;

namespace SequenceGenerator.Controllers
{
    public class SequenceController : Controller
    {
        private readonly ISequenceService _sequenceService;

        public SequenceController(ISequenceService sequenceService)
        {
            _sequenceService = sequenceService;
        }

        public ActionResult Index()
        {
            return View(new SequenceModel());
        }

        [HttpPost]
        public ActionResult Index(SequenceModel model)
        {
            if (!ModelState.IsValid)
            {
                 return View(model);
            }

            model.Sequences = _sequenceService.GetSequences(model.EnteredInput.Value, ",");

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
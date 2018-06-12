using SequenceGenerator.Dto;
using SequenceGenerator.Services;
using System.Web.Http;

namespace SequenceGenerator.Api.Controllers
{
    [RoutePrefix("api/Sequence")]
    public class SequenceController : ApiController
    {
        private readonly ISequenceService _sequenceService;
        private const string Seperator = ",";
        public SequenceController(ISequenceService sequenceService)
        {
            _sequenceService = sequenceService;
        }

        [HttpGet]
        [Route("{value}/All")]
        public IHttpActionResult GetAllSequence(int value)
        {
            if (value == 0)
                return BadRequest();

            var result = _sequenceService.GetAllSequence(value, Seperator);
            if (string.IsNullOrEmpty(result))
                return NotFound();

            return Ok(new SequenceResponse { Sequence = result });
        }

        [Route("{value}/Even")]
        public IHttpActionResult GetEvenSequence(int value)
        {
            if (value == 0)
                return BadRequest();

            var result = _sequenceService.GetEvenSequence(value, Seperator);
            if (string.IsNullOrEmpty(result))
                return NotFound();

            return Ok(new SequenceResponse { Sequence = result });
        }

        [Route("{value}/Odd")]
        public IHttpActionResult GetOddSequence(int value)
        {
            if (value == 0)
                return BadRequest();

            var result = _sequenceService.GetOddSequence(value, Seperator);
            if (string.IsNullOrEmpty(result))
                return NotFound();

            return Ok(new SequenceResponse { Sequence = result });
        }

        [Route("{value}/Multiples")]
        public IHttpActionResult GetMultiplesSequence(int value)
        {
            if (value == 0)
                return BadRequest();

            var result = _sequenceService.GetMultiplesSequence(value, Seperator);
            if (string.IsNullOrEmpty(result))
                return NotFound();

            return Ok(new SequenceResponse { Sequence = result });
        }

        [Route("{value}")]
        public IHttpActionResult GetAllProvided(int value)
        {
            if (value == 0)
                return BadRequest();

            return Ok(_sequenceService.GetSequences(value, Seperator));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using RestDuathlon.Managers;
using ZealandDuathlon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestDuathlon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuathletesController : ControllerBase
    {
        private DuathletesManager _duathletesManager = new DuathletesManager();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Duathlete>> Get(/*[FromQuery]string? duathleteName, [FromQuery]int? ageGroup, [FromQuery]int? bike, [FromQuery]int? run*/)
        {
            var list = _duathletesManager.GetAll();
            if (list == null) return NotFound("No list was found");
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Duathlete> Get(int id)
        {
            Duathlete duathlete = _duathletesManager.GetById(id);
            if (duathlete == null) return NotFound($"No such class Bib: {id}, was found");
            return Ok(duathlete);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Duathlete> Post([FromBody] Duathlete value)
        {
            Duathlete duathlete = _duathletesManager.Add(value);
            return Created(duathlete.Bib.ToString(), duathlete);
        }

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<Duathlete> Put([FromBody]Duathlete value, int bib)
        //{
        //    Duathlete duathlete = _duathletesManager.Update(value, bib);
        //    if (duathlete == null) return NotFound($"No duathlete with Bib: {bib}, was found");
        //    return Ok(duathlete);
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Duathlete> Delete(int id)
        {
            Duathlete duathlete = _duathletesManager.Delete(id);
            if (duathlete == null) return NotFound($"No duathlete with Bib: {id}, was found");
            return Ok(duathlete);
        }
    }
}

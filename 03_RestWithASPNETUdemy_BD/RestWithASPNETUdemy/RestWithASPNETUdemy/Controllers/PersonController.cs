using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            this.personBusiness = personBusiness;
        }

        [HttpGet()]
        public IActionResult Get()
        {          
            return Ok(this.personBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = this.personBusiness.FindById(id);
            if(person == null)return NotFound();
            return Ok(person);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Person person)
        {           
            if (person == null) return BadRequest();
            return Ok(this.personBusiness.Create(person));
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {            
            this.personBusiness.Delete(id);
            return NoContent();
        }
    }
}
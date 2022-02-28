using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Inplementations;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            this.personService = personService;
        }

        [HttpGet()]
        public IActionResult Get()
        {          
            return Ok(this.personService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = this.personService.FindById(id);
            if(person == null)return NotFound();
            return Ok(person);
        }

        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Person person)
        {           
            if (person == null) return BadRequest();
            return Ok(this.personService.Create(person));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {            
            this.personService.Delete(id);
            return NoContent();
        }
    }
}
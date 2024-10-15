using DataMatrix.Models;
using DataMatrix.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DataMatrix.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactController : Controller
    {
        public ContactController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        private readonly IRepository<Contact> _contactRepository;

        [HttpGet]
        public IActionResult Index()
        {
            var contacts = _contactRepository.GetAll();
            return Ok(contacts);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactRepository.Add(contact);

                if(result > 0)
                    return Created();
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(Contact contact) 
        {
            if (ModelState.IsValid)
            {
                var result = await _contactRepository.Update(contact);

                if (result > 0)
                    return Ok();

                if(result == 0)
                    return NoContent();
            }

            if (!ModelState.IsValid)
               return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _contactRepository.Delete(Id);
            if (result > 0)
                return Ok();

            if (result == 0)
                return NoContent();

            return Ok();
        }
    }
}

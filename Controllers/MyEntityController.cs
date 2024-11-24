using Microsoft.AspNetCore.Mvc;
using SolidPrincipalWithGenericDbContext.Model;
using SolidPrincipalWithGenericDbContext.Service;
using System.Xml;

namespace SolidPrincipalWithGenericDbContext.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyEntityController : ControllerBase
    {
        private readonly ExampleService _service;

        public MyEntityController(ExampleService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var entity = await _service.GetEntityByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MyEntity entity)
        {
            await _service.AddEntityAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteEntityAsync(id);
            return NoContent();
        }
    }
}

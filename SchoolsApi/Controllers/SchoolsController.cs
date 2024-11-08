using SchoolApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SchoolsApi.Models;

namespace SchoolApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost("register-school")]
        public async Task<IActionResult> Post([FromBody] School request)
        {
            var result = await _schoolService.AddSchool(request);
            if (result)
            {
                return Ok(new { Message = "Escuela registrada éxitosamente" });
            }
            return StatusCode(500, new { Message = "Ha ocurrido un error" });
        }

        [HttpGet("school/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var school = await _schoolService.GetSchoolAsync(id);
            if (school != null)
            {
                return Ok(school);
            }
            return NotFound(new { Message = "Escuela no encontrada" });
        }

        [HttpDelete("delete-school/{name}")]
        public async Task<IActionResult> DeleteSchoolByName(string name)
        {
            var result = await _schoolService.DeleteSchoolByName(name);
            if (result)
            {
                return Ok(new { Message = "Escuela eliminada correctamente" });
            }
            return NotFound(new { Message = "Escuela no encontrado para eliminar" });
        }
    }
}

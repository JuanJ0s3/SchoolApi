using SchoolApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SchoolsApi.Models;

namespace SchoolApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("register-course")]
        public async Task<IActionResult> Post([FromBody] Course request)
        {
            var result = await _courseService.AddCourse(request);
            if (result)
            {
                return Ok(new { Message = "Curso registrado exitosamente" });
            }
            return StatusCode(500, new { Message = "Ha ocurrido un error" });
        }

        [HttpGet("course/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var note = await _courseService.GetCourseAsync(id);
            if (note != null)
            {
                return Ok(note);
            }
            return NotFound(new { Message = "Curso no encontrado" });
        }

        [HttpDelete("delete-course/{name}")]
        public async Task<IActionResult> DeleteNoteByMatter(string name)
        {
            var result = await _courseService.DeleteCourseByName(name);
            if (result)
            {
                return Ok(new { Message = "Curso eliminado correctamente" });
            }
            return NotFound(new { Message = "Curso no encontrado para eliminar" });
        }
    }
}

using SchoolApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SchoolsApi.Models;

namespace SchoolApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost("register-note")]
        public async Task<IActionResult> Post([FromBody] Note request)
        {
            var result = await _noteService.AddNote(request);
            if (result)
            {
                return Ok(new { Message = "Nota registrada éxitosamente" });
            }
            return StatusCode(500, new { Message = "Ha ocurrido un error" });
        }

        [HttpGet("note/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var note = await _noteService.GetNoteAsync(id);
            if (note != null)
            {
                return Ok(note);
            }
            return NotFound(new { Message = "Nota no encontrada" });
        }

        [HttpDelete("delete-note/{matter}")]
        public async Task<IActionResult> DeleteNoteByMatter(string matter)
        {
            var result = await _noteService.DeleteNoteByMatter(matter);
            if (result)
            {
                return Ok(new { Message = "Nota eliminada correctamente" });
            }
            return NotFound(new { Message = "Nota no encontrado para eliminar" });
        }
    }
}

using SchoolsApi.Models;

namespace SchoolApi.Core.Services.Interfaces
{
    public interface INoteService
    {
        Task<bool> AddNote(Note note);
        Task<Note> GetNoteAsync(string id);
        Task<bool> DeleteNoteByMatter(string matter);
    }
}

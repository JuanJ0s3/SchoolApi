using SchoolApi.Contracts.Models;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task AddNote(Note note);
        Task<Note> GetNoteById(string id);
        Task<bool> DeleteNoteByMatter(string matter);
    }
}

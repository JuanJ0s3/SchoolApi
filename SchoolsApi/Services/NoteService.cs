using SchoolApi.Contracts.Models;
using SchoolApi.Core.Services.Interfaces;
using SchoolApi.Infrastructure.Repositories.Interfaces;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace SchoolApi.Core.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> AddNote(Note note)
        {
            await _noteRepository.AddNote(note);
            return true;
        }

        public async Task<Note> GetNoteAsync(string id)
        {
            return await _noteRepository.GetNoteById(id);
        }

        public async Task<bool> DeleteNoteByMatter(string matter)
        {
            return await _noteRepository.DeleteNoteByMatter(matter);
        }
    }
}

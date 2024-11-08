using SchoolApi.Infrastructure.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using SchoolsApi.Models;

namespace SchoolApi.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly IMongoCollection<Note> _note;

        public NoteRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:MongoDb").Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("MongoDBSettings:MongoDb", "La cadena de conexión de MongoDb no está configurada correctamente.");
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Schooldb");
            _note = database.GetCollection<Note>("Notes");
        }

        public async Task AddNote(Note note)
        {
            try
            {

                await _note.InsertOneAsync(note);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la nota: {ex.Message}");
                throw;
            }
        }

        public async Task<Note> GetNoteById(string id)
        {
            try
            {

                if (ObjectId.TryParse(id, out var objectId))
                {
                    return await _note.Find<Note>(note => note.Id == objectId).FirstOrDefaultAsync();
                }
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: El formato del ID no es válido: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteNoteByMatter(string matter)
        {
            var result = await _note.DeleteOneAsync(note => note.Matter == matter);
            return result.DeletedCount > 0;
        }
    }
}

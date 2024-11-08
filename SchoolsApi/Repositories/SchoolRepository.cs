using SchoolApi.Contracts.Models;
using SchoolApi.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SchoolsApi.Models;
using System;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories
{
    public class SChoolRepository : ISchoolRepository
    {
        private readonly IMongoCollection<School> _school;

        public SChoolRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:MongoDb").Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("MongoDBSettings:MongoDb", "La cadena de conexión de MongoDb no está configurada correctamente.");
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Schooldb");
            _school = database.GetCollection<School>("Schools");
        }

        public async Task AddSchool(School school)
        {
            try
            {
                
                await _school.InsertOneAsync(school);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la escuela: {ex.Message}");
                throw;
            }
        }

        public async Task<School> GetSchoolById(string id)
        {
            try
            {
                
                if (ObjectId.TryParse(id, out var objectId))
                {
                    return await _school.Find<School>(school => school.Id == objectId).FirstOrDefaultAsync();
                }
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: El formato del ID no es válido: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteSchoolByName(string name)
        {
            var result = await _school.DeleteOneAsync(school => school.Name == name);
            return result.DeletedCount > 0;
        }
    }
}

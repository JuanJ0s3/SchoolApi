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
    public class CourseRepository : ICourseRepository
    {
        private readonly IMongoCollection<Course> _course;

        public CourseRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:MongoDb").Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("MongoDBSettings:MongoDb", "La cadena de conexión de MongoDb no está configurada correctamente.");
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Schooldb");
            _course = database.GetCollection<Course>("Courses");
        }

        public async Task AddCourse(Course course)
        {
            try
            {
                
                await _course.InsertOneAsync(course);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el curso: {ex.Message}");
                throw;
            }
        }

        public async Task<Course> GetCourseById(string id)
        {
            try
            {
                
                if (ObjectId.TryParse(id, out var objectId))
                {
                    return await _course.Find<Course>(course => course.Id == objectId).FirstOrDefaultAsync();
                }
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: El formato del ID no es válido: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteCourseByName(string name)
        {
            var result = await _course.DeleteOneAsync(course => course.Name == name);
            return result.DeletedCount > 0;
        }
    }
}

using SchoolApi.Core.Services.Interfaces;
using SchoolApi.Infrastructure.Repositories.Interfaces;
using SchoolsApi.Models;

namespace SchoolApi.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> AddCourse(Course course)
        {
            await _courseRepository.AddCourse(course);
            return true;
        }

        public async Task<Course> GetCourseAsync(string id)
        {
            return await _courseRepository.GetCourseById(id);
        }

        public async Task<bool> DeleteCourseByName(string name)
        {
            return await _courseRepository.DeleteCourseByName(name);
        }
    }
}

using SchoolApi.Contracts.Models;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course);
        Task<Course> GetCourseById(string id);
        Task<bool> DeleteCourseByName(string name);
    }
}

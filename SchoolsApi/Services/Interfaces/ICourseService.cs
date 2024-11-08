using SchoolApi.Contracts.Models;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace SchoolApi.Core.Services.Interfaces
{
    public interface ICourseService
    {
        Task<bool> AddCourse(Course course);
        Task<Course> GetCourseAsync(string id);
        Task<bool> DeleteCourseByName(string name);
    }
}
using SchoolApi.Contracts.Models;
using SchoolApi.Core.Services.Interfaces;
using SchoolApi.Infrastructure.Repositories.Interfaces;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace SchoolApi.Core.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<bool> AddSchool(School school)
        {
            await _schoolRepository.AddSchool(school);
            return true;
        }

        public async Task<School> GetSchoolAsync(string id)
        {
            return await _schoolRepository.GetSchoolById(id);
        }

        public async Task<bool> DeleteSchoolByName(string name)
        {
            return await _schoolRepository.DeleteSchoolByName(name);
        }
    }
}

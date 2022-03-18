using Microsoft.EntityFrameworkCore;
using SchoolAPIApp.Data;
using SchoolAPIApp.Dtos;
using SchoolAPIApp.Exceptions;
using SchoolAPIApp.Models;

namespace SchoolAPIApp.Services
{

    public class SchoolService
    {
        private readonly DataContext _dataContext;
        public SchoolService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<School>> GetAllAsync()
        {
            List<School> schools = await _dataContext.Schools.Include(i => i.Students).ToListAsync();
            return schools;
        }

        public async Task<int> CreateAsync(CreateSchool createSchool)
        {
            var model = new School()
            {
                Name = createSchool.Name,
            };
            _dataContext.Add(model);
            await _dataContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var school = await _dataContext.Schools.FindAsync(id);
            if (school == null)
            {
                throw new SchoolNotFoundException("School not found");
            }
            _dataContext.Remove(school);
            await _dataContext.SaveChangesAsync();
        }
    }
}

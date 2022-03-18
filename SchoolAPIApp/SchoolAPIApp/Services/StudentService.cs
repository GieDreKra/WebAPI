using Microsoft.EntityFrameworkCore;
using SchoolAPIApp.Data;
using SchoolAPIApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPIApp.Services
{
    public class StudentService
    {
        private readonly DataContext _dataContext;
        public StudentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ListStudent>> GetAllAsync()
        {
            List<Student> students = await _dataContext.Students.ToListAsync();
            List<ListStudent> students1 = new List<ListStudent>();
            foreach (Student student in students) {
                students1.Add(new ListStudent {
                    Id = student.Id, 
                    Name = student.Name, 
                    Surname = student.Surname,
                    SchoolId = student.SchoolId, 
                    School = _dataContext.Schools.Find(student.SchoolId).Name
            });
          
            }
            return students1;
        }

        public async Task<int> CreateAsync(CreateStudent createStudent)
        {
            Student student = new Student()
            {
                Name = createStudent.Name,
                Surname = createStudent.Surname,
                SchoolId = createStudent.SchoolId
            };
            _dataContext.Add(student);
            await _dataContext.SaveChangesAsync();
            return student.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dataContext.Students.FindAsync(id);
            if (item == null)
            {
                throw new ArgumentException("Student not found");
            }
            _dataContext.Remove(item);
            await _dataContext.SaveChangesAsync();
        }
    }
}

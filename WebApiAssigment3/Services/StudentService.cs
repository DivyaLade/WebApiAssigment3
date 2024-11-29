using Microsoft.EntityFrameworkCore;
using WebApiAssigment3.Context;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Services
{
    public class StudentService : IStudent
    {
        private readonly SchoolManagmentDBContext _dbContext;
        public StudentService(SchoolManagmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();

        }
        public async Task<Student?> GetStudentById(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(obj => obj.StudentID == id);
        }
        public async Task<Student?> AddStudent(Student student)
        {
            var obj = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                ClassId = student.ClassId,
            };
            _dbContext.Students.Add(obj);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            var hero = await _dbContext.Students.FirstOrDefaultAsync(obj => obj.StudentID == id);
            if (hero != null)
            {
                _dbContext.Students.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
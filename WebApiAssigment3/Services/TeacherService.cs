using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using WebApiAssigment3.Context;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Services
{
    public class TeacherService : ITeacher
    {
        private readonly SchoolManagmentDBContext _dbContext;
        public TeacherService(SchoolManagmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _dbContext.Teachers.ToListAsync();
        }
        public async Task<Teacher?> GetAllTeacherById(int id)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(obj => obj.TeacherId == id);
        }
        public async Task<Teacher?> AddTeacher(Teacher teacher)
        {
            var obj = new Teacher()
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                SubjectId = teacher.SubjectId,
            };
            _dbContext.Teachers.Add(obj);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<bool> DeleteById(int id)
        {
            var hero = await _dbContext.Teachers.FirstOrDefaultAsync(obj => obj.TeacherId == id);
            if (hero != null)
            {
                _dbContext.Teachers.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        
        }
    } 
}

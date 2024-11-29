using Microsoft.EntityFrameworkCore;
using WebApiAssigment3.Context;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Services
{
    public class SubjectService:ISubject
    {
        private readonly SchoolManagmentDBContext _dbContext;
        public SubjectService(SchoolManagmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _dbContext.Subjects.ToListAsync();

        }
        public async Task<Subject?>GetSubjectById(int id)
        {
            return await _dbContext.Subjects.FirstOrDefaultAsync(s=>s.SubjectId == id); 
        }
        public async Task<Subject?> AllSubject(Subject obj)
        {
            var addSubject = new Subject()
            {
                SubjectName = obj.SubjectName,
                SubjectId = obj.SubjectId,

            };
            _dbContext.Subjects.Add(addSubject);
            var result= await _dbContext.SaveChangesAsync();
            return result >=0?addSubject : null;
        }
        public async Task<bool>DeleteSubjectById(int id)
        {
            var hero = await _dbContext.Subjects.FirstOrDefaultAsync(s=> s.SubjectId == id);
            if (hero != null)
            {
                _dbContext.Subjects.Remove(hero);
                var result=await _dbContext.SaveChangesAsync();
                return result >=0;
            }
            return false;
        }

    }
}

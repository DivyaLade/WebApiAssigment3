using Microsoft.EntityFrameworkCore;
using WebApiAssigment3.Context;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Services
{
    public class ClassService: IClasse
    {
        private readonly SchoolManagmentDBContext _dBContext;
        public ClassService(SchoolManagmentDBContext dbcontext)
        {
            _dBContext = dbcontext;
        }
        public async Task<List<Class>> GetAllClasses()
        {
            return await _dBContext.Classes.ToListAsync();
        }
        public async Task<Class?>GetClassById(int id)
        {
            return await _dBContext.Classes.FirstOrDefaultAsync(c=> c.ClassId == id);
        }

        public async Task<Class?>AddClass(Class obj)
        {
            var addClass=new Class()
            {
                ClassName=obj.ClassName,
                TeacherId=obj.TeacherId,
            };
            _dBContext.Classes.Add(addClass);
            var result=await _dBContext.SaveChangesAsync();
            return result  >= 0? addClass : null;
        }

        public async Task<bool>DeleteClassById(int id)
        {
            var hero = await _dBContext.Classes.FirstOrDefaultAsync(c=> c.ClassId==id);
            if (hero != null)
            {
                _dBContext.Classes.Remove(hero);
                var result=await _dBContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}

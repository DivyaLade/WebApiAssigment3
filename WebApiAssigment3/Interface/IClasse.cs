using WebApiAssigment3.Entities;

namespace WebApiAssigment3.Interface
{
    public interface IClasse
    {
        Task<List<Class>> GetAllClasses();
        Task<Class?> GetClassById(int id);
        Task<Class?> AddClass(Class obj);
        //Task<Class?>UpdateClass(int id,Class obj);
        Task<bool>DeleteClassById(int id);
    }
}

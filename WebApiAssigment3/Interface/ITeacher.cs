using WebApiAssigment3.Entities;

namespace WebApiAssigment3.Interface
{
    public interface ITeacher
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher?>GetAllTeacherById(int id);

        Task<Teacher?> AddTeacher(Teacher teacher);

        Task<bool> DeleteById(int id);
    }
}

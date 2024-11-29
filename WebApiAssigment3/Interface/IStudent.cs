using WebApiAssigment3.Entities;

namespace WebApiAssigment3.Interface
{
    public interface IStudent
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);

        Task<Student?> AddStudent(Student student);

        Task<bool> DeleteStudent(int id);
    }
}

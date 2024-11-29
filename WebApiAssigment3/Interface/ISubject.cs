using WebApiAssigment3.Entities;

namespace WebApiAssigment3.Interface
{
    public interface ISubject
    {
        Task<List<Subject>> GetAllSubjects();
        Task<Subject?>GetSubjectById(int id);
        Task<Subject?> AllSubject(Subject obj);
        //Task<Subjrct?>UpdateSunject(int id,Subject obj);
        Task<bool>DeleteSubjectById(int id);
    }
}

using WebApiAssigment3.Entities;

namespace WebApiAssigment3.Interface
{
    public interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User?>AddUser(User obj);
        //Task<User?>UpdateUser(int id, User obj);
        Task<bool> DeleteUserById(int id);
    }
}

using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiAssigment3.Context;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Services
{
    public class UserService: IUser
    {
        private readonly SchoolManagmentDBContext _dbContext;
        public UserService(SchoolManagmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User?>GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u=> u.UserId == id);
        }
        public async Task<User?>AddUser(User obj)
        {
            var addUser = new User()
            {
                UserId = obj.UserId,
                UserName = obj.UserName,
                PasswordHash = obj.PasswordHash,
                Role = obj.Role,
            };
            _dbContext.Users.Add(addUser);
            var result=await _dbContext.SaveChangesAsync();
            return result >= 0 ? addUser : null;
        }
        public async Task<bool>DeleteUserById(int id)
        {
            var hero= await _dbContext.Users.FirstOrDefaultAsync(u=>u.UserId == id);
            if (hero != null)
            {
                _dbContext.Users.Remove(hero);
                var result=await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}

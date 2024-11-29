using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var model=await _userService.GetAllUsers();
            if (model == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult>Get(int id)
        {
            var model=await _userService.GetUserById(id);
            if (model == null)
            {
                return NotFound("record not found");
            }
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult>AddUser(User obj)
        {
            var add = await _userService.AddUser(obj);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteUserById(int id)
        {
            var hero=await _userService.GetUserById(id);
            return Ok(hero);
            

            
        }
       
    }
}

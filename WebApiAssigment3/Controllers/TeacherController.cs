using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacherService;
        public TeacherController(ITeacher teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var teacher = await _teacherService.GetAllTeachers();
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var obj = await _teacherService.GetAllTeacherById(id);
            if (obj == null)
            { 
                return NotFound(); 
            }
            return Ok(obj);
        }
        
        [HttpPost]
        public async Task<IActionResult>AddTeacher(Teacher teacher)
        {
            var obj = await _teacherService.AddTeacher(teacher);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacheById(int id)
        {
            var hero = await _teacherService.DeleteById(id);
          
            return Ok(hero);
        }
        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentService;
        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var stud = await _studentService.GetAllStudents();
            if (stud == null)
            {
                return NotFound();
            }
            return Ok(stud);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var Student = await _studentService.GetStudentById(id);
            if (Student is null)
                return NotFound("Record Not Found");
            return Ok(Student);
        }
        [HttpPost]
        public async Task<IActionResult>AddStudent(Student student)
        {
            var obj=await _studentService.AddStudent(student);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var hero=await _studentService.DeleteStudent(id);
            return Ok(hero);

        }
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subjectService;
        public SubjectController(ISubject subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var model=await _subjectService.GetAllSubjects();
            if (model == null)
            {
                return NotFound("No Data found");
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("[action]/id")]

        public async Task<IActionResult>Get(int id)
        {
            var model=await _subjectService.GetSubjectById(id);
            if (model == null)
            {
                return NotFound("record nit found");
            }
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult>AddSubject(Subject obj)
        {
            var add =await _subjectService.AllSubject(obj);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteSubjectById(int id)
        {
            var hero=await _subjectService.GetSubjectById(id);
            return Ok(hero);
        }
    }
}

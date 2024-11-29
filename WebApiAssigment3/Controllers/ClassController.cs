using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssigment3.Entities;
using WebApiAssigment3.Interface;

namespace WebApiAssigment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClasse _classService;
        public ClassController(IClasse classService)
        {
            _classService = classService;
        }
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var model=await _classService.GetAllClasses();
            if (model == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
            
                
        }
        [HttpGet]
        [Route("[action]/id")]

        public async Task<IActionResult> Get(int id)
        {
            var model = await _classService.GetClassById(id);
            if (model == null)
            {
                return NotFound("record Not Found");
            }

            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult>AddClass(Class obj)
        {
            var add = await _classService.AddClass(obj);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassById(int id)
        {
            var hero = await _classService.GetClassById(id);
            return Ok(hero);
        }
    }
}

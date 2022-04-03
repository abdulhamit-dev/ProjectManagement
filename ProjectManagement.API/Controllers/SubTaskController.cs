using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business.Abstract;
using ProjectManagement.Entities.Concrete;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly ISubTaskService _subTaskService;

        public SubTaskController(ISubTaskService subTaskService)
        {
            _subTaskService = subTaskService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _subTaskService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _subTaskService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(SubTask subTask)
        {
            var result = _subTaskService.Add(subTask);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(SubTask subTask)
        {
            var result = _subTaskService.Update(subTask);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _subTaskService.Delete(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

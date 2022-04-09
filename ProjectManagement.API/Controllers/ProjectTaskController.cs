using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business.Abstract;
using ProjectManagement.Entities.Concrete;

namespace ProjectManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;
        public ProjectTaskController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _projectTaskService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _projectTaskService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(ProjectTask projectTask)
        {
            var result = _projectTaskService.Add(projectTask);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(ProjectTask projectTask)
        {
            var result = _projectTaskService.Update(projectTask);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _projectTaskService.Delete(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetProjectTasks/{id:int}")]
        public IActionResult GetProjectTasks(int id)
        {
            var result = _projectTaskService.GetProjectTasks(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetUserTasks/{id:int}")]
        public IActionResult GetUserTasks(int id)
        {
            var result = _projectTaskService.GetUserTasks(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

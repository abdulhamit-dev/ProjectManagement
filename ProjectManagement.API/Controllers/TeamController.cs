using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business.Abstract;
using ProjectManagement.Entities.Concrete;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _teamService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _teamService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Team team)
        {
            var result = _teamService.Add(team);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Team team)
        {

            var result = _teamService.Update(team);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _teamService.Delete(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

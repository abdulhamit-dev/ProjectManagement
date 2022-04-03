using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business.Abstract;
using ProjectManagement.Entities.Concrete;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userRoleService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _userRoleService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(UserRole userRole)
        {
            var result = _userRoleService.Add(userRole);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(UserRole userRole)
        {
            var result = _userRoleService.Update(userRole);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _userRoleService.Delete(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

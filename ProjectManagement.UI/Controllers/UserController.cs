using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.User;
using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly TeamService _teamService;

        public UserController(UserService userService, TeamService teamService)
        {
            _userService = userService;
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetAll();
            return View(user.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddShowModal()
        {
            var team = await _teamService.GetAll();
            return PartialView("_AddUpdatepp", new UserAddUpdateVM() { TeamVMs=team.Data});
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShowModal(int userId)
        {
            var user = await _userService.GetById(userId);
            var team=await _teamService.GetAll();
            user.Data.TeamVMs=team.Data;
            return PartialView("_AddUpdatepp", user.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserAddUpdateVM userAddUpdateVM)
        {
            Result result;

            if (userAddUpdateVM.Id == 0)
                result = await _userService.Add(userAddUpdateVM);
            else
                result = await _userService.Update(userAddUpdateVM);

            if (!result.Success)
                return Json(result);
            else
            {
                var user = await _userService.GetAll();

                return PartialView("_Listpp", user.Data);
            }
        }
    }
}

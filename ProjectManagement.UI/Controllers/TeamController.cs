using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.Team;
using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var team =await _teamService.GetAll();
            return View(team.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddShowModal()
        {
            return PartialView("_AddUpdatepp", new TeamAddUpdateVM());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShowModal(int teamId)
        {
            var team = await _teamService.GetById(teamId);

            return PartialView("_AddUpdatepp", team.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TeamAddUpdateVM teamAddUpdateVM)
        {
            Result result;

            if (teamAddUpdateVM.Id == 0)
                result = await _teamService.Add(teamAddUpdateVM);
            else
                result = await _teamService.Update(teamAddUpdateVM);

            if (!result.Success)
                return Json(result);
            else
            {
                var team = await _teamService.GetAll();

                return PartialView("_Listpp", team.Data);
            }
        }
    }
}

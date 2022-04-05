using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Models.Home;
using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ProjectService _projectService;
        private readonly TeamService _teamService;

        public HomeController(ProjectService projectService, TeamService teamService)
        {
            _projectService = projectService;
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var projectList= await _projectService.GetAll();
            var teamList=await _teamService.GetAll();
            HomeVM homeVM = new HomeVM();
            homeVM.projectVMs = projectList.Data;
            homeVM.teamVMs = teamList.Data;

            return View(homeVM);
        }
    }
}

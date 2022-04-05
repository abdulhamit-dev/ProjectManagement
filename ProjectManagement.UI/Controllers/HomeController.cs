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

        public HomeController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var projectList= await _projectService.GetAll();
            HomeVM homeVM = new HomeVM();
            homeVM.projectVMs = projectList.Data;

            return View(homeVM);
        }
    }
}

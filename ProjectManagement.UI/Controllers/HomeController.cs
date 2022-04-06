using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Models.Home;
using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {


        public HomeController()
        {
           
        }

        public async Task<IActionResult> Index()
        {
           

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> GetProjectDetail(int projectId)
        //{
        //    var project= await _projectService.GetProjectTasks(projectId);
        //    return PartialView("_ProjectTaskspp", project.Data);
        //}
    }
}

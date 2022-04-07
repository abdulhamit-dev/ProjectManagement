using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.Project;
using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;
        private readonly TeamService _teamService;
        public ProjectController(ProjectService projectService, TeamService teamService)
        {
            _projectService = projectService;
            _teamService = teamService;
        }
        public async Task< IActionResult> Index()
        {
            var project = await _projectService.GetAll();
            return View(project.Data);
        }
     
        [HttpPost]
        public async Task<IActionResult> Save(ProjectAddUpdateVM projectAddUpdateVM)
        {
            Result result;

            if (projectAddUpdateVM.Id == 0)
                result = await _projectService.Add(projectAddUpdateVM);
            else
                result = await _projectService.Update(projectAddUpdateVM);

            if (!result.Success)
                return Json(result);
            else
            {
                var locations = await _projectService.GetAll();
                return PartialView("_Listpp", locations.Data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddShowModal()
        {
            var team =await _teamService.GetAll();
            return PartialView("_AddUpdatepp", new ProjectAddUpdateVM() { TeamVMs=team.Data});
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShowModal(int projectId)
        {
            var project = await _projectService.GetById(projectId);
            var team = await _teamService.GetAll();
            project.Data.TeamVMs = team.Data;
            return PartialView("_AddUpdatepp", project.Data);
        }

    }
}

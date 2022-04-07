using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.ProjectTask;
using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly ProjectTaskService _projectTaskService;

        public ProjectTaskController(ProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task< IActionResult> Index(int projectId)
        {
            var projectTasks = await _projectTaskService.GetProjectTasks(projectId);
            return View(projectTasks.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddShowModal(int projectId)
        {
            return PartialView("_AddUpdatepp", new ProjectTaskAddUpdateVM() { ProjectId=projectId});
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShowModal(int taskId)
        {
            var projectTask = await _projectTaskService.GetById(taskId);
            
            return PartialView("_AddUpdatepp", projectTask.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProjectTaskAddUpdateVM projectTaskAddUpdateVM)
        {
            Result result;

            if (projectTaskAddUpdateVM.Id == 0)
                result = await _projectTaskService.Add(projectTaskAddUpdateVM);
            else
                result = await _projectTaskService.Update(projectTaskAddUpdateVM);

            if (!result.Success)
                return Json(result);
            else
            {
                var projectTasks = await _projectTaskService.GetProjectTasks(projectTaskAddUpdateVM.ProjectId);

                return PartialView("_Listpp", projectTasks.Data);
            }
        }
    }
}

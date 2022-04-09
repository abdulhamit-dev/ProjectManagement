using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.ProjectTask;
using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Controllers
{
    [Authorize]
    public class ProjectTaskController : Controller
    {
        private readonly ProjectTaskService _projectTaskService;
        private readonly UserService _userService;
        public ProjectTaskController(ProjectTaskService projectTaskService, UserService userService)
        {
            _projectTaskService = projectTaskService;
            _userService = userService;
        }

        public async Task< IActionResult> Index(int projectId)
        {
            var projectTasks = await _projectTaskService.GetProjectTasks(projectId);
            return View(projectTasks.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddShowModal(int projectId)
        {
            var user =await _userService.GetAll();

            var projectTask = new ProjectTaskAddUpdateVM() 
            { 
                ProjectId = projectId, 
                userVMs = user.Data 
            };

            return PartialView("_AddUpdatepp", projectTask);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShowModal(int taskId)
        {
            var user = await _userService.GetAll();
            var projectTask = await _projectTaskService.GetById(taskId);
            projectTask.Data.userVMs= user.Data;
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

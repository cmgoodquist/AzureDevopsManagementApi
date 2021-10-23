using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VssFacade.Clients.Project;

namespace AzdosManagementDashboardApi.Projects.DrivingDependencies
{
    [ApiController]
    [Route("api/v1/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectClient _service;

        public ProjectController(IProjectClient service) => _service = service;

        [HttpGet("all")]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _service.GetAllProjects();
            return Ok(projects);
        }
    }
}

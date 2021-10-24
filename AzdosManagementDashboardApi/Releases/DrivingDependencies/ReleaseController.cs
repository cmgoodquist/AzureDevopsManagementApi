using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VssFacade.Clients.Release;

namespace AzdosManagementDashboardApi.Releases
{
    [ApiController]
    [Route("api/v1/release")]
    public class ReleaseController : ControllerBase
    {
        private IReleaseClient _client;

        public ReleaseController(IReleaseClient client)
        {
            _client = client;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetReleaseDefinitions(string projectName)
        {
            var releaseDefinitions = await _client.GetReleaseDefinitions(projectName);
            return Ok(releaseDefinitions);
        }
    }
}

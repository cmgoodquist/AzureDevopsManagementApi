using Microsoft.AspNetCore.Mvc;
using System;

namespace AzdosManagementDashboardApi.AzdosManagementDashboard.DrivingDependencies
{
    [ApiController]
    [Route("api/v1/azdosmanagementdashboard")]
    public class AzdosManagementDashboardController : ControllerBase
    {
        private readonly IAzdosManagementDashboardService _service;

        public AzdosManagementDashboardController(IAzdosManagementDashboardService service) => _service = service;

        [HttpGet]
        public IActionResult GetAzdosManagementDashboard()
        {
            throw new NotImplementedException();
        }
    }
}

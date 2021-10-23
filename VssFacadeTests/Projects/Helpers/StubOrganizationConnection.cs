using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Moq;
using System;
using System.Threading.Tasks;
using VssFacade;

namespace VssFacadeTests.Projects.Helpers
{
    public class StubOrganizationConnection : IOrganizationConnection
    {
        private readonly IPagedList<TeamProjectReference> _projectReferences;

        public StubOrganizationConnection(IPagedList<TeamProjectReference> projectReferences)
        {
            _projectReferences = projectReferences;
        }

        public T GetClient<T>() where T : VssHttpClientBase
        {
            if (typeof(T) == typeof(ProjectHttpClient))
            {
                var projectMock = new Mock<ProjectHttpClient>(new Uri("https://something"), new VssCredentials());
                projectMock
                    .Setup(mock => mock.
                        GetProjects(null, null, null, null, null, null))
                    .Returns(Task.FromResult(_projectReferences));

                return projectMock.Object as T;
            }

            throw new NotImplementedException();
        }

    }
}

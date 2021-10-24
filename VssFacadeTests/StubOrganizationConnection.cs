using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi;
using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.Clients;
using Microsoft.VisualStudio.Services.WebApi;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VssFacade;

namespace VssFacadeTests
{
    public class StubOrganizationConnection : IOrganizationConnection
    {
        public IPagedList<TeamProjectReference> Projects { get; set; }
        public List<ReleaseDefinition> ReleaseDefinitions { get; set; }

        public T GetClient<T>() where T : VssHttpClientBase
        {
            if (typeof(T) == typeof(ProjectHttpClient) && !(Projects is null))
            {
                var projectMock = new Mock<ProjectHttpClient>(new Uri("https://something"), new VssCredentials());
                projectMock
                    .Setup(mock => mock
                        .GetProjects(null, null, null, null, null, null))
                    .Returns(Task.FromResult(Projects));

                return projectMock.Object as T;
            }
            else if(typeof(T) == typeof(ReleaseHttpClient) && !(ReleaseDefinitions is null))
            {
                var releaseDefinitionsMock = new Mock<ReleaseHttpClient>(new Uri("https://something"), new VssCredentials());
                releaseDefinitionsMock
                    .Setup(mock => mock
                        .GetReleaseDefinitionsAsync(It.IsAny<string>(), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, default(CancellationToken)))
                    .Returns(Task.FromResult(ReleaseDefinitions));

                return releaseDefinitionsMock.Object as T;
            }

            throw new NotImplementedException();
        }

    }
}

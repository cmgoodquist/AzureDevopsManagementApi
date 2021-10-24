using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using VssFacade.Clients.Project;
using VssFacade.Clients.Project.Implementations;
using VssFacadeTests.Projects.Helpers;
using Xunit;

namespace VssFacadeTests.Projects
{
    public class GetAllProjectsShould
    {
        [Theory]
        [MemberData(nameof(GetAllProjectsTheoryData.TeamProjectReferences), MemberType = typeof(GetAllProjectsTheoryData))]
        public async Task ReturnAllProjects(IPagedList<TeamProjectReference> projectReferences)
        {
            //Arrange
            var expectedProjects = projectReferences.Select(source => new Project(source));
            var stubConnection = new StubOrganizationConnection()
            {
                Projects = projectReferences
            };
            var projectClient = new ProjectClient(stubConnection);

            //Act
            var actualProjects = await projectClient.GetAllProjects();

            //Assert
            Assert.Equal(expectedProjects, actualProjects, new ProjectEqualityComparer());
        }

        private class ProjectEqualityComparer : IEqualityComparer<Project>
        {
            public bool Equals([AllowNull] Project expected, [AllowNull] Project actual)
            {
                if (expected is null || actual is null)
                    return false;

                return expected.Id == actual.Id
                    && expected.Name == actual.Name
                    && expected.Description == actual.Description
                    && expected.Url == actual.Url;
            }

            public int GetHashCode([DisallowNull] Project subject) => subject.GetHashCode();
        }
    }
}

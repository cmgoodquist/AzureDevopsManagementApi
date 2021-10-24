using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using VssFacade.Clients.Project;
using VssFacade.Clients.Project.Implementations;
using Xunit;

namespace VssFacadeTests.Projects
{
    public class GetAllProjectsShould
    {
        [Fact]
        public async Task ReturnAllProjects()
        {
            //Arrange
            var projectReferences = SetUpTestData();
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

        private IPagedList<TeamProjectReference> SetUpTestData()
        {
            var projects = new PagedList<TeamProjectReference>();
            for (var i = 0; i < 3; i++)
            {
                projects.Add(new TeamProjectReference()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name",
                    Description = "Description",
                    Url = "Url"
                });
            }
            return projects;
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

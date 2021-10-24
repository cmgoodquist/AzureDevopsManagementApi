using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VssFacade.Clients.Release;
using VssFacade.Clients.Release.Implementations;
using VssFacadeTests.Projects.Helpers;
using Xunit;

namespace VssFacadeTests.Releases
{
    public class GetAllReleaseDefinitionsShould
    {
        [Fact]
        public async Task ReturnAllReleaseDefinitions()
        {
            //Arrange
            var sourceReleaseDefinitions = SetUpReleaseDefinitions();
            var stubConnection = new StubOrganizationConnection()
            {
                ReleaseDefinitions = sourceReleaseDefinitions
            };
            var expectedReleaseDefinitions = sourceReleaseDefinitions.Select(definition => new ReleaseDefinitionReference(definition));
            var client = new ReleaseClient(stubConnection);

            //Act
            var actualReleaseDefinitions = await client.GetReleaseDefinitions("anything");

            //Assert
            Assert.Equal(expectedReleaseDefinitions, actualReleaseDefinitions, new ReleaseDefinitionEqualityComparer());
        }

        private List<ReleaseDefinition> SetUpReleaseDefinitions()
        {
            var definitions = new List<ReleaseDefinition>();
            for(var i = 0; i < 3; i++)
            {
                definitions.Add(new ReleaseDefinition()
                {
                    Id = new Random().Next(),
                    Name = Guid.NewGuid().ToString(),
                    Url = "https://something"
                });
            }
            return definitions;
        }

        private class ReleaseDefinitionEqualityComparer : IEqualityComparer<ReleaseDefinitionReference>
        {
            public bool Equals([AllowNull] ReleaseDefinitionReference expected, [AllowNull] ReleaseDefinitionReference actual)
            {
                if (expected is null || actual is null)
                    return false;

                return expected.Id == actual.Id
                    && expected.Name == actual.Name
                    && expected.Url == actual.Url;
            }

            public int GetHashCode([DisallowNull] ReleaseDefinitionReference definition) => definition.GetHashCode();
        }
    }
}

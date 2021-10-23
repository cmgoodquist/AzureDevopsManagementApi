using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using Xunit;

namespace VssFacadeTests.Projects.Helpers
{
    internal class GetAllProjectsTheoryData
    {
        public static TheoryData<IPagedList<TeamProjectReference>> TeamProjectReferences()
        {
            var data = new TheoryData<IPagedList<TeamProjectReference>>();
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

            data.Add(projects);
            return data;
        }

    }
}

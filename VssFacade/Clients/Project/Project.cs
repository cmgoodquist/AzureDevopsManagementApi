using Microsoft.TeamFoundation.Core.WebApi;
using System;

namespace VssFacade.Clients.Project
{
    public class Project
    {
        internal Project(TeamProjectReference source)
        {
            Id = source.Id;
            Name = source.Name;
            Description = source.Description;
            Url = source.Url;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Url { get; }

    }
}

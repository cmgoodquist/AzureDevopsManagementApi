using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace VssFacade.Clients.Release
{
    public class ReleaseDefinitionReference
    {
        public ReleaseDefinitionReference(ReleaseDefinition source)
        {
            Id = source.Id;
            Name = source.Name;
            Url = source.Url;
        }

        public int Id { get; }
        public string Name { get; }
        public string Url { get; }
    }
}

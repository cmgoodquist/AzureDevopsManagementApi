using Microsoft.TeamFoundation.Core.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VssFacade.Clients.Project.Implementations
{
    internal class ProjectClient : OrganizationClient, IProjectClient
    {
        internal ProjectClient(IOrganizationConnection connection)
            : base(connection)
        { }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var client = _connection.GetClient<ProjectHttpClient>();
            var projects = await client.GetProjects();
            return projects.Select(project => new Project(project));
        }
    }
}

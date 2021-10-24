using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.Clients;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VssFacade.Clients.Release.Implementations
{
    internal class ReleaseClient : OrganizationClient, IReleaseClient
    {
        internal ReleaseClient(IOrganizationConnection connection)
            : base(connection)
        { }

        public async Task<IEnumerable<ReleaseDefinitionReference>> GetReleaseDefinitions(string projectName)
        {
            var client = _connection.GetClient<ReleaseHttpClient>();
            var releaseDefinitions = await client.GetReleaseDefinitionsAsync(projectName);
            return releaseDefinitions.Select(definition => new ReleaseDefinitionReference(definition));
        }
    }
}

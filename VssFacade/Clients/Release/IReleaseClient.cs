using System.Collections.Generic;
using System.Threading.Tasks;

namespace VssFacade.Clients.Release
{
    public interface IReleaseClient
    {
        Task<IEnumerable<ReleaseDefinitionReference>> GetReleaseDefinitions(string projectName);
    }
}
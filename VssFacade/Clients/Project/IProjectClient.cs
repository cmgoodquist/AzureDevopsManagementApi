using System.Collections.Generic;
using System.Threading.Tasks;

namespace VssFacade.Clients.Project
{
    public interface IProjectClient
    {
        Task<IEnumerable<Project>> GetAllProjects();
    }
}
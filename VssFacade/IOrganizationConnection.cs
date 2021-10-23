using Microsoft.VisualStudio.Services.WebApi;

namespace VssFacade
{
    internal interface IOrganizationConnection
    {
        T GetClient<T>() where T : VssHttpClientBase;
    }
}

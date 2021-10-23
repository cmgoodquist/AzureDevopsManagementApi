using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;

namespace VssFacade
{
    internal class OrganizationConnection : IOrganizationConnection
    {
        private readonly VssConnection _connection;

        public OrganizationConnection(string organizationUrl, string personalAccessToken)
        {
            _connection = new VssConnection(new Uri(organizationUrl), new VssBasicCredential("pat", personalAccessToken));
        }

        public T GetClient<T>() where T : VssHttpClientBase => _connection.GetClient<T>();
    }
}

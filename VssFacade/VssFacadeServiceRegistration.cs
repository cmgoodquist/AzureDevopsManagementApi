using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VssFacade.Clients.Project;
using VssFacade.Clients.Project.Implementations;

namespace VssFacade
{
    public static class VssFacadeServiceRegistration
    {
        public static IServiceCollection RegisterVssFacadeServices(this IServiceCollection services, IConfiguration configuration)
        {
            var personalAccessToken = configuration["ProjectsPat"];
            var organizationUrl = configuration["OrganizationUrl"];
            services.AddSingleton<IOrganizationConnection, OrganizationConnection>(provider =>
                new OrganizationConnection(organizationUrl, personalAccessToken)
            );
            services.AddScoped<IProjectClient, ProjectClient>(provider =>
                new ProjectClient(provider.GetRequiredService<IOrganizationConnection>())
            );

            return services;
        }
    }
}

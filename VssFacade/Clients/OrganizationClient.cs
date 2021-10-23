namespace VssFacade
{
    internal abstract class OrganizationClient
    {
        protected readonly IOrganizationConnection _connection;

        internal OrganizationClient(IOrganizationConnection connection) => _connection = connection;
    }
}

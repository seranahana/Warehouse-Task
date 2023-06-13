using Microsoft.Extensions.DependencyInjection;

namespace Warehouse
{
    internal static class ServicesProviderFactory
    {
        internal static IServiceProvider ServiceProvider { get; }

        static ServicesProviderFactory()
        {
            Startup startup = new();
            ServiceCollection services = new();
            startup.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

    }
}

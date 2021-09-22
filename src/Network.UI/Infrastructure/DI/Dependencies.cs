using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mx.EntityFramework.Contracts;
using Network.Tester.Data;
using Network.UI.Messaging;
using Rebus.Config;
using Rebus.ServiceProvider;

namespace Network.UI.Infrastructure.DI
{
    public static class Dependencies
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration config)
        {
            var entityContextConnectionString = config["EntityContext"];
            services.AddScoped<IEntityContext>(provider =>
            {
                return new EntityContext(entityContextConnectionString);
            });

            var asbConnection = config["ServiceBus"];
            services.AddRebus((configurer, provider) =>
            {
                return configurer.Transport(transport => transport.UseAzureServiceBusAsOneWayClient(asbConnection));
            });
            
            services.AddTransient<IWineryRepository, WineryRepository>();
            services.AddTransient<IMessageClient, MessageClient>();
            return services;
        }
        
    }
}
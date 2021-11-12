using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mx.EntityFramework.Contracts;
using Network.Tester.Clients;
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

            services.Configure<BaseUrisConfiguration>(config.GetSection("BaseUris"));

            //var asbConnection = config["ServiceBus"];
            //services.AddRebus((configurer, provider) =>
            //{
            //    return configurer.Transport(transport => transport.UseAzureServiceBusAsOneWayClient(asbConnection));
            //});

            //var azureStorageConnection = config["AzureStorage"];
            //services.AddScoped<IQueueClient>(provider =>
            //{
            //    return new NetworkQueueClient(azureStorageConnection);
            //});
            
            services.AddTransient<IWineryRepository, WineryRepository>();
           // services.AddTransient<IMessageClient, MessageClient>();
            services.AddTransient<ICorpRepository, CorpRepository>();
            services.AddHttpClient<ITestWebClient, TestWebClient>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var uris = provider.GetRequiredService<IOptions<BaseUrisConfiguration>>().Value;
                    client.BaseAddress = new Uri(uris.TestWeb);
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(30));

            services.AddTransient<ITestWebRepository, TestWebRepository>();
            return services;
        }
        
    }
}
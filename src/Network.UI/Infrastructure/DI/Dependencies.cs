using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mx.EntityFramework.Contracts;
using Network.Tester.Data;

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

            services.AddTransient<IWineryRepository, WineryRepository>();
            return services;
        }
        
    }
}
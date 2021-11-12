using System;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;


namespace Network.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    configurationBuilder.AddJsonFile("appsettings.json", false, reloadOnChange: true);
                    configurationBuilder.AddJsonFile("appsettings.secrets.json", true, reloadOnChange: true);
                    configurationBuilder.AddEnvironmentVariables();

                    var interimConfiguration = configurationBuilder.Build();
                    var secretClient = new SecretClient(
                        new Uri(interimConfiguration["KeyVaultUrl"]),
                        new DefaultAzureCredential(
                            new DefaultAzureCredentialOptions
                            {
                                ExcludeVisualStudioCodeCredential = true,
                                ExcludeVisualStudioCredential = true
                            }));
                    configurationBuilder.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());


                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
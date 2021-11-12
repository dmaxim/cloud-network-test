
using Microsoft.Extensions.Configuration;

namespace Network.UI.Models
{
    public class VaultIndexModel
    {
        public VaultIndexModel(IConfiguration configuration)
        {
            TestSecret = configuration["VaultTesting:TestSecret"];
        }

        public string TestSecret { get; }
    }
}

using eShop.Api;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace eShop.Testing
{
    public static class ConfigurationFactory
    {
        private static IConfiguration configuration;
        public static IConfiguration Create()
        {
            if (configuration == null)
            {
                var basePath = Path.GetFullPath("../../../../../src/eShop.Api");

                configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", false)
                    .Build();
            }

            return configuration;
        }
    }
}

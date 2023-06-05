using Microsoft.Extensions.Configuration;

namespace Tests.Framework.Helpers.Configuration
{
    public static class ConfigurationProvider
    {
        public static IConfiguration TestsConfiguration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables()
            .Build();
    }
}
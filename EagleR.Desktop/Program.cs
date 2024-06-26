using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EagleR.Desktop;

internal class Program
{
    [STAThread]
    static void Main()
    {
        using var host = CreateHostBuilder().Build();

        ApplicationConfiguration.Initialize();
        Application.Run(host.Services.GetRequiredService<Main>());
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddEnvironmentVariables();
                builder.AddUserSecrets<Program>();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<Main>();
            });
    }
}
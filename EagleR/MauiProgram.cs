using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EagleR;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var configuration = new ConfigurationBuilder()
            .AddJsonStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("EagleR.appsettings.json")!)
            .AddJsonStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("EagleR.appsettings.json.user")!)
            .Build();
        
        builder.Configuration.AddConfiguration(configuration);

#if ANDROID
        SendActivity.Initialize(configuration.GetConnectionString("StorageAccount")!);
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

using CommunityToolkit.Maui;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using PersonalExpenseApp.Services;
namespace PersonalExpenseApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMicrocharts().UseMauiCommunityToolkit();
        builder.Services.AddSingleton(new DatabaseService(
    Path.Combine(FileSystem.AppDataDirectory, "expense.db3")
));
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            
        });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}

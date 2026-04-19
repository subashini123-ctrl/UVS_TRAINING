using ExpenseTracker.Services;
using ExpenseTracker.ViewModels;
using ExpenseTrackerApp;
using ExpenseTrackerApp.ViewModel;
using ExpenseTrackerApp.Views;
using CommunityToolkit.Maui;

namespace ExpenseTracker;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(f =>
        {
            f.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        }).UseMauiCommunityToolkit();
        builder.Services.AddSingleton<DatabaseService>();
        // ViewModels
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<AddExpenseViewModel>();
        // Pages
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<AddExpensePage>();
        return builder.Build();
    }
}
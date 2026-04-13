using Microsoft.Extensions.Logging;
using StudentList.View.StudentList;
using StudentList.ViewModel.StudentList;

namespace StudentList
{
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

#if DEBUG
    		builder.Logging.AddDebug();


#endif
            builder.Services.AddSingleton<StudentViewModel>();

            builder.Services.AddTransient<StudentListPage>();
            builder.Services.AddTransient<StudentViewModel>();

            return builder.Build();
        }
    }
}

using Microsoft.Extensions.Logging;
using UzdevumuParvaldnieksMAUIApp.Model;
using UzdevumuParvaldnieksMAUIApp.ViewModels;
using UzdevumuParvaldnieksMAUIApp.Views;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksMAUIApp
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
            builder.Services.AddSingleton<ITestDataFactory, TestDataFactoryList>();
            builder.Services.AddSingleton<ITestDataFactoryAsync, UzdevumiApiServiceAsync>();

            builder.Services.AddSingleton<IUzdevumuSarakstsViewModel, UzdevumuSarakstsViewModel>();
            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5138/")
            });
            builder.Services.AddSingleton<UzdevumuSarakstsViewModelAsync>();
            builder.Services.AddSingleton<UzdevumsViewModelAsync>();
            builder.Services.AddSingleton<UzdevumsViewAsync>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

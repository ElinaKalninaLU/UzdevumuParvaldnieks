using Microsoft.Extensions.Logging;
using UzdevumuParvaldnieksMAUIApp.ViewModels;
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
            builder.Services.AddSingleton<ITestDataFactory, TestDataFactoryArray>();
            builder.Services.AddSingleton<IUzdevumuSarakstsViewModel, UzdevumuSarakstsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

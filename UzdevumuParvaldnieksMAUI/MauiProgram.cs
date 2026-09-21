using Microsoft.Extensions.Logging;

namespace UzdevumuParvaldnieksMAUI
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
            builder.Services.AddTransient<ITestDataFactory, TestDataFactoryList>();
            builder.Services.AddTransient<ViewModel.IUzdevumuSarakstsViewModel, ViewModel.UzdevumuSarakstsViewModel>();
            builder.Services.AddTransient<ViewModel.IEditUzdevumsViewModel, ViewModel.EditUzdevumsViewModel>();
            builder.Services.AddSingleton<Data.IDataProvider, Data.TestDataprovider>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

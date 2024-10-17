using Microsoft.Extensions.Logging;
using WarehouseLogic;
using WarehouseLogic.Extensions;

namespace MAUIHouseControl
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
            builder.Services.AddNinjectBindings([new WarehouseLogicModule()]);
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}

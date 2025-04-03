using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
// 🔹 Agregamos el using necesario

namespace ProyectoBomba
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit() // 🔹 Inicializa CommunityToolkit
                .UseMauiCommunityToolkitMediaElement() // 🔹 Inicializa MediaElement
                .ConfigureFonts(fonts =>
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
}

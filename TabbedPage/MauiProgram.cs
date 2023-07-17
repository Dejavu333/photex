using PHOTEX._SERVICE;
using PHOTEX.MODEL.DOMAIN;
using PHOTEX.MODEL.REPOSITORY;
using PHOTEX.SERVICE;

namespace PHOTEX;

public static class MauiProgram
{
    //properties
    public static ServiceProvider _container;
    public static Settings _configuration;

    //methods
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            });
        //dependency injection
        builder.Services.AddSingleton<IPhotoRepository<Photo>, PhotoRepository>();
        builder.Services.AddSingleton<ITextRepository<Text>, TextRepository>();
        builder.Services.AddSingleton<ITextService<Text>, TextService>();
        builder.Services.AddSingleton<IPhotoService<Text,Photo>, PhotoService>();
        builder.Services.AddSingleton<TextController>();
        builder.Services.AddSingleton<PhotoController>();
        //IOC container
        _container = builder.Services.BuildServiceProvider();
        //configuration 
        return builder.Build();
    }
}

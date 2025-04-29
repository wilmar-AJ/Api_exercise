using Api_exercise.Repositories;
using Api_exercise.Repositories.Interfaces;
using Api_exercise.Services;
using Api_exercise.Services.Interfaces;
using Api_exercise.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Api_exercise;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
			builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
		builder.Services.AddSingleton<IResponseService, ResponseService>();

		builder.Services.AddTransient<ProductsViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif
        var app = builder.Build();

		Startup.ServicesProvider = app.Services;

		return builder.Build();
	}
}

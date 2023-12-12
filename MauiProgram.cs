namespace Sinca_Teodora_Lab7;

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
			})
            .ConfigureEssentials(essentials =>
            {
                essentials.UseMapServiceToken("9pWVMijQbzScVJWSrAwB~7n99qbz8dRJwkdCU1ANIdA~AiuOHq562Mtu2QlJeMbplCb8DsNJJwiM3XVZMTfoG77MV0WOlH4v13K7Af38Pev3");
            });

        return builder.Build();
	}
}

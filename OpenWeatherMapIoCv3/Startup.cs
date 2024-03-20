using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace OpenWeatherMapIoCv3;

public class Startup
{
	private readonly IServiceProvider provider;
	public IServiceProvider Provider => provider;

	
	/* constructor comes here */
	public Startup()
	{
		var services = new ServiceCollection();

		// add necessary services
		services.AddSingleton<IOpenApi, OpenAirApi>();
		services.AddSingleton<IOpenApi, OpenMapApi>();
		services.AddSingleton<IOpenApi, OpenAirApiMocked>();
		services.AddSingleton<IOpenApi, OpenMapApiMocked>();
		services.AddSingleton<IWeather, Weather>();

		// build the pipeline
		provider = services.BuildServiceProvider();
	}
}

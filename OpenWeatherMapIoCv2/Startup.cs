using Microsoft.Extensions.DependencyInjection;
using System;

namespace OpenWeatherMap
{
	public class Startup
	{
		private readonly IServiceProvider provider;
		public IServiceProvider Provider => provider;

		
		/* constructor comes here */
		public Startup()
		{
			var services = new ServiceCollection();

			// add necessary services
			//services.AddSingleton<IOpenAirApi, OpenAirApi>();
			services.AddSingleton<IOpenApi, OpenAirApi>();
			services.AddSingleton<IOpenApi, OpenMapApi>();
			services.AddSingleton<IWeather, Weather>();

			// build the pipeline
			provider = services.BuildServiceProvider();
		}
	}
}

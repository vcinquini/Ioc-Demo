using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
	class Weather : IWeather
	{
#if DEMO1

		readonly IOpenApi _mapApi;
		//readonly IOpenApi _airApi;

		public Weather(IOpenApi MapApi) //, IOpenApi AirApi)
		{
			_mapApi = MapApi;
			//_airApi = AirApi;
		}

		public async Task<string> GetWeatherData()
		{
			return await _mapApi.GetData();
		}

#elif DEMO2

		readonly IServiceProvider _serviceProvider;

		public Weather(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		public async Task<string> GetWeatherData()
		{
			var services = _serviceProvider.GetServices<IOpenApi>();

			var h1 = services.First(o => o.GetType() == typeof(OpenAirApi));
			var h2 = services.First(o => o.GetType() == typeof(OpenMapApi));

			var result1 = await h1.GetData();
			var result2 = await h2.GetData();

			return string.Concat("[", result1, ",", result2, "]");
		}
#endif
	}
}

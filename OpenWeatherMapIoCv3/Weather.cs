using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherMapIoCv3;

class Weather : IWeather
{
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
		var h3 = services.First(o => o.GetType() == typeof(OpenAirApiMocked));
		var h4 = services.First(o => o.GetType() == typeof(OpenMapApiMocked));

		var result1 = await h1.GetData();
		var result2 = await h2.GetData();
		var result3 = await h3.GetData();
		var result4 = await h4.GetData();

		var text = $"{{ \"result1\": { result1 }, \"result2\": \"{ result2 }\", \"result3\": { result3 }, \"result4\": { result3 } }} ";
		return text;
	}
}

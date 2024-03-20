using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace OpenWeatherMapIoCv3;

class Program
{
	static void Main(string[] args)
	{
		// instantiate startup
		// all the constructor logic would happen
		var startup = new Startup();

		// request an instance of type IWeather
		// from the ServicePipeline built
		// returns an object of type Weather
		var service = startup.Provider.GetService<IWeather>();

		var texto = service.GetWeatherData().Result;

		Console.WriteLine(FormatJson(texto));
	}

	private static string FormatJson(string json)
	{
		dynamic parsedJson = JsonConvert.DeserializeObject(json);
		return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
	}

}

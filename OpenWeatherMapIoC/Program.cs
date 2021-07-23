using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace OpenWeatherMap
{
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
			//var service = startup.Provider.GetRequiredService<IWeather>();
			//var texto = service.GetWeatherData().Result;
			//Console.WriteLine(FormatJson(texto));

			var service2 = startup.Provider.GetRequiredService<IWind>();
			var texto2 = service2.GetWeatherData();
			Console.WriteLine($"\n{texto2}");
		}

		private static string FormatJson(string json)
		{
			dynamic parsedJson = JsonConvert.DeserializeObject(json);
			return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
		}

	}
}

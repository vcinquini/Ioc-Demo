using Newtonsoft.Json;
using System;

namespace OpenWeatherMap
{
	class Program
	{
		static void Main(string[] args)
		{
			//OpenMapApi op = new OpenMapApi();
			OpenAirApi op = new OpenAirApi();

			Weather weather = new Weather(op);

			string texto = weather.GetWeatherData().Result;

			Console.WriteLine(FormatJson(texto));
		}

		private static string FormatJson(string json)
		{
			dynamic parsedJson = JsonConvert.DeserializeObject(json);
			return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
		}
	}
}

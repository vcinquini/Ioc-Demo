using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMapIoCv3;

class Program
{
	/****************************************
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
	***************************************/

	private static string FormatJson(string json)
	{
		dynamic parsedJson = JsonConvert.DeserializeObject(json);
		return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
	}


	
	//async Task Main feature allowed from C# 7.1+
	public static async Task Main(string[] args)
	{
		//Composition root
		IServiceProvider services = ConfigureServices();
		IConfiguration configuration = services.GetRequiredService<IConfiguration>();

		// request an instance of type IWeather
		// from the ServicePipeline built
		// returns an object of type Weather
		var service = services.GetService<IWeather>();

		var texto = await service.GetWeatherData();

		Console.WriteLine(FormatJson(texto));
	}


	public static IServiceProvider ConfigureServices()
	{
		IServiceCollection services = new ServiceCollection();

		IConfigurationRoot configuration = new ConfigurationBuilder().Build();

		services.AddSingleton<IOpenApi, OpenAirApi>();
		services.AddSingleton<IOpenApi, OpenMapApi>();
		services.AddSingleton<IOpenApi, OpenAirApiMocked>();
		services.AddSingleton<IOpenApi, OpenMapApiMocked>();
		services.AddSingleton<IWeather, Weather>();

		services.AddSingleton<IConfigurationRoot>(configuration);
		services.AddSingleton<IConfiguration>(configuration);

		return services.BuildServiceProvider();
	}
}

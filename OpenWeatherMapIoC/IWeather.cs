using System.Threading.Tasks;

namespace OpenWeatherMap
{
	interface IWeather
	{
		Task<string> GetWeatherData();
	}
}
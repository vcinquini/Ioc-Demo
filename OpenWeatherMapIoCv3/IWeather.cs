using System.Threading.Tasks;

namespace OpenWeatherMapIoCv3;

interface IWeather
{
	Task<string> GetWeatherData();
}
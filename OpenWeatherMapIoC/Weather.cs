using System.Threading.Tasks;

namespace OpenWeatherMap
{
	class Weather : IWeather
	{
		readonly IOpenApi _airApi;
		readonly IOpenApi _mapApi;

		public Weather(IOpenApi MapApi, IOpenApi AirApi)
		{
			_mapApi = MapApi;
			_airApi = AirApi;
		}

		public async Task<string> GetWeatherData()
		{
			var r1 = await _mapApi.GetData();
			var r2 = await _airApi.GetData();

			return string.Concat("[", r1, ",", r2, "]");
		}
	}
}

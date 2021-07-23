using System.Threading.Tasks;

namespace OpenWeatherMap
{
	class Weather
	{
		readonly IApi _api;

		public Weather(IApi api)
		{
			_api = api;
		}

		public async Task<string> GetWeatherData()
		{
			return await _api.GetData();
		}
	}
}

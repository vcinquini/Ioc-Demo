using System.Threading.Tasks;

namespace OpenWeatherMap
{
	class Weather
	{
		readonly OpenMapApi _api;

		public Weather()
		{
			_api = new OpenMapApi();
		}

		public async Task<string> GetWeatherData()
		{
			return await _api.GetData();
		}
	}
}

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
	class OpenMapApi
	{
		public async Task<string> GetData()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://community-open-weather-map.p.rapidapi.com/find?q=sao%20paulo&cnt=50&mode=null&lon=0&type=link%2C%20accurate&lat=0&units=imperial%2C%20metric"),
				Headers =
				{
					{ "x-rapidapi-key", "6a3a456950msh29fe948fd7e1135p1b03a8jsnd56b25654414" },
					{ "x-rapidapi-host", "community-open-weather-map.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return body;
			}
		}
	}
}

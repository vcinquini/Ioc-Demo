using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
	class OpenAirApi
	{
		public async Task<string> GetData()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://air-quality.p.rapidapi.com/history/airquality?lon=-78.638&lat=35.779"),
				Headers =
				{
					{ "x-rapidapi-key", "6a3a456950msh29fe948fd7e1135p1b03a8jsnd56b25654414" },
					{ "x-rapidapi-host", "air-quality.p.rapidapi.com" },
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

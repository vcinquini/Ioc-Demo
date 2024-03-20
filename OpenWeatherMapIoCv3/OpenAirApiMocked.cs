using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace OpenWeatherMapIoCv3;

class OpenAirApiMocked : IOpenApi
{
	public async Task<string> GetData()
	{
		dynamic body = new {
			message = "GetData has been called",
			className = "OpenAirApiMocked"
		};

		string res = JsonSerializer.Serialize(body);

		return await Task.FromResult(res);
	}
}

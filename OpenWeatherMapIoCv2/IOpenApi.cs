using System.Threading.Tasks;

namespace OpenWeatherMap
{
	interface IOpenApi
	{
		Task<string> GetData();
	}
}
using System.Threading.Tasks;

namespace OpenWeatherMap
{
	interface IApi
	{
		Task<string> GetData();
	}
}
using System.Threading.Tasks;

namespace OpenWeatherMapIoCv3;


interface IOpenApi
{
	Task<string> GetData();
}
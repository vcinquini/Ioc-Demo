using System.Threading.Tasks;

namespace OpenWeatherMap
{
	class Wind : IWind
	{
		readonly string _direction;

		public Wind(string direction)
		{
			_direction = direction;
		}

		public string GetWeatherData()
		{
			return _direction;
		}
	}
}

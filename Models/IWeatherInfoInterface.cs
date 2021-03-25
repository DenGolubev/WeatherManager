using System.Collections.Generic;


namespace WeatherManager.Models
{
    public interface IWeatherInfoInterface
    {
        void Add(WeatherInfo item);
        IEnumerable<WeatherInfo> GetAll();
        WeatherInfo Find(int id);
        WeatherInfo Remove(int id);
        void Update(WeatherInfo item);
    }
}


using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace WeatherManager.Models
{
    public class WeatherInfoRepository : IWeatherInfoInterface
    {
        private static ConcurrentDictionary<int, WeatherInfo> weatherInfo = new ConcurrentDictionary<int, WeatherInfo>();
        public WeatherInfoRepository()
        {
            Add(new WeatherInfo { Id = 1, Date = DateTime.UtcNow.ToShortDateString(), Temp = 4 });
            Add(new WeatherInfo { Id = 2, Date = DateTime.UtcNow.ToShortDateString(), Temp = 5 });
            Add(new WeatherInfo { Id = 3, Date = DateTime.UtcNow.ToShortDateString(), Temp = 6 });
        }
        public void Add(WeatherInfo item)
        {
            weatherInfo[item.Id] = item;
        }

        public WeatherInfo Find(int id)
        {
            weatherInfo.TryGetValue(id, out WeatherInfo item);
            return item;
        }

        public IEnumerable<WeatherInfo> GetAll()
        {
            return weatherInfo.Values;
        }

        public WeatherInfo Remove(int id)
        {
            weatherInfo.TryRemove(id, out WeatherInfo item);
            return item;
        }

        public void Update(WeatherInfo item)
        {
            weatherInfo[item.Id] = item;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStationApi.Services.Interfaces
{
    public interface IWeatherClient
    {
        public Task<string> CalculateAverageTemperature(int stationId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WeatherStationApi.Services.Interfaces;
using WeatherStationApi.Models;

namespace WeatherStationApi.Services
{
    public class WeatherStationService : IWeatherStationService
    {
        private readonly IWeatherClient weatherClient;

        public WeatherStationService(IWeatherClient weatherClient)
        {
            this.weatherClient = weatherClient;
        }

        public Task<string> HelloWorld()
        {
            return Task.FromResult<string>("Hello World Again");
        }

        public Task<string> GetFromClient(int id)
        {
            return weatherClient.CalculateAverageTemperature(id);
        }
    }
}
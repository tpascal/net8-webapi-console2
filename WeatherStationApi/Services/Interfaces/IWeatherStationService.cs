using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WeatherStationApi.Models;

namespace WeatherStationApi.Services.Interfaces
{
    public interface IWeatherStationService
    {
        Task<string> GetFromClient(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WeatherStationApi.Services.Interfaces;

namespace WeatherStationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherStationController : ControllerBase
    {
        private readonly IWeatherStationService _weatherStationService;

        public WeatherStationController(IWeatherStationService weatherStationService)
        {
            _weatherStationService = weatherStationService;
        }

        [HttpGet("{id}")]
        public Task<string> Get(int id)
        {
            var result = _weatherStationService.GetFromClient(id);

            return result;
        }
    }
}
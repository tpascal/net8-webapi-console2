using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WeatherStationApi.Models;
using WeatherStationApi.Services.Interfaces;
using System.Net.Http.Headers;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherStationApi.Services
{
    public class WeatherClient : IWeatherClient
    {
        private readonly HttpClient client;

        public WeatherClient(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<string> CalculateAverageTemperature(int stationId)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:127.0) Gecko/20100101 Firefox/127.0");

            var averageTemp = 0.0D;
       
            try
            {
                var result = (await ProcessResponseAsync(client, stationId)).observations;

                if (result != default && result.data != default)
                {
                    var count = 0;
                    var tempTotal = 0.0;
                    foreach (var item in result.data)
                    {
                        if(item.air_temp == default) continue;

                        count++;
                        var airTemp = (double)item.air_temp;
                        tempTotal += airTemp;
                    }

                    if(count > 0)
                        averageTemp = (tempTotal / count);
                }

            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

            return averageTemp.ToString("#.##");
        }

        private async Task<WeatherObservationResponse> ProcessResponseAsync(HttpClient client, int stationId)
        {
            var url = $"http://www.bom.gov.au/fwo/IDS60801/IDS60801.{stationId}.json";
            await using Stream stream = await client.GetStreamAsync(url);

            var options = new JsonSerializerOptions 
            { 
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var result = await JsonSerializer.DeserializeAsync<WeatherObservationResponse>(stream, options);
            return result ?? new();
        }
    }
}
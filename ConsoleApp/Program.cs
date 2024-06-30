namespace ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new();
        await RunHttpClient(client);
    }

    static async Task RunHttpClient(HttpClient client)
    {
        try
        {
            var stations = Stations.GetStations();
            var sortedStations = from s in stations orderby s.Key ascending select s;

            Console.WriteLine($"----------------------------------------");
            var d = sortedStations.ToDictionary(pair => pair.Key, pair => pair.Value);

            for (int i = 0; i < d.Count(); i++)
            {
                Console.WriteLine($"| {i} | {d.ElementAt(i).Key} ({d.ElementAt(i).Value})");
                Console.WriteLine($"----------------------------------------");
            }

            Console.WriteLine($"Which weather observation (0 - {d.Count() - 1})?");
            var observation = Console.ReadLine();

            var stationId = 0;
            int.TryParse(observation, out var isInteger);
            if (isInteger > -1 && isInteger >= 0 && isInteger <= sortedStations.Count())
            {
                Console.WriteLine($"Retrieving data for the station at {sortedStations.ElementAt(isInteger).Key}");
                stationId = sortedStations.ElementAt(isInteger).Value;
            }
            else
            {
                // fallback station
                stationId = stations["Adelaide Airport"];
            }

            var result = (await CallApiAsync(client, stationId));
            if (result != default)
            {
                Console.WriteLine($"Average temperature: {result} degrees");
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static async Task<string> CallApiAsync(HttpClient client, int stationId)
    {
        return await client.GetStringAsync($"https://localhost:7224/api/weatherstation/{stationId}");
    }
}

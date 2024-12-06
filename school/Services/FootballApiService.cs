using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using school.Model;
using static school.Model.Team;
namespace school.Services
{
    public class FootballApiService
    {
        private readonly HttpClient _httpClient;

        public FootballApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            string url = "https://api.schoolfootball.com/teams";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Team>>(json);
            }
            else
            {
                throw new Exception($"Failed to fetch teams: {response.StatusCode}");
            }
        }
    }
}

using BoekenOnline.Data;
using Schoolvoetbalapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace Schoolvoetbalapp.Data
{
    internal class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Wedstrijd>> GetWedstrijdenAsync()
        {
            var response = await _httpClient.GetAsync("https://schoolvoetbal4sweb.test/api/games");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Wedstrijd>>(json);
        }

        public async Task SynchroniseerWedstrijdenMetDatabase(SchoolvoetbalOnlineContext dbContext)
        {
            var wedstrijden = await GetWedstrijdenAsync();

            foreach (var wedstrijd in wedstrijden)
            {
                if (!dbContext.Wedstrijden.Any(w => w.Id == wedstrijd.Id))
                {
                    dbContext.Wedstrijden.Add(wedstrijd);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}

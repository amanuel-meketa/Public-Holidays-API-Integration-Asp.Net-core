using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsumeThirdPartyApisDemo.Models;

namespace ConsumeThirdPartyApisDemo.Services
{
    public class HolidaysApiService : IHolidaysApiService
    {
        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            var result = new List<HolidayModel>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://date.nager.at");
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);

            return result;
        }
    }
}

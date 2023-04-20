using System.Collections.Generic;
using System.Threading.Tasks;
using ConsumeThirdPartyApisDemo.Models;

namespace ConsumeThirdPartyApisDemo.Services
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}

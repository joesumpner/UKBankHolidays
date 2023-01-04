using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using UKBankHolidays.Models;

namespace UKBankHolidays.Services
{
    public class BankHolidaysClient : IBankHolidaysClient
    {
        private readonly HttpClient _httpClient;
        private const string _apiUri = "https://www.gov.uk/bank-holidays.json";

        public BankHolidaysClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BankHolidaysResponse> GetBankHolidaysAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(_apiUri, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new BankHolidaysClientException($"Exception when calling UK Bank Holidays API. Status Code: {response.StatusCode}. Reason: {response.ReasonPhrase}");
            }

            var resp = JsonSerializer.Deserialize<BankHolidaysResponse>(await response.Content.ReadAsStreamAsync(cancellationToken));

            return resp;
        }

        public async Task<BankHolidaysResponse> GetBankHolidaysInYearAsync(int year, CancellationToken cancellationToken = default)
        {
            var bankHolidays = await GetBankHolidaysAsync(cancellationToken);

            return bankHolidays.FilterBankHolidays(x => x.Date.Year == year);
        }

        public async Task<BankHolidaysResponse> GetBankHolidaysFromDateAsync(DateTime date, CancellationToken cancellationToken = default)
        {
            var bankHolidays = await GetBankHolidaysAsync(cancellationToken);

            return bankHolidays.FilterBankHolidays(x => x.Date >= date);
        }
    }
}

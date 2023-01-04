using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UKBankHolidays.Models;

namespace UKBankHolidays.Services
{
    public interface IBankHolidaysClient
    {
        public Task<BankHolidaysResponse> GetBankHolidaysAsync(CancellationToken cancellationToken = default);
        public Task<BankHolidaysResponse> GetBankHolidaysInYearAsync(int year, CancellationToken cancellationToken = default);
        public Task<BankHolidaysResponse> GetBankHolidaysFromDateAsync(DateTime date, CancellationToken cancellationToken = default);
    }
}

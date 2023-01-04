using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKBankHolidays.Models
{
    public class BankHolidaysClientException : Exception
    {
        public BankHolidaysClientException(string message) : base(message)
        {

        }
    }
}

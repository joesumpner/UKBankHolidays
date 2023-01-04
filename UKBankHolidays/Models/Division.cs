using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UKBankHolidays.Models
{
    public class Division
    {
        [JsonPropertyName("division")]
        public string Name { get; set; }

        [JsonPropertyName("events")]
        public IEnumerable<BankHoliday> Events { get; set; }
    }
}

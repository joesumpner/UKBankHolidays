using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UKBankHolidays.Models
{
    public class BankHolidaysResponse
    {
        [JsonPropertyName("england-and-wales")]
        public Division EnglandAndWales { get; set; }

        [JsonPropertyName("scotland")]
        public Division Scotland { get; set; }

        [JsonPropertyName("northern-ireland")]
        public Division NorthernIreland { get; set; }

        /// <summary>
        /// Filters the list of bank holidays for each division by the given predicate, and returns a new <see cref="BankHolidaysResponse"/> object.
        /// </summary>
        /// <param name="filterPredicate"></param>
        /// <returns></returns>
        public BankHolidaysResponse FilterBankHolidays(Func<BankHoliday, bool> filterPredicate)
        {
            return new BankHolidaysResponse()
            {
                EnglandAndWales = new Division()
                {
                    Name = EnglandAndWales.Name,
                    Events = EnglandAndWales.Events.Where(filterPredicate),
                },
                Scotland = new Division()
                {
                    Name = Scotland.Name,
                    Events = Scotland.Events.Where(filterPredicate),
                },
                NorthernIreland = new Division()
                {
                    Name = NorthernIreland.Name,
                    Events = NorthernIreland.Events.Where(filterPredicate),
                },
            };
        }
    }
}

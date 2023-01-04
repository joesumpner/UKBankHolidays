using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKBankHolidays.Models;

namespace UKBankHolidays.Tests
{
    internal static class DummyResponse
    {
        /// <summary>
        /// Returns a dummy valid response from the bank holidays API.
        /// </summary>
        public static BankHolidaysResponse Valid = new()
        {
            EnglandAndWales = new Division()
            { 
                Name = "england-and-wales",
                Events = new List<BankHoliday>()
                {
                    new BankHoliday()
                    {
                        Title = "EW Bank Holiday 1",
                        Date = new DateTime(2020, 1, 1)
                    },
                    new BankHoliday()
                    {
                        Title = "EW Bank Holiday 2",
                        Date = new DateTime(2020, 2, 2)
                    },
                    new BankHoliday()
                    {
                        Title = "EW Bank Holiday 3",
                        Date = new DateTime(2020, 3, 3)
                    },
                    new BankHoliday()
                    {
                        Title = "EW Bank Holiday 4",
                        Date = new DateTime(2021, 10, 10)
                    }
                }
            },

            Scotland = new Division()
            {
                Name = "scotland",
                Events = new List<BankHoliday>()
                {
                    new BankHoliday()
                    {
                        Title = "S Bank Holiday 1",
                        Date = new DateTime(2021, 4, 4)
                    },
                    new BankHoliday()
                    {
                        Title = "S Bank Holiday 2",
                        Date = new DateTime(2021, 5, 5)
                    },
                    new BankHoliday()
                    {
                        Title = "S Bank Holiday 3",
                        Date = new DateTime(2021, 6, 6)
                    }
                }
            },

            NorthernIreland = new Division()
            {
                Name = "northern-ireland",
                Events = new List<BankHoliday>()
                {
                    new BankHoliday()
                    {
                        Title = "NI Bank Holiday 1",
                        Date = new DateTime(2022, 7, 7)
                    },
                    new BankHoliday()
                    {
                        Title = "NI Bank Holiday 2",
                        Date = new DateTime(2022, 8, 8)
                    }
                }
            }
        };

    }
}

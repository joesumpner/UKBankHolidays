using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Protected;
using UKBankHolidays.Services;
using UKBankHolidays.Models;
using System.Text.Json;

namespace UKBankHolidays.Tests
{
    public class BankHolidaysClientTests
    {
        private static Mock<HttpMessageHandler> GetMockedMessageHandler(BankHolidaysResponse testContent)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(testContent))
                });

            return mockMessageHandler;
        }

        [Fact]
        public async Task GetBankHolidaysAsync_ReturnsBankHolidays()
        {
            BankHolidaysResponse testContent = DummyResponse.Valid;

            var mockMessageHandler = GetMockedMessageHandler(testContent);

            var underTest = new BankHolidaysClient(new HttpClient(mockMessageHandler.Object));

            // Act
            var result = await underTest.GetBankHolidaysAsync();

            // Assert
            Assert.NotEmpty(result.EnglandAndWales.Events);
            Assert.NotEmpty(result.Scotland.Events);
            Assert.NotEmpty(result.NorthernIreland.Events);
        }

        [Fact]
        public async Task GetBankHolidaysInYearAsync_ReturnsBankHolidays_ForEnglandAndWales()
        {
            BankHolidaysResponse testContent = DummyResponse.Valid;
            int testYear = 2020;

            var mockMessageHandler = GetMockedMessageHandler(testContent);

            var underTest = new BankHolidaysClient(new HttpClient(mockMessageHandler.Object));

            // Act
            var result = await underTest.GetBankHolidaysInYearAsync(testYear);

            // Assert
            var eventsInYear = testContent.EnglandAndWales.Events.Where(x => x.Date.Year == testYear).ToList();
            Assert.NotEmpty(eventsInYear);

            Assert.NotEmpty(result.EnglandAndWales.Events);

            Assert.All(result.EnglandAndWales.Events, x => Assert.Equal(testYear, x.Date.Year));
        }

        [Fact]
        public async Task GetBankHolidaysFromDateAsync_ReturnsBankHolidays_ForEnglandAndWales()
        {
            BankHolidaysResponse testContent = DummyResponse.Valid;
            DateTime testDate = new(2020, 3, 3);

            var mockMessageHandler = GetMockedMessageHandler(testContent);

            var underTest = new BankHolidaysClient(new HttpClient(mockMessageHandler.Object));

            // Act
            var result = await underTest.GetBankHolidaysFromDateAsync(testDate);

            // Assert
            var eventsFromDate = testContent.EnglandAndWales.Events.Where(x => x.Date >= testDate).ToList();
            Assert.NotEmpty(eventsFromDate);

            Assert.NotEmpty(result.EnglandAndWales.Events);

            Assert.All(result.EnglandAndWales.Events, x => Assert.True(x.Date >= testDate));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class ExchangeApiController : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeNestedViewModel> bookingExchangeNestedViewModels = new List<BookingExchangeNestedViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=tr&currency=USD"),
                Headers =
    {
        { "X-RapidAPI-Key", "8f12fb9e51mshd11557ba6519623p1b0f16jsnc4ef2df0bbcf" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingExchangeNestedViewModel>(body);
                return View(values.exchange_rates);
            }
        }
    }
}

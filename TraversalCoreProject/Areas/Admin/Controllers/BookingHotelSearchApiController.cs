using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?dest_type=city&room_number=1&units=metric&checkout_date=2023-09-28&locale=en-gb&dest_id=-1746443&filter_by_currency=AED&checkin_date=2023-09-27&adults_number=2&order_by=popularity&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&page_number=0&children_number=2&include_adjacency=true"),
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
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
                return View(values.result);
            }
        }
        [HttpGet]

        public async Task<IActionResult> GetCityDestinationId()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCityDestinationId(string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=tr&name={city}"),
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
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
                return View(values.result);
            }
        }
    }
}

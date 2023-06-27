using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class MovieApiController : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            List<MovieApiViewModel> movieapis = new List<MovieApiViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "8f12fb9e51mshd11557ba6519623p1b0f16jsnc4ef2df0bbcf" },
        { "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                movieapis = JsonConvert.DeserializeObject<List<MovieApiViewModel>>(body);
                return View(movieapis);
            }
        }
    }
}

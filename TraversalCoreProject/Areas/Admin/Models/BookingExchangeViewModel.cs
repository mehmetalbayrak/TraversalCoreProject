using Newtonsoft.Json;

namespace TraversalCoreProject.Areas.Admin.Models
{
    public class BookingExchangeViewModel
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchange_rate_buy")]
        public string ExchangeRateBuy { get; set; }
    }
}

using Newtonsoft.Json;

namespace TraversalCoreProject.Areas.Admin.Models
{
    public class MovieApiViewModel
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }
    }
}

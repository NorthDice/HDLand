using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Models
{
    public class MovieSearchResult
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public List<MovieModel> Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}

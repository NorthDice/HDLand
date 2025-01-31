using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Models
{
    public class ApiClientFactory
    {
        private const string ApiBaseUrl = "https://api.themoviedb.org/3";

        public static RestClient CreateClient(string endpoint)
        {
            var options = new RestClientOptions($"{ApiBaseUrl}{endpoint}");
            return new RestClient(options);
        }
    }
}

using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Models
{
    public class RequestFactory
    {
        private const string BearerToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI5ZjdlYjcxYWNmZTZiODRmYWM1OTZmMTNiODE5ZDQwNiIsIm5iZiI6MTczODIzMzg5MC42NzIsInN1YiI6IjY3OWI1ODIyYjAwZDNiYWQ5MmJkNzg3NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.W4c6yfcHMWuZhnhNDXpsFFWBfXC2k_DdmPnR12q3vGo";

        public static RestRequest CreateRequest()
        {
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {BearerToken}");
            return request;
        }
    }
}

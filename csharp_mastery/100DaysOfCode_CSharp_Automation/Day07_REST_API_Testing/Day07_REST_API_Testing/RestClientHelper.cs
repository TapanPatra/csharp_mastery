using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07_REST_API_Testing
{
    public class RestClientHelper
    {
        public static readonly string baseUrl = "https://restful-booker.herokuapp.com";
        public static RestClient GetClient()
        {
            return new RestClient(baseUrl);
        }
    }
}

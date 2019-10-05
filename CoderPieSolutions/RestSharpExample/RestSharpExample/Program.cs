using RestSharp;
using System;
using System.Configuration;

namespace RestSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {            
            var response = GetDetails();
            Console.WriteLine(response);
            Console.ReadKey();
        }

        private static string GetDetails()
        {
            string apiKey = ConfigurationManager.AppSettings["UpTimeRobotApiKey"];
            var client = new RestClient("https://api.uptimerobot.com/v2/getAccountDetails");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", "api_key="+apiKey+"&format=json", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content.ToString();
        }
    }
}

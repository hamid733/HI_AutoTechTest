﻿using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text.Json;
namespace HI_TechTest_BDD.Support
{
    internal class Common
    {
        public string Call_ApiAsync(string method)
        {
            var options = new RestClientOptions("https://www.purgomalum.com/service/" + method)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 3000
            };


            var client = new RestClient(options);
            var request = new RestRequest()
                .AddQueryParameter("text", "hello");
            request.AddHeader("Accept", "*/*");
            var response = client.Execute(request);

            //Console.WriteLine(response.Content);
            var str_code = JsonSerializer.Serialize(response.StatusCode);
            return str_code;

        }

        internal string check_profanity_result(string word)
        {

            var options = new RestClientOptions("https://www.purgomalum.com/service/containsprofanity")
            {
                ThrowOnAnyError = true,
                MaxTimeout = 3000
            };


            var client = new RestClient(options);
            var request = new RestRequest()
                .AddQueryParameter("text", word);
            request.AddHeader("Accept", "*/*");
            var response = client.Execute(request);

            return response.Content;
        }

        internal object check_api_result(string input, string api)
        {
            var options = new RestClientOptions("https://www.purgomalum.com/service/" + api)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 3000
            };

            var client = new RestClient(options);
            var request = new RestRequest()
                .AddQueryParameter("text", input);
            request.AddHeader("Accept", "*/*");
            var response = client.Execute(request);

            return response.Content;

        }
        internal object get_api_result_only(string input, string api)
        {
            var options = new RestClientOptions("https://www.purgomalum.com/service/" + api)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 3000
            };

            var client = new RestClient(options);
            var request = new RestRequest()
                .AddQueryParameter("text", input);
            request.AddHeader("Accept", "*/*");
            var response = client.Execute(request);
            var json_result = JObject.Parse(response.Content);
            //var str_code = JsonSerializer.Serialize(response.Content);
            var rs = json_result["result"].ToString();
            return rs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace TestRest
{
    public class Api
    {
        static readonly HttpClient client = new HttpClient();
        public static string findByStatus = "pet/findByStatus?status=";
        public static string pet = "pet";
        public static string order = "store/order";

        public static string host = "petstore.swagger.io/v2";

        public static Uri GetUri(string path)
        {
            Uri uri = new Uri($"https://{host}/{path}");
            return uri;
        }

        public static HttpResponseMessage Post(Uri uri, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync(uri, content).Result;

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Failed to POST data: ({result.StatusCode}): {result.Content.ReadAsStringAsync().Result}");

            return result;
        }

        public static HttpResponseMessage Put(Uri uri, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PutAsync(uri, content).Result;

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Failed to PUT data: ({result.StatusCode}): {result.Content.ReadAsStringAsync().Result}");

            return result;
        }

        public static HttpResponseMessage Delete(Uri uri)
        {
            var result = client.DeleteAsync(uri).Result;

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Failed to Delete data: ({result.StatusCode}): {result.Content.ReadAsStringAsync().Result}");

            return result;
        }

        public static HttpResponseMessage Get(Uri uri)
        {
            var result = client.GetAsync(uri).Result;

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Failed to GET data: ({result.StatusCode}): {result.Content.ReadAsStringAsync().Result}");
          
            return result;
        }
    }
}

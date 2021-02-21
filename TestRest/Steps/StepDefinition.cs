using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using TechTalk.SpecFlow;
using System.IO;
using TestRest;
using System.Text.Json;
using System.Net.Http;

namespace TestRest.Steps
{
    [Binding]
    public sealed class StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public StepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"get animals with status ""(.*)""")]
        public void GivenGetAnimalsWithStatus(string status)
        {
              string host = "petstore.swagger.io/v2";
              Uri uri = new Uri($"http://{host}/pet/findByStatus?status={status}");

              WebRequest request = WebRequest.Create(Config.GetUri(status));

              WebResponse response = request.GetResponse();
              // Display the status.
              Console.WriteLine(((HttpWebResponse)response).StatusDescription);

              using (Stream dataStream = response.GetResponseStream())
              {
                  // Open the stream using a StreamReader for easy access.
                  StreamReader reader = new StreamReader(dataStream);
                  // Read the content.
                  string responseFromServer = reader.ReadToEnd();
                  // Display the content.
                  Console.WriteLine(responseFromServer);
              }

              response.Close();
        }

        [Given(@"add pet")]
        public void GivenAddPet()
        {
            string host = "petstore.swagger.io/v2";
            Uri uri = new Uri($"https://{host}/pet");

            string json = JsonSerializer.Serialize(Pets.GetPet());

            json = json.ToLower();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var task = client.PostAsync(uri, content);

            HttpResponseMessage response = task.Result;
            Console.WriteLine(response); 
        }

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

      /*  static async void get()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://petstore.swagger.io/v2/pet/findByStatus?status=available");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using TechTalk.SpecFlow;
using System.IO;

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

            WebRequest request = WebRequest.Create(uri);

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using TechTalk.SpecFlow;
using System.IO;
using TestRest;
using System.Text.Json;

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
            var response = Api.Get(Api.GetUri(Api.findByStatus+status));
        }

        public string Data;

        [Given(@"add pet")]
        public void GivenAddPet()
        {
            Data = JsonSerializer.Serialize(Pets.GetPet()).ToLower();

            var response = Api.Post(Api.GetUri(Api.addPet), Data);
            Console.WriteLine(response); 
        }

        [Given(@"check adding pet")]
        public void GivenCheckAddingPet()
        {
            var response = Api.Get(Api.GetUri(Api.getPet+Pets.pet.Id));

            response.Content.ReadAsStringAsync().Result.Equals(Data);
        }

    }
}

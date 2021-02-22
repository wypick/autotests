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
        public string Data;
        public HttpResponseMessage response;
        public string addedPet;

        [Given(@"add pet with status ""(.*)""")]
        public void GivenAddPetWithStatus(string status)
        {
            Data = JsonSerializer.Serialize(Pets.GetPet(status)).ToLower();

            response = Api.Post(Api.GetUri(Api.addPet), Data);
            addedPet = response.Content.ReadAsStringAsync().Result;
        }

        [Given(@"get animals with status ""(.*)""")]
        public void GivenGetAnimalsWithStatus(string status)
        {
            response = Api.Get(Api.GetUri(Api.findByStatus+status));
        }

        [Given(@"check contain pet")]
        public void GivenCheckContainPet()
        {
            if (!response.Content.ReadAsStringAsync().Result.Contains(addedPet))
            {
                throw new Exception($"Добавленного животного: {Pets.pet.Id} не найдено в {response.Content.ReadAsStringAsync().Result}");
            }
        }

        [Given(@"add pet")]
        public void GivenAddPet()
        {
            Data = JsonSerializer.Serialize(Pets.GetPet()).ToLower();

            response = Api.Post(Api.GetUri(Api.addPet), Data);
            addedPet = response.Content.ReadAsStringAsync().Result;
            Console.Write(addedPet);
        }

        [Given(@"check pet")]
        public void GivenCheckPet()
        {
            response = Api.Get(Api.GetUri(Api.getPet+Pets.pet.Id));

            if (!response.Content.ReadAsStringAsync().Result.Equals(addedPet))
            {
                throw new Exception($"Животное: id {Pets.pet.Id} не равно {response.Content.ReadAsStringAsync().Result}");
            }
        }

        [Given(@"check deleted pet")]
        public void GivenCheckDeletedPet()
        {
             try
             {
                 response = Api.Get(Api.GetUri(Api.getPet + Pets.pet.Id));
             }
             catch (Exception) { }
             finally
             {
                 throw new Exception($"Животное: id {Pets.pet.Id} не удалено");
             }
        }

        [Given(@"update pet")]
        public void GivenUpdatePet()
        {
            Data = JsonSerializer.Serialize(Pets.UpdatePet()).ToLower();
            response = Api.Put(Api.GetUri(Api.addPet), Data);
            addedPet = response.Content.ReadAsStringAsync().Result;
            Console.Write(addedPet);
        }

        [Given(@"delete pet")]
        public void GivenDeletePet()
        {
            response = Api.Delete(Api.GetUri(Api.getPet+Pets.pet.Id));
        }
    }
}

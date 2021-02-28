using System;
using TechTalk.SpecFlow;
using System.Text.Json;
using OpenQA.Selenium;
//using Allure.Commons;

namespace TestRest.Steps
{
    [Binding]
    public sealed class StepDefinition
    {
        public string Data;

        [Given(@"add pet with status ""(.*)""")]
        public void GivenAddPetWithStatus(string status)
        {
            Context.Pet = new Pet(status);

            Context.Response = Api.Post(Api.GetUri(Api.pet), JsonSerializer.Serialize(Context.Pet).ToLower());
            Context.AddedPet = Context.Response.Content.ReadAsStringAsync().Result;
        }

        [Given(@"get animals with status ""(.*)""")]
        public void GivenGetAnimalsWithStatus(string status)
        {
            Context.Response = Api.Get(Api.GetUri(Api.findByStatus+status));
        }

        [Given(@"check contain pet")]
        public void GivenCheckContainPet()
        {
            if (!Context.Response.Content.ReadAsStringAsync().Result.Contains(Context.AddedPet))
            {
                throw new Exception($"Добавленного животного: {Context.Pet.Id} не найдено в {Context.Response.Content.ReadAsStringAsync().Result}");
            }
        }

        [Given(@"add pet")]
        public void GivenAddPet()
        {
            Context.Pet = new Pet();

            Context.Response = Api.Post(Api.GetUri(Api.pet), JsonSerializer.Serialize(Context.Pet).ToLower());
            Context.AddedPet = Context.Response.Content.ReadAsStringAsync().Result;
        }

        [Given(@"check pet")]
        public void GivenCheckPet()
        {
            Context.Response = Api.Get(Api.GetUri(Api.pet + '/' + Context.Pet.Id));

            if (!Context.Response.Content.ReadAsStringAsync().Result.Equals(Context.AddedPet))
            {
                throw new Exception($"Животное: id {Context.Pet.Id} не равно {Context.Response.Content.ReadAsStringAsync().Result}");
            }
        }

        [Given(@"check deleted pet")]
        public void GivenCheckDeletedPet()
        {
            try
            {
                Context.Response = Api.Get(Api.GetUri(Api.pet + '/' + Context.Pet.Id));
                throw new Exception("error");
            }
            catch (Exception e)
            {
                if (e.Message == "error")
                {
                    throw new Exception($"Животное: id {Context.Order.id} не удалено");
                }
            }
        }

        [Given(@"update pet")]
        public void GivenUpdatePet()
        {
            Pet.UpdatePet();
            Context.Response = Api.Put(Api.GetUri(Api.pet), JsonSerializer.Serialize(Context.Pet).ToLower());
            Context.AddedPet = Context.Response.Content.ReadAsStringAsync().Result;
        }

        [Given(@"delete pet")]
        public void GivenDeletePet()
        {
            Context.Response = Api.Delete(Api.GetUri(Api.pet + '/' + Context.Pet.Id));
        }

        [Given(@"create order")]
        public void GivenCreateOrder()
        {
            Context.Order = new Order();
            Context.Response = Api.Post(Api.GetUri(Api.order), JsonSerializer.Serialize(Context.Order));
            Context.AddedOrder = Context.Response.Content.ReadAsStringAsync().Result;
        }

        [Given(@"check order")]
        public void GivenCheckOrder()
        {
            Context.Response = Api.Get(Api.GetUri(Api.order + '/' + Context.Order.id));

            if (!Context.Response.Content.ReadAsStringAsync().Result.Equals(Context.AddedOrder))
            {
                throw new Exception($"Заказ: id {Context.Order.id} не равен {Context.Response.Content.ReadAsStringAsync().Result}");
            }
        }

        [Given(@"delete order")]
        public void GivenDeleteOrder()
        {
            Context.Response = Api.Delete(Api.GetUri(Api.order + '/' + Context.Order.id));
        }

        [Given(@"check deleted order")]
        public void GivenCheckDeletedOrder()
        {
            try
            {
                Context.Response = Api.Get(Api.GetUri(Api.order + '/' + Context.Order.id));
                throw new Exception("error");
            }
            catch (Exception e) {
               if (e.Message == "error")
                {
                    throw new Exception($"Заказ: id {Context.Order.id} не удален");
                }
            }
        }

        [Given(@"check chrome")]
        public void GivenCheckChrome()
        {
            WebDriver.Driver.Navigate().GoToUrl("https://www.ya.ru/");

            try
            {
                WebDriver.Driver.FindElement(By.XPath("//div//input[@id='text']"));
            }
            catch (NoSuchElementException)
            {
               // AllureLifecycle.Instance.AddAttachment("Error_Screenshot", "image/png", ((ITakesScreenshot)WebDriver.Driver).GetScreenshot().AsByteArray);
                throw new Exception("Элемент не найден");
            }

           WebDriver.Driver.Close();
        }
    }
}

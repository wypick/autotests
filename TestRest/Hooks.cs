using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;
using System.Data.SqlClient;
//using Allure.Commons;

namespace TestRest
{
    [Binding]
    class Hooks
    {
        /// <summary> Текущий WebDriver </summary>
        public static WebDriver WebDriver { get; set; }

        [BeforeTestRun]
        static public void BeforeTestRun()
        {
            KillAllChromeDrivers();
        }

        [BeforeScenario("gui")]
        static public void BeforeScenarioGui()
        {
            WebDriver = new WebDriver(20);
        }

        [BeforeScenario]
        static public void BeforeScenario()
        {
            Context.Init();
        }

        [BeforeStep]
        static public void BeforeStep()
        {

        }

        [AfterStep]
        static public void AfterStep()
        {
           /* DateTime date = DateTime.Now;
            string time = date.ToString("yyyy-MM-dd HH:mm:ss");
            string result = "passed";
            string error = null;
            if (ScenarioContext.Current.TestError != null)
            {
                error = ScenarioContext.Current.TestError.Message;
                result = "failed";
            }

            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=DB; Integrated Security = True; Persist Security Info = False; Pooling = False; MultipleActiveResultSets = False; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = True"))
            {
                connection.Open();
                string sql = $@"INSERT INTO [dbo].[Log] ([TimeLog], [Name], [Step], [Result], [Error]) VALUES ('{time}', '{ScenarioContext.Current.ScenarioInfo.Title}', '{ScenarioContext.Current.StepContext.StepInfo.Text}', '{result}', '{error}')";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }*/
        }

        [AfterScenario("gui")]
        static public void AfterScenarioGui()
        {
            WebDriver.Driver?.Dispose();
            KillAllChromeDrivers();
        }

        public static void KillAllChromeDrivers()
        {
            foreach (Process proc in Process.GetProcessesByName("chromedriver"))
            {
                try
                {
                    proc.Kill();
                }
                catch (Exception) { }
            }
        }
    }
}

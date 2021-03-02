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
            Config.InitializeEnvironment();
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
            if (Config.DbLogEnable)
            {
                DateTime date = DateTime.Now;
                string time = date.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string result = "passed";
                string error = null;
                if (ScenarioContext.Current.TestError != null)
                {
                    error = ScenarioContext.Current.TestError.Message;
                    result = "failed";
                }

                using (SqlConnection connection = new SqlConnection(@"Data Source=wypick.database.windows.net;Initial Catalog=DB;User ID=wypick;Password=cnTgFyJdBx3010;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();
                    string sql = $@"INSERT INTO [dbo].[Log] ([TimeLog], [Name], [Step], [Result], [Error]) VALUES ('{time}', N'{ScenarioContext.Current.ScenarioInfo.Title}', '{ScenarioContext.Current.StepContext.StepInfo.Text}', '{result}', '{error}')";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
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
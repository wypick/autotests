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
using Allure.Commons;

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
           // Config.InitializeEnvironment();
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
            Logger.Blue("Step: " + ScenarioContext.Current.StepContext.StepInfo.Text);
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("gui"))
                Thread.Sleep(500);
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

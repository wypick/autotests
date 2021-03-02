using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestRest
{
    class WebDriver
    {
        public static IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; }

        public WebDriver(int seconds = 0)
        {
            var options = new ChromeOptions
            {
                BinaryLocation = Config.BasePath + @"\Helpers\GoogleChromePortable\GoogleChromePortable.exe"
            };
            options.AddArgument("--start-maximized");
            options.AddArgument("--remote-debugging-port=9222");
            options.AddArgument("--allowed-ips=127.0.0.1");
            options.AddArgument("window-size=1920,1080");

            Driver = new ChromeDriver(Config.BasePath, options);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            Wait = new WebDriverWait(Driver, Config.WebDriverWait);
            Driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            Driver.Manage().Window.Maximize();
        }
    }
}

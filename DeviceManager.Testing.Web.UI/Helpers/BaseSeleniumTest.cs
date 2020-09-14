using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Testing.Web.UI.Helpers
{
    public abstract class BaseSeleniumTest : IDisposable
    {

        public readonly IWebDriver webDriver;
        public readonly IHost testingHost;
        public const string HOST_URL = TestingWebServerHelper.HOST_URL;

        public BaseSeleniumTest()
        {
            webDriver = new ChromeDriver();
            testingHost = TestingWebServerHelper.CreateHostBuilder().Build();

            testingHost.Start();

        }

        public void Dispose()
        {
            this.webDriver.Dispose();
            this.testingHost.Dispose();
        }

        protected void Wait(float secs)
        {
            var secsInMs = Convert.ToInt32(secs * 1000);
            System.Threading.Thread.Sleep(secsInMs);
        }

    }
}

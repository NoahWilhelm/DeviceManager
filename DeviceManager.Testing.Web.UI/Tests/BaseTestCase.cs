using DeviceManager.Testing.Web.UI.Helpers;
using DeviceManager.Web;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Testing.Web.UI
{
    public class BaseTestCase : BaseSeleniumTest
    {

        [Fact]
        public async Task Test_Init_Device_Count()
        {

            this.webDriver.Navigate().GoToUrl(HOST_URL);
            
            this.Wait(5);

            var devicesElements = this.GetCurrentDeviceItems();
            var devicesElementsCount = devicesElements.Count;


            Assert.Equal(1, devicesElementsCount);

            await this.Test_Delete_Existing_Device();
            await this.Test_Upload_Data_File(4);
            await this.Test_Upload_Data_File(8);
            await this.Open_First_Device_Details();
            await this.Go_Back_To_Main_Page();
        }

        
        public async Task Test_Delete_Existing_Device()
        {

            this.Wait(1);

            var devicesElements = this.GetCurrentDeviceItems();
            var firstDeviceElement = devicesElements.FirstOrDefault();
            var deleteButton = firstDeviceElement.FindElement(By.TagName("fa-icon"));
            deleteButton.Click();

            this.Wait(2);

            var newDevicesElements = this.GetCurrentDeviceItems();
            var newDevicesElementsCount = newDevicesElements.Count;


            Assert.Equal(0, newDevicesElementsCount);

        }

        public async Task Test_Upload_Data_File(int expectedDevicesCount)
        {
            
            var currentDirectory = Directory.GetCurrentDirectory();
            var projectDirectory = Path.Combine(currentDirectory, "..", "..", "..");
            var testingDataFile = Path.Combine(projectDirectory, "data.json");
            var testingDataFileCanonicalPath = new Uri(testingDataFile).LocalPath;

            var uploadInput = this.webDriver.FindElement(By.Id("uploadInput"));
            uploadInput.SendKeys(testingDataFileCanonicalPath);

            this.Wait(3);

            var newDeviceItems = GetCurrentDeviceItems();
            var newDeviceItemsCount = newDeviceItems.Count;

            Assert.Equal(expectedDevicesCount, newDeviceItemsCount);

        }

        public async Task Open_First_Device_Details()
        {

            var currentDevices = GetCurrentDeviceItems();
            var firstDevice = currentDevices.FirstOrDefault();

            var firstDeviceTitle = firstDevice.FindElement(By.ClassName("device-item-name"));
            firstDeviceTitle.Click();

            this.Wait(5);

            var hasBackButton = GetBackButton() != null;

            Assert.True(hasBackButton);

        }

        public async Task Go_Back_To_Main_Page()
        {

            var backButton = GetBackButton();
            backButton.Click();
            this.Wait(1);

            var hasUploadButton = this.webDriver.FindElement(By.Id("uploadButton")) != null;

            Assert.True(hasUploadButton);

        }

        private IWebElement GetBackButton() => this.webDriver.FindElement(By.ClassName("btn-grey"));

        private ReadOnlyCollection<IWebElement> GetCurrentDeviceItems()
        {
            return this.webDriver.FindElements(By.ClassName("device-item"));
        }


    }
}


using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Linq;


namespace DssAutomation.Tests
{
    class HHcahpsFileUpload
    {
        ExtentTest test;
        IWebDriver driver = new InternetExplorerDriver(@"C:\Visual Studio 2015\Projects");
        ExtentReports report = new ExtentReports("C:\\Automation\\Reports\\DssSmokeTest.html", true);
        [Test]
        public void FileUpload()

        {
            test = report.StartTest("HHCahps File Upload");
            driver.Url = ConfigurationManager.AppSettings["hhcahpsStg"];
            driver.Manage().Window.Maximize();
            var timeout = 10000000;
            var wait = new WebDriverWait(driver, new TimeSpan(timeout));

            // Login to hhcahps
            var login = new PageObjects.HHCahpsObjects(driver);
            login.LoginHHcahps();

            // Navigate to file upload menu
            var hhcahpsPage = new PageObjects.HHCahpsObjects(driver);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='ctl00_ContentPlaceHolderGlobalNav_RadMenu1']/ul/li[3]/a/span")));
            hhcahpsPage.UploadMenu.Click();
            hhcahpsPage.UploadFile.Click();

            // Select DSS Test Client

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ctl00_PageContent_ddClients")));
            driver.FindElement(By.Id("ctl00_PageContent_ddClients")).FindElement(By.XPath(".//option[contains(text(),'DSS Test')]")).Click();

            // Select Project

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ctl00_PageContent_ddProjects")));
            SelectElement dropdownProject = new SelectElement(driver.FindElement(By.Id("ctl00_PageContent_ddProjects")));
            dropdownProject.SelectByText("HHCAHPS Test Job - IN CONSTANT USE, DO NOT CLOSE");       
            

            // Select Date
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ctl00_PageContent_ddMonthYear")));
            SelectElement dropdownDate = new SelectElement(driver.FindElement(By.Id("ctl00_PageContent_ddMonthYear")));
            dropdownDate.SelectByText("02/2015");

            // Choose Patient file          
            IWebElement element = driver.FindElement(By.Id("ctl00_PageContent_HHCAHPSFile"));
            element.SendKeys("\\\\dssresearch.com\\files\\PHI\\Incoming_Data\\2009_Non_Hedis\\HHCAHPS\\10282\\201502999999.txt");

            // Enter Notes
            driver.FindElement(By.Id("ctl00_PageContent_txtComments")).SendKeys("Automation Test");

            // Upload button
            driver.FindElement(By.Id("ctl00_PageContent_btnSubmit")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='ctl00_PageContent_DivResults']/div/div[1]")));
            string pageData = driver.FindElement(By.XPath(".//*[@id='ctl00_PageContent_DivResults']/div/div[1]")).Text;       
            Assert.IsTrue(pageData.Contains("Emails regarding uploaded patient file(s) will be coming from HHCAHPS Automated"));
            
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            report.EndTest(test);
            report.Flush();
            driver.Close();
        }



    }
}

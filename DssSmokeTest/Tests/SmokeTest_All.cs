
using AutoIt;
using AutoItX3Lib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Configuration;
using RelevantCodes.ExtentReports;
using NUnit.Framework.Interfaces;
using System;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace DssAutomation.Tests
{
    

    public class SmokeTest_All
    {
        
        ExtentTest test;
        IWebDriver driver = new InternetExplorerDriver(@"C:\Visual Studio 2015\Projects");
        AutoItX3 autoIt = new AutoItX3();
        ExtentReports report = new ExtentReports("C:\\Automation\\Reports\\DssSmokeTest.html", true);

        [Test]
        public void OmniStgLogin()
        {
            Utilities utility = new Utilities();
            test = report.StartTest("Omni Stage Login");

            driver.Url = ConfigurationManager.AppSettings["OmniStg"];
            driver.Manage().Window.Maximize();

            // Login to Omni
            var login = new PageObjects.OmniObjects(driver);
            login.loginOmni();           

            if (AutoItX.WinWaitActive("[CLASS:SunAwtDialog]", "", 10) == 1)
            {
                //Click Run on Java applet
                autoIt.MouseClick("left", 894, 502);
            }
            var pagedata = driver.FindElement(By.Id("ctl00_Content_Main_hlnkOfcStatus")).Text;
            Assert.IsTrue(pagedata.Contains("Office status"), pagedata + " Was not found");
            test.Log(LogStatus.Pass,"Login Succesful");
            Utilities.TakeScreenshot(driver, @"C:\Automation\Screenshots\Results.png");


        }

        [Test]
        public void OmniProdLogin()
        {

            test = report.StartTest("Omni Prod Login");

            driver.Url = ConfigurationManager.AppSettings["OmniProd"];
            driver.Manage().Window.Maximize();

            // Login to Omni
            var login = new PageObjects.OmniObjects(driver);
            login.loginOmni();
           
            if (AutoItX.WinWaitActive("[CLASS:SunAwtDialog]", "", 10) == 1)
            {
                //Click Run on Java applet
                autoIt.MouseClick("left", 894, 502);
            }
            var pagedata = driver.FindElement(By.Id("ctl00_Content_Main_hlnkOfcStatus")).Text;
            Assert.IsTrue(pagedata.Contains("Office status"), pagedata + " Was not found");
            test.Log(LogStatus.Pass, "Login Succesful");

        }

        [Test]      
        public void iCatiStgLogin()
        {
            
            test = report.StartTest("iCati Stage Login");
           
            driver.Url = ConfigurationManager.AppSettings["iCatiStg"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.ICatiLogin(driver);
            login.LoginToIcati();
            var pagevalid = driver.FindElement(By.Id("ctl00_content_main_tblPTOTitle")).Text;

            if (AutoItX.WinWaitActive("[CLASS:SunAwtDialog]", "", 10) == 1)
            {
                //Click Run on Java applet
                autoIt.MouseClick("left", 894, 502);
            }
            Assert.IsTrue(pagevalid.Contains("PTO - Week at a glance"), pagevalid + " Was not found");
            test.Log(LogStatus.Pass, "iCati Login successful");
                   
        }

        [Test]
        public void iCatiProdLogin()
        {

            test = report.StartTest("iCati Prod Login");

            driver.Url = ConfigurationManager.AppSettings["iCatiProd"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.ICatiLogin(driver);
            login.LoginToIcati();
            
            if (AutoItX.WinWaitActive("[CLASS:SunAwtDialog]", "", 10) == 1)
            {
                //Click Run on Java applet
                autoIt.MouseClick("left", 894, 502);
            }
            var pagevalid = driver.FindElement(By.Id("ctl00_content_main_tblPTOTitle")).Text;
            Assert.IsTrue(pagevalid.Contains("PTO - Week at a glance"), pagevalid + " Was not found");
            test.Log(LogStatus.Pass, "iCati Login successful");

        }

        [Test]
        public void SapphireStgLogin()
        {
            test = report.StartTest("Sapphire Stage Login");
            driver.Url = ConfigurationManager.AppSettings["SapphireStg"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.SapphireObjects(driver);
            login.LoginSapphire();

            // page data to validate
            var pagedata = driver.FindElement(By.Id("ctl00_LoginStatus1")).Text;
            Assert.AreEqual("Sign Out", pagedata);
            var user = driver.FindElement(By.Id("ctl00_LoginName1")).Text;
            test.Log(LogStatus.Pass, "Successfully signed in as "  + user);
        }

        [Test]
        public void SapphireProdLogin()
        {
            test = report.StartTest("Sapphire Prod Login");
            driver.Url = ConfigurationManager.AppSettings["SapphireStg"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.SapphireObjects(driver);
            login.LoginSapphire();

            // page data to validate
            var pagedata = driver.FindElement(By.Id("ctl00_LoginStatus1")).Text;
            Assert.AreEqual("Sign Out", pagedata);
            var user = driver.FindElement(By.Id("ctl00_LoginName1")).Text;
            test.Log(LogStatus.Pass, "Successfully signed in as " + user);
        }

        [Test]
        public void hhcahpsStgLogin()
        {
            test = report.StartTest("HHCahps Stg Login");
            driver.Url = ConfigurationManager.AppSettings["hhcahpsStg"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.HHCahpsObjects(driver);
            login.LoginHHcahps();

            // Assertions
            var pagedata = driver.FindElement(By.Id("ctl00_btnLogOff")).Text;
            var user = driver.FindElement(By.Id("ctl00_LabelUsername")).Text;
            Assert.AreEqual("Log Off", pagedata);
            test.Log(LogStatus.Pass, "Successfully signed in as " + user);
        }

        [Test]
        public void hhcahpsProdLogin()
        {
            test = report.StartTest("HHCahps Stg Login");
            driver.Url = ConfigurationManager.AppSettings["hhcahpsProd"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.HHCahpsObjects(driver);
            login.LoginHHcahps();

            // Assertions
            var pagedata = driver.FindElement(By.Id("ctl00_btnLogOff")).Text;
            var user = driver.FindElement(By.Id("ctl00_LabelUsername")).Text;
            Assert.AreEqual("Log Off", pagedata);
            test.Log(LogStatus.Pass, "Successfully signed in as " + user);
        }
  
        [Test]
        public void OLRstgLogin()
        {
            test = report.StartTest("OLR Stage Login");
            driver.Url = ConfigurationManager.AppSettings["OLRstg"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.OLRobjects(driver);
            login.LoginOLR();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var pageData = driver.FindElement(By.ClassName("secTitle")).Text;
            var user = driver.FindElement(By.Id("ctl00_MainContent_UserInfo")).Text;
            Assert.AreEqual("Login Success!", pageData);
            test.Log(LogStatus.Pass, "Successfully signed in as " + user);
        }

        [Test]
        public void OLRProdLogin()
        {
            test = report.StartTest("OLR Prod Login");
            driver.Url = ConfigurationManager.AppSettings["OLRprod"];
            driver.Manage().Window.Maximize();

            var login = new PageObjects.OLRobjects(driver);
            login.LoginOLR();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var pageData = driver.FindElement(By.ClassName("secTitle")).Text;
            var user = driver.FindElement(By.Id("ctl00_MainContent_UserInfo")).Text;
            Assert.AreEqual("Login Success!", pageData);
            test.Log(LogStatus.Pass, "Successfully signed in as " + user);
        }

        [Test]
        public void DssLive()
        {
            test = report.StartTest("DssLive Login");
            driver.Url = ConfigurationManager.AppSettings["DssLive"];

            var login = new PageObjects.DssLiveObjects(driver);
            login.LoginDssLive();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var pageData = driver.FindElement(By.Name("btnNext")).Text;
            Assert.AreEqual("Begin Survey", pageData);

            test.Log(LogStatus.Pass, "DssLive Survey Is Online");
        }



        [TearDown]
        public void GetResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                ? ""
                : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
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

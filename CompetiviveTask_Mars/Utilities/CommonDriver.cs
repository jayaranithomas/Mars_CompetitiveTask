using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CompetiviveTask_Mars.DataModel;
using CompetiviveTask_Mars.Pages;

namespace CompetiviveTask_Mars.Utilities
{

    [SetUpFixture]
    public class CommonDriver
    {
        public static IWebDriver driver;
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        protected void Setup()
        {
            var path = Assembly.GetCallingAssembly().Location;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + @"Reports\ExtentReport.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "Jaya");
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            extent.Flush();

        }

        [SetUp]
        public void BeforeTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public void Initialize()
        {
            //Opening the Chrome driver
            driver = new ChromeDriver();

            //Maximizing the Window
            driver.Manage().Window.Maximize();
        }
        public void Close()
        {
            driver.Quit();
        }

        [TearDown]

        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            string stacktrace;

            if (string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace))
            {
                stacktrace = "";
            }
            else
            {
                stacktrace = string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            }
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(driver, fileName);
                    test.Log(Status.Fail, "Fail");                   
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(@"Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    time = DateTime.Now;
                    fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    screenShotPath = Capture(driver, fileName);
                    test.Log(Status.Pass, "Pass");                    
                    test.Log(Status.Pass, "Snapshot below: " + test.AddScreenCaptureFromPath(@"Screenshots\\" + fileName));

                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.Flush();
            Close();

        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;

            Screenshot screenshot = ts.GetScreenshot();
            var pth = Assembly.GetCallingAssembly().Location;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + @"Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + @"Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath);
            return reportPath;

        }
    }


}

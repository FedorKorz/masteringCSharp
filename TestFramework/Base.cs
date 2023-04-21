using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace TestFramework
{
    public class Base
    {
        String browserName;
        ExtentReports extent;
        ExtentTest test;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory; //path of the class
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
        }

        [SetUp]
        public void StartBrowser() 
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            string workingDirectory = Environment.CurrentDirectory;
            TestContext.WriteLine("THIS IS DIRECTORY" + workingDirectory);
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null) 
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName) 
        { 
            switch(browserName.ToUpper()) 
            {
                case "CHROME":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "FIREFOX":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "EDGE":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            }
            driver.Value.Manage().Window.Maximize();
            driver.Value.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }

        [TearDown]
        public void AfterTest() 
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            test.Log(Status.Fail, "test failed with logtrace " + stackTrace);

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == TestStatus.Failed)
            {
                test.Fail("Test Failed", captureScreenShot(driver.Value, fileName));
            }
            else if (status == TestStatus.Passed)
            {

            }
            extent.Flush();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName) 
        {
            ITakesScreenshot takesScreen = (ITakesScreenshot) driver;
            var screenShot = takesScreen.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot).Build();
        }
    }
}

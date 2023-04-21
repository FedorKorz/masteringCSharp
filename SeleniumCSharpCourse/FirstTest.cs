using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpCourse
{
    internal class FirstTest : AbstractComponents
    {

        private IWebDriver driver = Singleton.getDriver();

        [SetUp]
        public void StartBrowser()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }

        [Test]
        public void TestOne()
        {

            IWebElement dropdown = driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Teacher");

            IWebElement radioButton = driver.FindElement(By.CssSelector("input[value='user']"));
            radioButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//button[@id='okayBtn']"))));

        }

        [TearDown] public void TestTwo()
        {
            //chromeDriver.Quit(); 
        }
    }
}

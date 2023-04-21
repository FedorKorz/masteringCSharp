using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.pageObjects
{
    internal class CountryDestinationPage
    {
        private IWebDriver driver;
        public CountryDestinationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement textBoxCountry;

        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement termsCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement purchaseButton;

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement alertSuccess;

        public void selectCountry(String countryName)
        {
            textBoxCountry.SendKeys("ind");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(countryName)));
            driver.FindElement(By.LinkText(countryName)).Click();
        }

        public void clickTermsCheckBox() 
        {
            termsCheckbox.Click();
        }

        public void clickPurchaseButton() 
        {
            purchaseButton.Click();
        }

        public String getSuccesAlertText() 
        {
            return alertSuccess.Text;
        }
    }
}

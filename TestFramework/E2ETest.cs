using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using TestFramework.pageObjects;
using TestFramework.Utilities;

namespace TestFramework
{
    public class E2ETest : Base
    {
        [Test]

        public void EndtoEndFlow()
        {
            
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.validLogin("username", "pass");

            ProductsPage productsPage = new ProductsPage(getDriver());
            productsPage.waitForPageDisplay();
            productsPage.clickCheckoutButton();

            CheckoutPage checkoutPage = new CheckoutPage(getDriver());
            checkoutPage.clickFinalCheckout();

            CountryDestinationPage countryDestination = new CountryDestinationPage(getDriver());
            countryDestination.selectCountry("India");
            countryDestination.clickTermsCheckBox();
            countryDestination.clickPurchaseButton();

            StringAssert.Contains("Success", countryDestination.getSuccesAlertText());
        }

    }
}
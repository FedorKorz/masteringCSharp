using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using TestFramework.pageObjects;
using TestFramework.Utilities;

namespace TestFramework
{
    public class E2ETest : Base
    {
        [Test, TestCaseSource(nameof(AddTestDataConfig)), Category("Smoke")]
        [Parallelizable(ParallelScope.All)]

        public void EndtoEndFlow(String username, String password, String[] expectedProducts)
        {
            
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.validLogin(username, password);

            ProductsPage productsPage = new ProductsPage(getDriver());
            productsPage.waitForPageDisplay();
            productsPage.getNeededItems(expectedProducts);
            productsPage.clickCheckoutButton();

            CheckoutPage checkoutPage = new CheckoutPage(getDriver());

            Assert.That(checkoutPage.getActualProducts(), Is.EqualTo(expectedProducts));
            checkoutPage.clickFinalCheckout();

            CountryDestinationPage countryDestination = new CountryDestinationPage(getDriver());
            countryDestination.selectCountry("India");
            countryDestination.clickTermsCheckBox();
            countryDestination.clickPurchaseButton();

            StringAssert.Contains("Success", countryDestination.getSuccesAlertText());
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig() 
        {
            yield return new TestCaseData(JSONReader.grabData("username"), JSONReader.grabData("password"), JSONReader.grabDataArray("products"));
            yield return new TestCaseData(JSONReader.grabData("username_wrong"), JSONReader.grabData("password_wrong"), JSONReader.grabDataArray("products"));
        }
    }
}
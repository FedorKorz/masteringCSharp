using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestFramework.pageObjects
{
    internal class CheckoutPage
    {
        private String[] actualProducts = new string[2];
        private IWebDriver driver;

        public CheckoutPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement finalCheckoutButton;

        public IList<IWebElement> getCheckoutCards()
        {
            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));
            return checkoutCards;

        }

        public String[] getActualProducts() 
        {
            IList<IWebElement> checkoutCards = getCheckoutCards();
            for (int i = 0; i < getCheckoutCards().Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            return actualProducts;
        }

        public void clickFinalCheckout() 
        {
            finalCheckoutButton.Click();
        }
    }
}

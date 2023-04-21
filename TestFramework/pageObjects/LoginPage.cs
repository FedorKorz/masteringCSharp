using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestFramework.pageObjects
{
    internal class LoginPage
    {

        private IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "login-row")]
        private IWebElement termsCheckbox;

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signInButton;

        public IWebElement getUsername()
        {
            return username;
        }

        public IWebElement getPassword()
        {
            return password;
        }

        public IWebElement getTermsCheckbox() 
        {
            return termsCheckbox;
        }

        public IWebElement getSignInButton() 
        {
            return signInButton;
        }

        public void validLogin(String login, String password) 
        {
            getUsername().SendKeys(login);
            getPassword().SendKeys(password);
            getTermsCheckbox().Click();
            getSignInButton().Click();
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpCourse
{


    internal class AbstractComponents
    {
        private IWebDriver driver; 

        public AbstractComponents() 
        {
            driver = Singleton.getDriver();
        }

        public void waitElementToAppear(By elem)
        {

        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpCourse
{
    public static class Singleton
    {
        public static IWebDriver driver = null;
        public static WebDriver getDriver()
        {

            if (driver == null)
            {
                return new ChromeDriver();
            } else
            {
                return null;
            }
            
        }
    }
}

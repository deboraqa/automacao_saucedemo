using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace automacao_saucedemo.Bases
{
    public static class WebDriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}

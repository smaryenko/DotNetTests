using Tests.Framework.Helpers.Configuration;

namespace Tests.UI.PageObjects
{
    public class BasePage
    {
        public static IWebDriver Driver;
        public static WebDriverWait waitDriver;
        public string PageUrl = ConfigurationProvider.TestsConfiguration["BaseUrl"];
        public string DefaultTimeout = ConfigurationProvider.TestsConfiguration["DefaultTimeout"];

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            waitDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(DefaultTimeout)));
        }

        public void LoadPage()
        {
            Driver.Url = PageUrl;
            waitDriver.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}

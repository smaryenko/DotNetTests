using OpenQA.Selenium.Chrome;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Tests.UI.StepDefinitions
{
    [Binding]
    public class TestBase
    {
        public static IWebDriver driver;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        }

        [AfterFeature]
        public static void AfterFeature()
        {
            driver.Close();
            driver.Quit();
        }

        [AfterScenario]
        public void AfterWebTest()
        {
            //if (ScenarioContext.Current.TestError != null)
            //{
            //    ScreenshotHelper.TakeScreenshot(driver);
            //}
        }
    }
}

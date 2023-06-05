using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Tests.UI
{
    [Binding]
    class Hook : Steps
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public static string dir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TestResults\\");

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(dir);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
        [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var stepText = ScenarioStepContext.Current.StepInfo.Text;

            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepText);
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepText);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepText);
                else if (stepType == "And")
                    scenario.CreateNode<And>(stepText);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepText).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepText).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepText).Fail(ScenarioContext.Current.TestError.Message);
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepText).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepText).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepText).Skip("Step Definition Pending");

            }
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void Initialize()
        {
            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
    }
}
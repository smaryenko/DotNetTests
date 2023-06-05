
using Tests.UI.PageObjects;

namespace Tests.UI.StepDefinitions
{
    [Binding]
    public class LoginSteps : TestBase
    {
        private LoginPage LoginPage;

        [Given(@"Login page is loaded")]
        public void GivenLoginPageIsLoaded()
        {
            LoginPage = new LoginPage(driver);
            LoginPage.LoadPage();
        }

        [When(@"(.*) and (.*) are entered and login button pressed")]
        public void WhenValidAndAreEnteredAndLoginButtonPressed(string email, string password)
        {
            LoginPage.Login(email, password);
        }

        [Then(@"User sees error message (.*)")]
        public void ThenUserSeesErrorMessage(string error)
        {
            LoginPage.WaitForError(error);
        }
    }
}

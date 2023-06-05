namespace Tests.UI.PageObjects
{
    public class LoginPage : BasePage
    {
        public By InputEmail => By.Id("user-name");
        public By InputPassword => By.Id("password");
        public By ButtonLogin => By.Id("login-button");
        public By MessageContainer => By.ClassName("error-message-container");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string email, string password)
        {
           
            waitDriver.Until(ElementIsVisible(InputEmail));
            Driver.FindElement(InputEmail).SendKeys(email);

            waitDriver.Until(ElementIsVisible(InputPassword));
            Driver.FindElement(InputPassword).SendKeys(password);

            waitDriver.Until(ElementToBeClickable(ButtonLogin)).Click();
        }

        public void WaitForError(string error)
        {
            var element = Driver.FindElement(MessageContainer);
            waitDriver.Until(TextToBePresentInElement(element, error));
        }
    }
}

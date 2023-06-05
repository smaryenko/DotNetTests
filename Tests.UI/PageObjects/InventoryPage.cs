namespace Tests.UI.PageObjects
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver)
        {
            PageUrl += "/inventory.html";
        }
    }
}

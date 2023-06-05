
using Tests.UI.PageObjects;

namespace Tests.UI.StepDefinitions
{
    [Binding]
    public class InventorySteps : TestBase
    {
        private InventoryPage InventoryPage;

        [Then(@"Inventory page is loaded")]
        public void GivenInventoryPageIsLoaded()
        {
            InventoryPage = new InventoryPage(driver);
            InventoryPage.LoadPage();
        }
    }
}

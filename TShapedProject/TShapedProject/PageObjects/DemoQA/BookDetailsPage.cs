using OpenQA.Selenium;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.DemoQA
{
    public class BookDetailsPage : BasePage
    {
        private By addToCollectionButton = By.XPath("//button[text()='Add To Your Collection']");

        public BookDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddBookToUserCollection()
        {
            WaitForElementClickable(addToCollectionButton);
            ClickToElement(addToCollectionButton);
        }

        public void AcceptAlert()
        {
            WaitForAlertPresent();
            driver.SwitchTo().Alert().Accept();
        }
    }
}

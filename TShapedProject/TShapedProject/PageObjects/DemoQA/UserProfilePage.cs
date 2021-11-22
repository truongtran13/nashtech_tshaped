using OpenQA.Selenium;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.DemoQA
{
    public class UserProfilePage : BasePage
    {
        private By loginLink = By.LinkText("login");
        private By closeAdsArrowButton = By.Id("close-fixedban");

        public UserProfilePage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage GoToLoginPage()
        {
            WaitForElementClickable(loginLink);
            ClickToElement(loginLink);
            return new LoginPage(driver);
        }

        public void CloseAdsPopup()
        {
            ClickToElement(closeAdsArrowButton);
        }

        public bool BookExistsInProfileCollection(string title)
        {
            try
            {
                var bookTitle = By.XPath($"//div[@class='action-buttons']//a[text()='{title}']");
                FindElement(bookTitle);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void DeleteBook(string title)
        {
            WaitForElementClickable(By.XPath($"//span[@id='see-book-{title}']//..//..//..//span[@title='Delete']"));

            var deleteButton = FindElement(By.XPath($"//span[@id='see-book-{title}']//..//..//..//span[@title='Delete']"));
            deleteButton.Click();

            var deleteModal = FindElement(By.Id("closeSmallModal-ok"));
            deleteModal.Click();

            WaitForAlertPresent();
            driver.SwitchTo().Alert().Accept();
        }
    }
}

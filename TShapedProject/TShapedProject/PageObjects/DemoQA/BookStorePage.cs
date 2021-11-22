using OpenQA.Selenium;
using System;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.DemoQA
{
    public class BookStorePage : BasePage
    {
        private By loginButton = By.Id("login");
        private By usernameLabel = By.Id("userName-value");
        private By closeAdsArrowButton = By.Id("close-fixedban");
        private By searchBox = By.Id("searchBox");

        public BookStorePage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage GoToLoginPage()
        {
            ClickToElement(loginButton);
            return new LoginPage(driver);
        }

        public string GetUsernameLabelValue()
        {
            WaitForElementVisible(usernameLabel);
            return GetElementText(usernameLabel);
        }

        public void CloseAdsPopup()
        {
            ClickToElement(closeAdsArrowButton);
        }

        public BookDetailsPage SelectBook(string title)
        {
            var bookTitle = By.XPath($"//div[@class='action-buttons']//a[text()='{title}']");
            WaitForElementClickable(bookTitle);
            ClickToElement(bookTitle);
            return new BookDetailsPage(driver);
        }

        public bool BookExistsInStore(string title)
        {
            try
            {
                var bookTitle = By.XPath($"//div[@class='action-buttons']//a[text()='{title}']");
                WaitForElementExists(bookTitle);
                FindElement(bookTitle);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void SearchBooks(string title)
        {
            WaitForElementExists(searchBox);
            SendKeyToElement(searchBox, title);
        }
    }
}

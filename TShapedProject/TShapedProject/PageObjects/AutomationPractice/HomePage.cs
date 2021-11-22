using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.AutomationPractice
{
    public class HomePage : BasePage
    {
        private By signInLinkText = By.LinkText("Sign in");
        private By womenMenu = By.XPath("//ul[contains(@class,'menu-content')]//a[text()='Women']");
        
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public SignInPage SignIn()
        {
            ClickToElement(signInLinkText);
            return new SignInPage(driver);
        }

        public ProductListPage GoToSubMenu(string subMenu)
        {
            var women = FindElement(womenMenu);
            Actions actions = new Actions(driver);
            actions.MoveToElement(women).Perform();

            WaitForElementVisible(By.LinkText(subMenu));
            var sub = FindElement(By.LinkText(subMenu));
            sub.Click();
            return new ProductListPage(driver);
        }
    }
}

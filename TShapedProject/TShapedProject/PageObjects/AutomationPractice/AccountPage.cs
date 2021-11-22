using OpenQA.Selenium;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.AutomationPractice
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        public bool UserLoginSuccess(string name)
        {
            try
            {
                FindElement(By.XPath($"//div[@class='header_user_info']//span[text()='{name}']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

using OpenQA.Selenium;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.AutomationPractice
{
    public class SignInPage : BasePage
    {
        private By emailCreate = By.Id("email_create");
        private By submitCreateButton = By.Id("SubmitCreate");
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        public CreateAccountPage EmailRegister(string email)
        {
            SendKeyToElement(emailCreate, email);
            ClickToElement(submitCreateButton);
            return new CreateAccountPage(driver);
        }
    }
}

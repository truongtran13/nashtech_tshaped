using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TShapedProject.Common;
using TShapedProject.PageObjects.AutomationPractice;

namespace TShapedProject.TestCases
{
    public class AutomationPracticeTests : WebDriverManagers
    {
        IWebDriver _driver;
        CreateAccountPage _createAccountPage;
        SignInPage _signInPage;
        HomePage _homePage;
        AccountPage _accountPage;
        ProductListPage _productListPage;

        [SetUp]
        public void Setup()
        {
            _driver = CreateBrowserDriver("chrome");
            _driver.Navigate().GoToUrl(Constant.AutomationPractice.APP_URL);
            _homePage = new HomePage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void RegisterNewAccount()
        {
            _signInPage = _homePage.SignIn();

            _createAccountPage = _signInPage.EmailRegister(Constant.AutomationPractice.EMAIL);

            var accountInfo = new AccountInformation
            {
                MaleGender = true,
                CustomerFirstName = Constant.AutomationPractice.FIRSTNAME,
                CustomerLastName = Constant.AutomationPractice.LASTNAME,
                Password = Constant.AutomationPractice.PASSWORD,
                AddressFirstName = Constant.AutomationPractice.FIRSTNAME,
                AddressLastName = Constant.AutomationPractice.LASTNAME,
                Address = Constant.AutomationPractice.ADDRESS,
                City = Constant.AutomationPractice.CITY,
                State = Constant.AutomationPractice.STATE,
                PostCode = Constant.AutomationPractice.POST_CODE,
                MobilePhone = Constant.AutomationPractice.MOBILE_PHONE,
                Alias = Constant.AutomationPractice.Alias
            };

            _createAccountPage.EnterAccountInformation(accountInfo);
            _accountPage = _createAccountPage.CreateAccount();

            var userLogin = _accountPage.UserLoginSuccess(Constant.AutomationPractice.FIRSTNAME + " " + Constant.AutomationPractice.LASTNAME);
            Assert.IsTrue(userLogin);
        }

        [Test]
        public void SearchProduct()
        {
            _productListPage = _homePage.GoToSubMenu(Constant.AutomationPractice.SUB_MENU_TSHIRTS);

            var productName = _productListPage.GetFirstProductName();

            _productListPage.SearchProduct(productName);

            var productInSearchResult = _productListPage.GetProductName(productName);

            Assert.NotNull(productInSearchResult);
        }
    }
}

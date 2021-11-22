using NUnit.Framework;
using OpenQA.Selenium;
using TShapedProject.Common;
using TShapedProject.PageObjects.DemoQA;

namespace TShapedProject.TestCases
{
    public class DemoQATests : WebDriverManagers
    {
        private IWebDriver _driver;
        private BookStorePage _bookStorePage;
        private LoginPage _loginPage;
        private BookDetailsPage _bookDetailsPage;
        private UserProfilePage _userProfilePage;

        [SetUp]
        public void Setup()
        {
            _driver = CreateBrowserDriver("chrome");
        }

        [TearDown]
        public void TearDown()
        {
           _driver.Quit();
        }

        [Test]
        [Order(1)]
        public void AddBookToCollection()
        {
            _driver.Navigate().GoToUrl(Constant.DemoQA.APP_URL);
            _bookStorePage = new BookStorePage(_driver);
            _bookStorePage.CloseAdsPopup();
            _loginPage = _bookStorePage.GoToLoginPage();
            _loginPage.LoginWithValidAccount(Constant.DemoQA.USERNAME, Constant.DemoQA.PASSWORD);

            _bookDetailsPage = _bookStorePage.SelectBook(Constant.DemoQA.GIT_POCKET_GUIDE);
            _bookDetailsPage.AddBookToUserCollection();

            _bookDetailsPage.AcceptAlert();

            _driver.Navigate().GoToUrl(Constant.DemoQA.PROFILE_URL);
            _userProfilePage = new UserProfilePage(_driver);

            var bookExistsInProfileCollection = _userProfilePage.BookExistsInProfileCollection(Constant.DemoQA.GIT_POCKET_GUIDE);

            Assert.IsTrue(bookExistsInProfileCollection);
        }

        [Test]
        [TestCase("design")]
        [TestCase("Design")]
        public void SearchBookWithMultipleResult(string title)
        {
            _driver.Navigate().GoToUrl(Constant.DemoQA.APP_URL);
            _bookStorePage = new BookStorePage(_driver);
            _bookStorePage.CloseAdsPopup();
            _loginPage = _bookStorePage.GoToLoginPage();
            _loginPage.LoginWithValidAccount(Constant.DemoQA.USERNAME, Constant.DemoQA.PASSWORD);

            _bookStorePage.SearchBooks(title);

            var learnJavaExistsInStore = _bookStorePage.BookExistsInStore(Constant.DemoQA.LEARN_JAVASCRIPT);
            var designingsWebApiExistsInStore = _bookStorePage.BookExistsInStore(Constant.DemoQA.DESIGNING_EVOLVABLE);

            Assert.IsTrue(learnJavaExistsInStore);
            Assert.IsTrue(designingsWebApiExistsInStore);
        }

        [Test]
        [Order(2)]
        public void DeleteBookFromProfile()
        {
            _driver.Navigate().GoToUrl(Constant.DemoQA.PROFILE_URL);
            _userProfilePage = new UserProfilePage(_driver);
            _userProfilePage.CloseAdsPopup();

            _loginPage = _userProfilePage.GoToLoginPage();
            _loginPage.LoginWithValidAccount(Constant.DemoQA.USERNAME, Constant.DemoQA.PASSWORD);

            _userProfilePage = new UserProfilePage(_driver);
            _userProfilePage.DeleteBook(Constant.DemoQA.GIT_POCKET_GUIDE);

            var bookExistsInProfileCollection = _userProfilePage.BookExistsInProfileCollection(Constant.DemoQA.GIT_POCKET_GUIDE);

            Assert.IsFalse(bookExistsInProfileCollection);
        }
    }
}
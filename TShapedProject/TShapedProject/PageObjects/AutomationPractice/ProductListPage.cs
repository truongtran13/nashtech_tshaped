using OpenQA.Selenium;
using System.Linq;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.AutomationPractice
{
    public class ProductListPage : BasePage
    {
        private By firstItem = By.XPath("//ul[contains(@class,'product_list')]//li[contains(@class,'first-in-line')]//a[@class='product-name']");
        private By search = By.Id("search_query_top");
        private By submitButton = By.XPath("//button[contains(@class,'button-search')]");
        private By productName = By.ClassName("product-name");
        public ProductListPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetFirstProductName()
        {
            return FindElement(firstItem).Text;
        }

        public void SearchProduct(string productName)
        {
            var searchBar = FindElement(search);
            searchBar.SendKeys(productName);

            var submitSearch = searchBar.FindElement(submitButton);
            submitSearch.Click();
        }

        public string GetProductName(string name)
        {
            return FindElements(productName).FirstOrDefault(a => a.Text == name)?.Text;
        }
    }
}

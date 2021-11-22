using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TShapedProject.Common;

namespace TShapedProject.PageObjects.AutomationPractice
{
    public class CreateAccountPage : BasePage
    {
        private By maleGenderRadio = By.Id("id_gender1");
        private By femaleGenderRadio = By.Id("id_gender2");
        private By customerFirstName = By.Id("customer_firstname");
        private By customerLastName = By.Id("customer_lastname");
        private By password = By.Id("passwd");
        private By addressFirstName = By.Id("firstname");
        private By addressLastName = By.Id("lastname");
        private By address = By.Id("address1");
        private By city = By.Id("city");
        private By state = By.Id("uniform-id_state");
        private By postCode = By.Id("postcode");
        private By mobilePhone = By.Id("phone_mobile");
        private By alias = By.Id("alias");
        private By createAccountButton = By.Id("submitAccount");

        public CreateAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterAccountInformation(AccountInformation accountInformation)
        {
            if (accountInformation.MaleGender)
            {
                WaitForElementExists(maleGenderRadio);
                var gender = FindElement(maleGenderRadio);
                gender.Click();
            }
            else
            {
                WaitForElementExists(femaleGenderRadio);
                var gender = FindElement(femaleGenderRadio);
                gender.Click();
            }

            EnterInformation(customerFirstName, accountInformation.CustomerFirstName);
            EnterInformation(customerLastName, accountInformation.CustomerLastName);
            EnterInformation(password, accountInformation.Password);
            EnterInformation(addressFirstName, accountInformation.AddressFirstName);
            EnterInformation(addressLastName, accountInformation.AddressLastName);
            EnterInformation(address, accountInformation.Address);
            EnterInformation(city, accountInformation.City);
            EnterInformation(postCode, accountInformation.PostCode);
            EnterInformation(mobilePhone, accountInformation.MobilePhone);
            EnterInformation(alias, accountInformation.Alias);


            WaitForElementClickable(state);
            var stateDropdown = FindElement(state);
            stateDropdown.Click();

            var stateOption = By.XPath($"//select[@id='id_state']//option[text()='{accountInformation.State}']");
            WaitForElementClickable(stateOption);
            var stateOptionDropdown = FindElement(stateOption);
            stateOptionDropdown.Click();
        }

        public AccountPage CreateAccount()
        {
            WaitForElementClickable(createAccountButton);
            var createAccount = FindElement(createAccountButton);
            createAccount.Click();
            return new AccountPage(driver);
        }

        private void EnterInformation(By byLocator, string info)
        {
            WaitForElementExists(byLocator);
            var cusFirstName = FindElement(byLocator);
            cusFirstName.Clear();
            cusFirstName.SendKeys(info);
        }
    }

    public class AccountInformation
    {
        public bool MaleGender { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Password { get; set; }
        public string AddressFirstName { get; set; }
        public string AddressLastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string MobilePhone { get; set; }
        public string Alias { get; set; }
    }
}

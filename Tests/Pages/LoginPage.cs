using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Pages {
    public class LoginPage : Page {
        private string homeURL = "https://finviz.com/";
        private By logInBtnLocatorRegist = By.XPath("//a[@href='/login.ashx']");
        private By emailLocator = By.XPath("//input[@name='email']");
        private By passwordLocator = By.XPath("//input[@type='password']");
        private By submitBtnLocator = By.XPath("//input[@type='submit']");
        public LoginPage OpenPage() {
            OnOpen();
            OpenUrl(homeURL);
            return this;
        }

        public LoginPage(IWebDriver driver) : base(driver) {

        }

        public MainPage Login(Account account) {
            FindElementWithWait(logInBtnLocatorRegist).Click();
            IWebElement Email = FindElementWithWait(emailLocator);
            Email.Clear();
            Email.SendKeys(account.getLogin());

            IWebElement Password = FindElementWithWait(passwordLocator);
            Password.Clear();
            Password.SendKeys(account.getPassword());

            FindElementWithWait(submitBtnLocator).Click();

            return new MainPage(driver);
        }
    }
}

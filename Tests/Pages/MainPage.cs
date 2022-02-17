using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages {
    public class MainPage : Page {
        //private By logInBtnLocatorNews = By.XPath("//a[@href='/news.ashx']");
        //private By logInBtnLocatorHelp = By.XPath("//a[@href='/help/screener.ashx']");
        //private By logInBtnLocatorMaps = By.XPath("//a[@href='/map.ashx']");
        //private By logInBtnLocatorGroups = By.XPath("//a[@href='/groups.ashx']");
        //private By logInBtnLocatorFutures = By.XPath("//a[@href='/futures.ashx']");
        private By search = By.XPath("//input[@placeholder ='Search ticker, company or profile']");
        private By resultSearch = By.XPath("//table[@class ='styled-table is-full-width is-condensed is-striped is-hoverable has-full-row-links']");
        private By searchBtn = By.XPath("//span[@class ='fa fa-search']");
        private string valueTosearch = "pop";
        private By informationPasswordFieldLocator = By.XPath("//a[@class='nav-link sign-in account-btn is-account']");
        public MainPage(IWebDriver driver) : base(driver) {}

        public IWebElement Search() {
            IWebElement search = FindElementWithWait(this.search);
            search.Clear();
            search.SendKeys(valueTosearch);
            FindElementWithWait(searchBtn).Click();
            return FindElementWithWait(this.search);
        }
        public bool FindResultSearch() {
            return FindElementWithWait(resultSearch) != null ? true : false;
        }



        public IWebElement FindAccountInfo() {
            return FindElementWithWait(informationPasswordFieldLocator);
        }
    }
}

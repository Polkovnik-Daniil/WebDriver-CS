using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using Tests.Models;
using Tests.Service;
using Tests.Util;

namespace Tests.Steps {
    public class Steps {
        IWebDriver driver;
        ///////////////////////////////////////////////
        public void InitBrowser() {
            driver = Driver.DriverInstance.GetInstance();
        }
        public void CloseBrowser() {
            //TestLog.LogStat(TestContext.CurrentContext);
            Driver.DriverInstance.CloseBrowser();
        }
        ///////////////////////////////////////////////
        public void LoginFinviz() {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            Account User = AccountCreator.CreateAccount();
            loginPage.OpenPage();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            loginPage.Login(User);
        }
        public IWebElement CheckAccount() {
            Pages.MainPage accountPage = new Pages.MainPage(driver);
            return accountPage.FindAccountInfo();
        }
        ///////////////////////////////////////////////
        public IWebElement Search() {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.Search();
        }
        public bool FindResultSearch() {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.FindResultSearch();
        }
        ///////////////////////////////////////////////
        public void Filtr() {
            Pages.Screener screener = new Pages.Screener(driver);
            screener.OpenPage().Filtration();
            return;
        }
        public bool FindFiltrationInfo() {
            Pages.Screener screener = new Pages.Screener(driver);
            bool value = screener.FindFiltrationInfo();
            return value;
        }
        ///////////////////////////////////////////////
        public void CreatePorfolio() {
            Pages.Portfolio portfolio = new Pages.Portfolio(driver);
            portfolio.OpenPage().CreatePortfolio();
        }
        public bool FindPortfolio() {
            Pages.Portfolio portfolio = new Pages.Portfolio(driver);
            return portfolio.FindPortfolio();
        }
        ///////////////////////////////////////////////
        public void DestroyPortfolio() {
            Pages.Portfolio portfolio = new Pages.Portfolio(driver);
            portfolio.OpenPage().DestroyPortfolio();
        }
        public int? FindDestroyPortfolio() {
            Pages.Portfolio portfolio = new Pages.Portfolio(driver);
            int? value = portfolio.FindDestroyPortfolio();
            return value == 0 ? null : value;
        }
        ///////////////////////////////////////////////
        public void SearchScreener() {
            Pages.Screener screener = new Pages.Screener(driver);
            screener.OpenPage().SearchTicker();
            return;
        }
        public IWebElement FindResultSearchScreener() {
            Pages.Screener screener = new Pages.Screener(driver);
            return screener.FindResultSearchScreener();
        }
        ///////////////////////////////////////////////
        public void SetValue() {
            Pages.Screener screener = new Pages.Screener(driver);
            screener.OpenPage().SetValue();
        }
        public void Reset() {
            Pages.Screener screener = new Pages.Screener(driver);
            screener.Reset();
            return;
        }
        public int? FindResetInfo() {
            Pages.Screener screener = new Pages.Screener(driver);
            return screener.FindResetInfo();
        }
        ///////////////////////////////////////////////
        public void SaveScreenParameter() {
            Pages.Screener screener = new Pages.Screener(driver);
            screener.SaveParameter();
        }
        public bool FindInfoTab() {
            Pages.Screener screener = new Pages.Screener(driver);
            return screener.FindInfoTab() == 1;
        }
        ///////////////////////////////////////////////
        public void DeleteScreenParameter() {
            Pages.Screener screener = new Pages.Screener(driver);
            screener.OpenPage().DeleteScreenParameter();
        }
        ///////////////////////////////////////////////
        public void SetParameter() {
            Pages.AccountSetting screener = new Pages.AccountSetting(driver);
            screener.OpenPage().SetParameterAccount();
        }
        public void BackParameter() {
            Pages.AccountSetting screener = new Pages.AccountSetting(driver);
            screener.OpenPage().BackParameterAccount();
        }
        public bool FindInFoAccount() {
            Pages.AccountSetting screener = new Pages.AccountSetting(driver);
            return screener.OpenPage().CheckParameterAccount();
        }
        public bool FindInFoBackAccount() {
            Pages.AccountSetting screener = new Pages.AccountSetting(driver);
            return screener.OpenPage().CheckBackParameterAccount();
        }
    }
}

using OpenQA.Selenium;


namespace Tests.Pages {
    class Portfolio : Page {
        private By logInBtnLocatorScreener = By.XPath("//a[@href='/portfolio.ashx']");
        private By toCheck = By.XPath("//td[@class='body-table-nw']");

        private By portfolio = By.XPath("//option[@value='0']");
        private By ticker = By.XPath("//input[@name='ticker0']");
        private By shares = By.XPath("//input[@name='shares0']");
        private By price = By.XPath("//input[@name='price0']");
        private By portfolioName = By.XPath("//input[@name='portfolio_name']");
        private By portfolioDestroyBtn = By.XPath("//a[@href='javascript:PortfolioDelete()']");
        private By saveChanges = By.XPath("//input[@class='portfolio-edit'][@value='Save Changes']");
        private By logo = By.XPath("//a[@href='/']");
        private string nameTicker = "B";
        private string namePortfolio = "Popo";
        private string nameShares = "8858";
        private string namePrice = "9999";

        public Portfolio(IWebDriver driver) : base(driver) { }
        public Portfolio OpenPage() {
            FindElementWithWait(logo).Click();
            FindElementWithWait(logInBtnLocatorScreener).Click();
            return new Portfolio(driver);
        }
        public void CreatePortfolio() {
            FindElementWithWait(this.portfolio).Click();
            AddValue(namePortfolio, this.portfolioName);
            AddValue(nameTicker, this.ticker);
            AddValue(nameShares, this.shares);
            AddValue(namePrice, this.price);
            FindElementWithWait(saveChanges).Click();
        }
        public void AddValue(string value, By by) {
            IWebElement webelem = FindElementWithWait(by);
            webelem.Clear();
            webelem.SendKeys(value);
        }
        public bool FindPortfolio() {
            IWebElement a = FindElementWithWait(toCheck);
            return a != null;
        }

        public void DestroyPortfolio() {
            FindElementWithWait(portfolioDestroyBtn).Click();
            driver.SwitchTo().Alert().Accept();
        }
        public int? FindDestroyPortfolio() {
            return driver.FindElements(portfolioDestroyBtn).Count;
        }
    }
}

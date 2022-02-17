using OpenQA.Selenium;


namespace Tests.Pages {
    class Screener : Page {
        private By logInBtnLocatorScreener = By.XPath("//a[@href='/screener.ashx']");
        private By logo = By.XPath("//a[@href='/']");
        private By IDExchange = By.XPath("//option[@value='amex']");
        private By IDCount = By.XPath("//td[@class='count-text']");
        private By IDTable = By.XPath("//tr[@class='table-dark-row-cp']");
        private By IDtable = By.XPath($"//*[@id='screener - content']/table/tbody/tr[4]");
        private By IDIndex = By.XPath("//option[@value='sp500']");
        private By searchTicker = By.XPath("//input[@id='tickersInput']");
        private By searchTickerBtn = By.XPath("//input[@value='>']");
        private By IDNyse = By.XPath("//option[@value='nyse']");
        private By IDBasicMaterials = By.XPath("//option[@value='basicmaterials']");
        private By IDAgriculturalInputs = By.XPath("//option[@value='agriculturalinputs']");
        private By CountLight = By.XPath("//tr[@class='table-light-row-cp']");
        private By ResetBtn = By.XPath(@"//input[@value='Reset (4)']");
        private By SaveParameterBtn = By.XPath(@"//option[@value='__save_screen']");
        private By EditParameterBtn = By.XPath(@"//option[@value='__edit_screens']");
        private By RemoveBtnParameter = By.XPath(@"//button[@class='screener-presets-edit']");
        private By SaveTabBtn = By.XPath(@"//input[@value='Save Changes']");
        private By CheckTab = By.XPath(@"//option[@value='v=171&f=exch_nyse,idx_sp500,ind_agriculturalinputs,sec_basicmaterials']");
        
        private string searchTickervalue = "A";
        public Screener(IWebDriver driver) : base(driver) { }
        public Screener OpenPage() {
            FindElementWithWait(logo).Click();
            FindElementWithWait(logInBtnLocatorScreener).Click();
            return new Screener(driver);
        }
        public IWebElement Filtration() {
            FindElementWithWait(IDExchange).Click();
            FindElementWithWait(IDIndex).Click();
            return FindElementWithWait(IDCount);
        }
        public bool FindFiltrationInfo() {
            return FindElementWithWait(IDCount) != null ? true : false;
        }
        public void SearchTicker() {
            IWebElement element = FindElementWithWait(searchTicker);
            element.SendKeys(searchTickervalue);
            FindElementWithWait(searchTickerBtn).Click();
            return;
        }
        public IWebElement FindResultSearchScreener() {
            return FindElementWithWait(IDCount);
        }

        public void SetValue() {
            FindElementWithWait(IDNyse).Click();
            FindElementWithWait(IDIndex).Click();
            FindElementWithWait(IDBasicMaterials).Click();
            FindElementWithWait(IDAgriculturalInputs).Click();
        }
        public void Reset() {
            FindElementWithWait(ResetBtn).Click();
        }
        public int? FindResetInfo() {
            return driver.FindElements(CountLight).Count;
        }
        public void SaveParameter() {
            FindElementWithWait(SaveParameterBtn).Click();
            FindElementWithWait(SaveTabBtn).Click();
        }
        public int? FindInfoTab() {
            return driver.FindElements(CheckTab).Count;
        }
        public void DeleteScreenParameter() {
            FindElementWithWait(EditParameterBtn).Click();
            FindElementWithWait(RemoveBtnParameter).Click();
            FindElementWithWait(SaveTabBtn).Click();
        }
    }
}

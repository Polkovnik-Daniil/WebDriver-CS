using OpenQA.Selenium;


namespace Tests.Pages {
    class AccountSetting : Page {
        private By logInBtnLocatorSetting = By.XPath("//a[@href='/myaccount.ashx']");
        private By ToSubject = By.XPath("//td[@id='account-dropdown']");
        private By Aft = By.XPath("//option[@value='50000'][@selected='selected']");
        private By before = By.XPath("//option[@value='0'][@selected='selected']");

        private By paramFirstBefore= By.XPath("/html/body/table[3]/tbody/tr[1]/td/table/tbody/tr[3]/td/form/table[1]/tbody/tr[3]/td[2]/select/option[1]");
        private By paramSecondBefore = By.XPath("/html/body/table[3]/tbody/tr[1]/td/table/tbody/tr[3]/td/form/table[1]/tbody/tr[4]/td[2]/select/option[1]");

        private By paramFirstAfter = By.XPath("/html/body/table[3]/tbody/tr[1]/td/table/tbody/tr[3]/td/form/table[1]/tbody/tr[3]/td[2]/select/option[2]");
        private By paramSecondAfter = By.XPath("/html/body/table[3]/tbody/tr[1]/td/table/tbody/tr[3]/td/form/table[1]/tbody/tr[4]/td[2]/select/option[2]");
        private By SaveBtn = By.XPath("//input[@value='Save Changes']");
        public AccountSetting(IWebDriver driver) : base(driver) { }
        public AccountSetting OpenPage() {
            FindElementWithWait(ToSubject).Click();
            FindElementWithWait(logInBtnLocatorSetting).Click();
            return new AccountSetting(driver);
        }
        public void SetParameterAccount() {
            FindElementWithWait(paramFirstAfter).Click();
            FindElementWithWait(paramSecondAfter).Click();
            FindElementWithWait(SaveBtn).Click();
        }
        public void BackParameterAccount() {
            FindElementWithWait(paramFirstBefore).Click();
            FindElementWithWait(paramSecondBefore).Click();
            FindElementWithWait(SaveBtn).Click();
        }
        public bool CheckParameterAccount() {
            FindElementWithWait(ToSubject).Click();
            FindElementWithWait(logInBtnLocatorSetting).Click();
            return driver.FindElements(before).Count != 0;  
        }
        public bool CheckBackParameterAccount() {
            FindElementWithWait(ToSubject).Click();
            FindElementWithWait(logInBtnLocatorSetting).Click();
            return driver.FindElements(before).Count != 0;
        }
    }
}

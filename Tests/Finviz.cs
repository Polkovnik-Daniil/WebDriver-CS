using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Pages;
using Tests.Service;
using Tests.Models;

namespace Tests {
    [TestFixture]
    public class Finviz {
        private Steps.Steps steps = new Steps.Steps();
        //1
        [Test]
        public void A_MainPageSearch() {
            steps.Search();
            bool result = steps.FindResultSearch();
            Assert.IsTrue(result);
        }
        //2
        [Test]
        public void B_ScreenerFiltration() {
            steps.Filtr();
            bool result = steps.FindFiltrationInfo();
            Assert.IsTrue(result);
        }
        //3
        [Test]
        public void C_CreatePortfolio() {
            steps.CreatePorfolio();
            bool result = steps.FindPortfolio();
            Assert.IsTrue(result);
        }
        //4
        [Test]
        public void D_DestroyPortfolio() {
            steps.DestroyPortfolio();
            Assert.IsNull(steps.FindDestroyPortfolio());
        }
        //5
        [Test]
        public void E_SearchTicker() {
            steps.SearchScreener();
            Assert.IsNotNull(steps.FindResultSearchScreener());
        }
        //6
        [Test]
        public void F_SetParameterSearch() {
            steps.SetValue();
            Assert.IsNotNull(steps.FindResultSearchScreener());
        }
        //7
        [Test]
        public void G_ResetParameterSearch() {
            steps.SetValue();
            steps.Reset();
            Assert.IsNotNull(steps.FindResultSearchScreener());
        }
        //8
        [Test]
        public void H_SaveScreenParameter() {
            steps.SetValue();
            steps.SaveScreenParameter();
            Assert.IsNotNull(steps.FindInfoTab());
        }
        //9
        [Test]
        public void I_DeleteScreenParameter() {
            steps.DeleteScreenParameter();
            Assert.IsNotNull(steps.FindInfoTab());
        }
        //10    
        [Test]
        public void J_AccountSetting() {
            steps.SetParameter();
            Assert.IsTrue(steps.FindInFoAccount());
        }
        //11 additional
        [Test]
        public void K_BackAccountSetting() {
            steps.BackParameter();
            Assert.IsTrue(steps.FindInFoBackAccount());
        }
        [TearDown]
        public void TearDownTest() {
            steps.CloseBrowser();
        }


        [SetUp]
        public void SetupTest() {
            steps.InitBrowser();
            steps.LoginFinviz();
            steps.CheckAccount();
        }

    }
}

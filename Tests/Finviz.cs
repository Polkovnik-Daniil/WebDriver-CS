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
        public void MainPageSearch() {
            steps.Search();
            Assert.IsTrue(steps.FindResultSearch());
        }
        //2
        [Test]
        public void ScreenerFiltration() {
            steps.Filtr();
            Assert.IsTrue(steps.FindFiltrationInfo());
        }
        //3
        [Test]
        public void CreatePortfolio() {
            steps.CreatePorfolio();
            Assert.IsTrue(steps.FindPortfolio());
            steps.DestroyPortfolio();
        }
        //4
        [Test]
        public void DestroyPortfolio() {
            steps.CreatePorfolio();
            steps.DestroyPortfolio();
            Assert.IsNull(steps.FindDestroyPortfolio());
        }
        //5
        [Test]
        public void SearchTicker() {
            steps.SearchScreener();
            Assert.IsNotNull(steps.FindResultSearchScreener());
        }
        //6
        [Test]
        public void SetParameterSearch() {
            steps.SetValue();
            Assert.IsNotNull(steps.FindResultSearchScreener());
        }
        //7
        [Test]
        public void ResetParameterSearch() {
            steps.SetValue();
            steps.Reset();
            Assert.IsNotNull(steps.FindResultSearchScreener());
        }
        //8
        [Test]
        public void SaveScreenParameter() {
            steps.SetValue();
            steps.SaveScreenParameter();
            Assert.IsNotNull(steps.FindInfoTab());
            DeleteScreenParameter();
        }        
        //9
        [Test]
        public void DeleteScreenParameter() {
            //SaveScreenParameter();
            steps.DeleteScreenParameter();
            Assert.IsNotNull(steps.FindInfoTab());
        }
        //10    
        [Test]
        public void AccountSetting() {
            steps.SetParameter();
            Assert.IsTrue(steps.FindInFoAccount());
            steps.BackParameter();
        }
        //11 additional
        [Test]
        public void BackAccountSetting() {
            steps.SetParameter();
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

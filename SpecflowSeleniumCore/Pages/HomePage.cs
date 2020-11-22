using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;

namespace SpecflowSeleniumCore.Pages
{
    public class HomePage
    {
        private String currentUrl;
        private String firstUrl;
        public IWebDriver webDriver { get; }
        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.firstUrl = this.webDriver.Url;
        }

        public IWebElement TequilaItem => webDriver.FindElement(By.XPath("//*[@id='menu-item-20424']/a"));  //webDriver.FindElement(By.LinkText("TEQUILA"));
        public void ClickTequila()
        {
            System.Threading.Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(120));
            var products = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='menu-item-3830']/a")));
            Actions action = new Actions(webDriver);
            action.MoveToElement(products).Build().Perform();

            System.Threading.Thread.Sleep(2000);

            var tequila = webDriver.FindElement(By.XPath("//*[@id='menu-item-20424']/a"));
            tequila.Click();

            System.Threading.Thread.Sleep(2000);

            currentUrl = webDriver.Url;
        }

        public bool CheckUrlTequila()
        {

            if (firstUrl.Equals(currentUrl)==false && webDriver.PageSource.Contains("Free your mind. For the essentials."))
                return true;

            return false;
        }

        public void ClickSearchButton()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            var searchButtonClicked = webDriver.FindElement(By.XPath("//*[@id='et_search_icon']"));
            Actions action = new Actions(webDriver);
            action.MoveToElement(searchButtonClicked).Click().Build().Perform();

            firstUrl = webDriver.Url;
            IWebElement input = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("s"))); 

            System.Threading.Thread.Sleep(2000);
            input.SendKeys("chili");
            System.Threading.Thread.Sleep(2000);
            input.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);
            currentUrl = webDriver.Url;

            IJavaScriptExecutor js = (IJavaScriptExecutor) webDriver;
            js.ExecuteScript("window.scrollBy(0,250)", "");
            System.Threading.Thread.Sleep(2000);
            
            var link = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/div/div/div/div[1]/article[1]/h2/a")));
            //var move = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div/div[1]/article[1]/h2"));
            //action.MoveToElement(move).Build().Perform(); 
            IJavaScriptExecutor ex = (IJavaScriptExecutor)webDriver;
            ex.ExecuteScript("arguments[0].click();", link);

        }

        public bool CheckUrlChili()
        {
            if (firstUrl.Equals(currentUrl) == false && webDriver.PageSource.Contains("CHILI4 – Limited Design – “Yellow”"))
                return true;

            return false;
        }

        public void ClickSearchButton2()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(120));
            var searchButtonClicked = webDriver.FindElement(By.XPath("//*[@id='et_search_icon']"));
            Actions action = new Actions(webDriver);
            action.MoveToElement(searchButtonClicked).Click().Build().Perform();

            firstUrl = webDriver.Url;
            IWebElement input = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("s"))); 

            System.Threading.Thread.Sleep(2000);
            input.SendKeys("chily");
            System.Threading.Thread.Sleep(2000);
            input.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);
            currentUrl = webDriver.Url;

        }

        public bool CheckUrlChily()
        {
            if (firstUrl.Equals(currentUrl)==false &&webDriver.PageSource.Contains("No Results Found"))
                return true;

            return false;
        }
    }
}

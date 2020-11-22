using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowSeleniumCore.Pages;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecflowSeleniumCore.Steps
{
    [Binding]
    public class SkyWalkSearchTEQUILASteps
    {
        HomePage homePage;
        
        [Given(@"Otvoren je web sajt skywalk\.info")]
        public void GivenOtvorenJeWebSajtSkywalk_Info()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox"); //dodato zbog greske sa http zahtevimom
            IWebDriver chromeDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(),options,TimeSpan.FromMinutes(3));
            chromeDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            chromeDriver.Navigate().GoToUrl("https://skywalk.info");
            chromeDriver.Manage().Window.Maximize();
            homePage = new HomePage(chromeDriver);
        }
        
        [When(@"Biram stavku TEGUILA iz stavke menija pod nazivom PRODUCTS")]
        public void selectTequila()
        {
            homePage.ClickTequila();
        }
        
        [Then(@"Proveravam da li je doslo do promene url-a i da li stranica sadrzi tekst Free your mind. For the essentials.")]
        public void FirstTest()
        {
            Assert.That(homePage.CheckUrlTequila(), Is.True);
        }

        

        [When(@"Kliknem na ikonu za pretragu i ukucam rec CHILI u polju za pretragu, zatim kliknem ENTER na tastaturi i kliknem na prvi dobijeni link")]
        public void searchChili()
        {
            homePage.ClickSearchButton();
        }

        [Then(@"Proveravam da li je doslo do promene url-a, da li stranica sadrzi tekst CHILI4 – Limited Design – “Yellow”")]
        public void secondTest()
        {
            Assert.That(homePage.CheckUrlChili(), Is.True);
        }

        [When(@"Kliknem na ikonu za pretragu i ukucam rec CHILY u polju za pretragu, a zatim kliknem ENTER na tastaturi")]
        public void searchChily()
        {
            homePage.ClickSearchButton2();
        }

        [Then(@"Proveravam da li je doslo do promene url-a i da li stranica sadrzi tekst NoResultsFound")]
        public void thirdTest()
        {
            Assert.That(homePage.CheckUrlChily(), Is.True);
        }
    }
}

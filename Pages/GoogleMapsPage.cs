using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GoogleMapsTests.Pages
{
    public class GoogleMapsPage
    {
        private readonly IWebDriver driver;

        public GoogleMapsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AcceptConsents()
        {
            this.driver.FindElement(By.CssSelector("button[aria-label='Aceitar a utilização de cookies e outros dados para os fins descritos']")).Click();
        }

        public void SearchBy(string address)
        {
            this.driver.FindElement(By.Id("searchboxinput")).SendKeys(address);
            this.driver.FindElement(By.Id("searchbox-searchbutton")).Click();
        }

        public string GetAddress()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            return wait.Until(e => e.FindElement(By.CssSelector(".x3AX1-LfntMc-header-title-title"))).Text;
        }

        public void ClickOnDirections()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(e => e.FindElement(By.CssSelector("button[data-value=Direções]"))).Click();
        }

        public string GetDestination()
        {
            return this.driver.PageSource.ToString();
        }
    }
}

using FluentAssertions;
using GoogleMapsTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace GoogleMapsTests
{
    public class GoogleMapsTest
    {
        private IWebDriver? driver;
        private GoogleMapsPage? googleMapsPage;

        [SetUp]
        public void Setup()
        {
            var browserOptions = new ChromeOptions
            {
                PlatformName = "Linux",
                BrowserVersion = "98.0"
            };

            var environmentName = Environment.GetEnvironmentVariable("SELENIUMHUB_HOST") ?? "localhost";

            this.driver = new RemoteWebDriver(new Uri($"http://{environmentName}:4444"), browserOptions);

            googleMapsPage = new GoogleMapsPage(driver);
            driver.Navigate().GoToUrl("https://www.google.com/maps");
            googleMapsPage.AcceptConsents();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void GoogleMaps_SearchByAddress_ReturnsAddressAndDestination()
        {
            // Arrange
            var expectedAddress = "Dublin";
            var expectedDestination = "Dublin";

            // Act
            googleMapsPage.SearchBy("Dublin");

            // Assert
            var address = googleMapsPage.GetAddress();
            address.Should().Be(expectedAddress);

            googleMapsPage.ClickOnDirections();

            var destination = googleMapsPage.GetDestination();
            destination.Should().Contain(expectedDestination);
        }
    }
}

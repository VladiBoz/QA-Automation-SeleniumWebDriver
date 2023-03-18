using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebdriverURLShortenerTest
{
    public class TestsURlShortenerTest
    {
        private WebDriver driver;


        [SetUp]
        public void openBrowser()
        {
         
            this.driver = new ChromeDriver();
        }
        [TearDown] public void closeBrowser()
        { 
            driver.Quit();
        }

        [Test]
        public void TestHomePageAndGetTitle()
        {
            driver.Url = "https://shorturl.softuniqa.repl.co/";

            var pageTitle = driver.Title;

            Assert.That(pageTitle, Is.EqualTo("URL Shortener"));


        }

        [Test]
        public void TestShortUrlPageAndGetURL()
        {
            driver.Url = "https://shorturl.softuniqa.repl.co/";

            var urlLink = driver.FindElement(By.LinkText("Short URLs"));
            urlLink.Click();
            var pageTitle = driver.Title;

            var originalUrl = driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[1]/td[1]/a")).Text;
            var shortUrl = driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[1]/td[2]")).Text;



            Assert.That(pageTitle, Is.EqualTo("Short URLs"));

            Assert.That(originalUrl, Is.EqualTo("https://nakov.com"));

            Assert.That(shortUrl, Is.EqualTo("http://shorturl.softuniqa.repl.co/go/nak"));


            

        }
    }
}
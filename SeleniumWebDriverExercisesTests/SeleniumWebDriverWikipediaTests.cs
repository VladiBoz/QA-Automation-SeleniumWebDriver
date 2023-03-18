using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace SeleniumWebDriverExercisesTests
{
    public class SeleniumWebDriverWikipediaTests
    {
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            
        }
        [TearDown]

        public void CloseBrowser()
        {
            this.driver.Quit();
        }


        [Test]
        public void TestWikipediaTitle()
        {
            driver.Url = "https://www.wikipedia.org/";
            var pageTitle = driver.Title;
            var expected = "Wikipedia";

            Assert.That(pageTitle, Is.EqualTo(expected));
        }
        [Test]
        public void TestWikipediaQaSearch()
        {
            driver.Url = "https://www.wikipedia.org/";
            var searhElement = driver.FindElement(By.Id("searchInput"));
            searhElement.SendKeys("QA" + Keys.Enter);
            var pageTitle = driver.Title;
            var expected = "QA - Wikipedia";

            Assert.That(pageTitle, Is.EqualTo(expected));
        }



    }

}
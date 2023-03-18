using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace SeleniumWebDriverExercisesTests
{
    public class SeleniumWeDriverCalculatorTest
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
        public void TestSummatorOfNumbersAppMultiplying()
        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
            var searchNumber1 = driver.FindElement(By.Id("number1"));
            searchNumber1.SendKeys("15" + Keys.Enter);

            var searchNumber2 = driver.FindElement(By.Id("number2"));
            searchNumber2.SendKeys("7" + Keys.Enter);

            var searchOperator = driver.FindElement(By.CssSelector("#operation > option:nth-child(4)"));
            searchOperator.Click();

            var searchCalculate = driver.FindElement(By.Id("calcButton"));
            searchCalculate.Click();

            var expected = driver.FindElement(By.Id("result")).Text;
            var actual = "Result: 105";

            Assert.That(actual, Is.EqualTo(expected));

        }
        [Test]
        public void TestSummatorOfNumbersAppInvalidInput()
        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
            var searchNumber1 = driver.FindElement(By.Id("number1"));
            searchNumber1.SendKeys("15" + Keys.Enter);

            var searchNumber2 = driver.FindElement(By.Id("number2"));
            searchNumber2.SendKeys("hello" + Keys.Enter);

            var searchOperator = driver.FindElement(By.CssSelector("#operation > option:nth-child(4)"));
            searchOperator.Click();

            var searchCalculate = driver.FindElement(By.Id("calcButton"));
            searchCalculate.Click();

            var expected = driver.FindElement(By.Id("result")).Text;
            var actual = "Result: invalid input";

            Assert.That(actual, Is.EqualTo(expected));

        }
        [Test]
        public void TestSummatorOfNumbersAppTestResetButton()
        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

            var searchNumber1 = driver.FindElement(By.Id("number1"));
            searchNumber1.SendKeys("15" + Keys.Enter);
            var verifyNumber1 = driver.FindElements(By.Id("number1"));
            
            var searchNumber2 = driver.FindElement(By.Id("number2"));
            searchNumber2.SendKeys("10" + Keys.Enter);
            var verifyNumber2 = driver.FindElements(By.Id("number2"));
           
            var searchOperator = driver.FindElement(By.CssSelector("#operation > option:nth-child(4)"));
            searchOperator.Click();

            var searchCalculate = driver.FindElement(By.Id("calcButton"));
            searchCalculate.Click();

           
            var searchReset = driver.FindElement(By.Id("resetButton"));
            searchReset.Click();

            var resetNumber1 = driver.FindElement(By.Id("number1")).Text;
            var resetNumber2 = driver.FindElement(By.Id("number2")).Text;

            Assert.True(verifyNumber1.Count > 0);
            Assert.True(verifyNumber2.Count > 0);
            Assert.IsEmpty(resetNumber1);
            Assert.IsEmpty(resetNumber2);






        }




    }

}
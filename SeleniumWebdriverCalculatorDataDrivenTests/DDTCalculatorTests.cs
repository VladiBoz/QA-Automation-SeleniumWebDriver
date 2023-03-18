using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebdriverCalculatorDataDrivenTests
{
    public class DDTCalculatorTests
    {
        private WebDriver driver;

       [SetUp]
        public void openBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();

        }


          [TestCase("5", "+", "10", "Result: 15")]
          [TestCase("10", "*", "10", "Result: 100")]
          [TestCase("10", "/", "2", "Result: 5")]
          [TestCase("10", "-", "2", "Result: 8")]
          [TestCase("10", "-", "2", "Result: 8")]
           public void TestCalculatorValidIntegers(string firstNum, string operations, string secondNum, string expectedResult)
         
        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys(firstNum + Keys.Enter);

            var operation = driver.FindElement(By.Id("operation"));
            operation.SendKeys(operations + Keys.Enter);

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys(secondNum + Keys.Enter);

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resetButton = driver.FindElement(By.Id("resetButton"));

            var actualResult = driver.FindElement(By.Id("result")).Text;

           

            Assert.That(actualResult, Is.EqualTo(expectedResult));




        }

        [TestCase("5.3", "+", "10.2", "Result: 15.5")]
        [TestCase("10.9", "*", "10.1", "Result: 110.09")]
        [TestCase("10.2", "/", "2.3", "Result: 4.4347826087")]
        [TestCase("10.7", "-", "2.4", "Result: 8.3")]
        [TestCase("10.4", "-", "2.1", "Result: 8.3")]
        public void TestCalculatorValidDecimalNumbers(string firstNum, string operations, string secondNum, string expectedResult)

        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys(firstNum + Keys.Enter);

            var operation = driver.FindElement(By.Id("operation"));
            operation.SendKeys(operations + Keys.Enter);

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys(secondNum + Keys.Enter);

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resetButton = driver.FindElement(By.Id("resetButton"));

            var actualResult = driver.FindElement(By.Id("result")).Text;

            Assert.That(actualResult, Is.EqualTo(expectedResult));




        }
        [TestCase("aa", "+", "10.2", "Result: invalid input")]
        [TestCase("10.9", "4", "10.1", "Result: invalid operation")]
        [TestCase("10.2", "/", "bbb", "Result: invalid input")]
        
        public void TestCalculatorInvalidInputs(string firstNum, string operations, string secondNum, string expectedResult)

        {
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys(firstNum + Keys.Enter);

            var operation = driver.FindElement(By.Id("operation"));
            operation.SendKeys(operations + Keys.Enter);

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys(secondNum + Keys.Enter);

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resetButton = driver.FindElement(By.Id("resetButton"));

            var actualResult = driver.FindElement(By.Id("result")).Text;

            Assert.That(actualResult, Is.EqualTo(expectedResult));




        }
    }
}
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class SeleniumTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(); // You can replace this with the desired browser driver
        }

        [Test]
        public void Todotest()
        {
            Console.WriteLine("Navigating to todos app.");
            _driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");

            _driver.FindElement(By.Name("li4")).Click();
            Console.WriteLine("Clicking Checkbox");
            _driver.FindElement(By.Name("li5")).Click();

            IList<IWebElement> elems = _driver.FindElements(By.ClassName("done-true"));
            Assert.AreEqual(2, elems.Count);

            Console.WriteLine("Entering Text");
            _driver.FindElement(By.Id("sampletodotext")).SendKeys("Yey, Let's add it to list");
            _driver.FindElement(By.Id("addbutton")).Click();

            string spanText = _driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span")).Text;
            Assert.AreEqual("Yey, Let's add it to list", spanText);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
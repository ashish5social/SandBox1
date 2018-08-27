using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox; 



namespace Yatra
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PrintFirstResult(); 
            Assert.AreEqual(1, 1); 
        }

        public string PrintFirstResult()
        {

            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("google.com");
            var searchTextField = driver.FindElementById("lst-ib");
            searchTextField.SendKeys("Microsoft");
            System.Threading.Thread.Sleep(2000); 
           
            var searchButton = driver.FindElementByName("btnK");
            searchButton.Click();
            return "Hi"; 

        }
    }
}

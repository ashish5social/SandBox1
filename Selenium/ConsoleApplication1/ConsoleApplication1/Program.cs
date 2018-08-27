using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make sure to add the path to where you extracting the chromedriver.exe:
            IWebDriver driver = new ChromeDriver(@"C:\sandbox\Selenium\chromedriver"); //<-Add your path
           //System.setProperty("webdriver.gecko.driver", "/Users/username/Downloads/geckodriver");
            //IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new FirefoxDriver(); 
                
            try
            {
                driver.Navigate().GoToUrl("http://yatra.com");
				driver.Manage().Window.Maximize(); 
                System.Threading.Thread.Sleep(10000);
                IWebElement myField = driver.FindElement(By.Id("BE_flight_origin_city"));
                myField.SendKeys("New Delhi, India (DEL)");
                myField = driver.FindElement(By.Id("BE_flight_arrival_city"));
                myField.SendKeys("Bagdogra, India (IXB)");
                myField = driver.FindElement(By.Id("BE_flight_origin_date"));
                myField.SendKeys("27/08/2018");
                myField = driver.FindElement(By.Id("BE_flight_flsearch_btn"));
                myField.Click();
				System.Threading.Thread.Sleep(30000);
			} catch(Exception e)
            {
                Console.WriteLine(e.Message); 
            } finally
            {
                driver.Close(); 
            }




        }
    }
}

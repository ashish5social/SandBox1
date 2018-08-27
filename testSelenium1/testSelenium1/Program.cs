using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSelenium1
{
	class Program
	{
		static void Main(string[] args)
		{
			IWebDriver driver = new FirefoxDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://www.redbus.in/");
			IWebElement src = driver.FindElement(By.XPath("//*[@id='src']"));
			src.SendKeys("Hyderabad");
			System.Threading.Thread.Sleep(1000); 
			IWebElement dest = driver.FindElement(By.XPath("//*[@id='dest']"));
			dest.SendKeys("Bangalore");
			System.Threading.Thread.Sleep(1000);
			IWebElement startDate = driver.FindElement(By.Id("onward_cal"));
			//startDate.Click();
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].setAttribute('value','26-Aug-2018');", startDate);
			//var startDates = driver.FindElements(By.TagName("table"));
			//var dates = startDates[0].FindElement(By.ClassName("current day"));
			System.Threading.Thread.Sleep(1000);
			var search = driver.FindElement(By.Id("search_btn"));
			search.Click();
			System.Threading.Thread.Sleep(5000);
			var buses = driver.FindElements(By.ClassName("row-sec"));
			
			Dictionary<string, int> prices = new Dictionary<string, int>();
			Dictionary<string, string> ids = new Dictionary<string, string>();
			//int[] prices = new int[buses.Count];
			int i = 0; 
			foreach (var bus in buses)
			{
				string busId = bus.GetAttribute("id"); 
				var fare = bus.FindElement(By.ClassName("seat-fare"));
				var fare1 = fare.FindElement(By.ClassName("f-bold"));
				string busName = bus.FindElement(By.ClassName("travels")).Text;
				string value = fare1.Text;
				int busFare = Convert.ToInt32(Convert.ToDouble(value));

				//int busFare = Int32.Parse(fare1.Text); 
				Console.WriteLine("fare for bus {0} is {1}", busName, busFare);
				try
				{
					prices.Add(busName, busFare);
					ids.Add(busName, busId); 
				}
				catch (Exception e)
				{
					Console.WriteLine("Exception thrown: " + e.StackTrace); 
				}
				//prices[i++] = busFare; 
			}

			string minFareBus = ""; 
			int minFare = int.MaxValue;
			//string key = ""; 
			foreach(string key in prices.Keys)
			{
				if (prices[key] < minFare)
				{
					minFare = prices[key];
					minFareBus = key; 
				}
			}

			Console.WriteLine("Lowest price is {0} for travels: {1}", minFare, minFareBus);
			var selectedBus = driver.FindElement(By.Id(ids[minFareBus]));
			var button = selectedBus.FindElement(By.ClassName("button"));
			button.Click();

			IWebElement element = driver.FindElement(By.TagName("canvas"));

			Actions builder = new Actions(driver);
			Action drawAction = builder.MoveToElement(element, 135, 15)
					  .Click()
					  .MoveByOffset(200, 60) // 2nd points (x1,y1)
					  .Click()
					  .MoveByOffset(100, 70)// 3rd points (x2,y2)
					  .DoubleClick()
					  .Build();




			drawAction.Perform();



			Console.ReadLine(); 
		}
	}
}

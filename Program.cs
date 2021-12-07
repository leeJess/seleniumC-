using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace sc
{
    class Program
    {
        public static IWebDriver driver;

        [Test]
        public static void Main ()
        {
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver","driver/chromedriver");
            driver =new ChromeDriver();
            driver.Url = "https://www.carlist.my";

            driver.FindElement(By.XPath("//form[contains(@autocomplete,'off')]//div[contains(@class,'selectize-control js-selectize js-reset-selectize single')]")).Click();
            driver.FindElement(By.CssSelector("div[data-value='used']")).Click();
            driver.FindElement(By.CssSelector("form[autocomplete='off'] button[type='submit']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.XPath("(//h2[contains(@class,'flush')])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            char[] charsToTrim = { ',','M','R', ' ', '\''};

            string needed = driver.FindElement(By.XPath("//*[@id='details-gallery']/div/div/div[1]/div[1]/div[2]/div/div[1]/h3")).Text;
            
            needed = needed.Replace(",", String.Empty);
            Console.WriteLine(needed);
            needed = needed.Replace(".", String.Empty);
            Console.WriteLine(needed);

            string result = needed.Trim(charsToTrim);
            Console.WriteLine(result);
          
            int result2 = Int32.Parse(result);
            Console.WriteLine(result2);

            Console.WriteLine($"string to int, the value i get: '{result2}'");
            Assert.That(result2, Is.GreaterThan(1000));
          
            driver.Close();
        }
    }
}

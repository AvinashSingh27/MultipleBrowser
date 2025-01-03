using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace ParallelBrowserTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the browser name from command-line arguments or default to Chrome
            string browser = args.Length > 0 ? args[0].ToLower() : "chrome";
            IWebDriver driver;

            // Initialize the browser driver based on the argument
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            try
            {
                // Open a dummy website
                driver.Navigate().GoToUrl("https://example.com");

                // Verify the page title
                Console.WriteLine($"Running test on {browser.ToUpper()}");
                Console.WriteLine($"Page Title: {driver.Title}");

                // Simulate a dummy verification
                if (driver.Title.Contains("Example"))
                {
                    Console.WriteLine("Test Passed: Title contains 'Example'");
                }
                else
                {
                    Console.WriteLine("Test Failed: Title does not contain 'Example'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }
    }
}

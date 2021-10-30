using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;


namespace TwiiterGetData
{
    class Program
    {
        static void Main(string[] args)
        {
            

                ChromeDriverService log = ChromeDriverService.CreateDefaultService();
                log.HideCommandPromptWindow = true;
                log.SuppressInitialDiagnosticInformation = true;
                ChromeOptions hide = new ChromeOptions();
                //hide.AddArgument("--headless");
                ChromeDriver driver = new ChromeDriver(log, hide);


                ///login เฟสผ่าน Token app [เสร็จ]
                driver.Navigate().GoToUrl("https://m.facebook.com/");
                string password = File.ReadAllLines("password.txt")[0];
                string username = File.ReadAllLines("username.txt")[0];
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.XPath("//div[@id='email_input_container']//input")).SendKeys(username);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.XPath("//div[@data-sigil='m_login_password']//input")).SendKeys(password);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.XPath("//div[@id='login_password_step_element']//button")).Click();

                Thread.Sleep(5000);
                driver.Navigate().GoToUrl("https://m.facebook.com/profile.php");

                var blackgcolor = Console.BackgroundColor = ConsoleColor.Blue;
                string date = DateTime.Now.ToLongTimeString();
                string text = " : Success";
                Console.WriteLine(date + text);

                 Console.ReadKey();
                driver.Quit();


        }
    }
}

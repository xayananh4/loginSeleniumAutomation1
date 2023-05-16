using System.Drawing;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
namespace loginSeleniumAutomation;

[TestClass]
public class UnitTest1
{
    static IWebDriver driver = null;

    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine("TestExcution Has Started");
        driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/?ref=hackernoon.com");
        Console.WriteLine("Url is opened");
        driver.Manage().Window.Size = new Size(1920, 1080);
        String txt_title = driver.Title.ToString();
        bool titleIsEqual = txt_title.Equals("The Internet");
        Assert.IsTrue(titleIsEqual);
        Console.WriteLine("Test has completed. Website is up.");
    }

    [TestMethod]
    public void test2()
    {
        // click on Add/Remove Elements page
        clickElement("#content > ul > li:nth-child(2) > a");
        clickElement("#content > div > button");
        clickElement("#elements > button");
        driver.Navigate().Back();
        String txt_title = driver.Title.ToString();
        bool titleIsEqual = txt_title.Equals("The Internet");
        Assert.IsTrue(titleIsEqual);
        Console.WriteLine("Test has completed. Back to Home page.");

    }







    public static IWebElement clickElement(string selector)
    {
        By elementSelector = By.CssSelector(selector);
        var element = driver.FindElement(elementSelector);
        if (element != null)
        {

            element.Click();
            Console.WriteLine("Element has been clicked");
            return element;
        }
        else
        {
            Console.WriteLine("element not found");
            throw new InvalidOperationException("element is not exist");
        }
    }


    // Means initialize once; Entry point where test is ran, only happens once
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("no-sandbox");

        driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
        driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));


        if (driver != null)
        {
            Console.WriteLine("WebDriver is not null");

        }
        else
        {
            Console.WriteLine("WebDriver is not initialize");
            throw new InvalidOperationException("webDriver is not initialize");
        }
        Console.WriteLine("driverInitialize");
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        driver.Quit();
        driver.Close();
        Console.WriteLine("classCleanUp");
    }
}

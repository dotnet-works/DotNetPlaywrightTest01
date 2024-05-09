using Allure.Net.Commons;
using Allure.NUnit;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tests
{
    [AllureNUnit]
    //[Parallelizable]
    [Parallelizable(ParallelScope.All)]
    public class DemoPlaywright2
    {
        IPlaywright playwright;
        IBrowser browser;
        IPage page;
        BrowserTypeLaunchOptions launchOptions;


        public ILocator _searchBox;
        public ILocator _resultPageToolsBTN;
        public ILocator _resultPageAnyTimeBTN;

        //public readonly Input depositValue = Input.ByName("depositValue");





        [SetUp]
        public async Task InitTest()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new() { Headless = true, Timeout = 45000 });
            page = await browser.NewPageAsync();

            _searchBox = page.Locator("[name=q]");
            _resultPageToolsBTN = page.Locator("//div[@id='hdtb-tls']");
        }

        [TearDown]
        public async Task Cleanup()
        {
            var bytes = await page.ScreenshotAsync();

            AllureApi.AddAttachment("AttachByteArray.png", "image/png", bytes);
            //await page.ScreenshotAsync(new PageScreenshotOptions { Path = "../../../screenshot1.png" });
            page.CloseAsync();
            browser.CloseAsync();
        }


        [Test]
        [Description("Testing pressing of keyboard key")]
        public async Task SampleTest1()
        {
            ///* ##### SetUp ####  */
            //playwright = await Playwright.CreateAsync();
            //browser = await playwright.Firefox.LaunchAsync(new() { Headless = false, Timeout = 45000 });
            //page = await browser.NewPageAsync();
            ///* #########  */



            await page.GotoAsync("https://www.google.com/");
            Thread.Sleep(4000);


            //var locator = page.Locator("[name=q]");
            await Assertions.Expect(_searchBox).ToBeEnabledAsync(new() { Timeout = 2500 });

            await _searchBox.ClickAsync();
            await _searchBox.FillAsync("Playwright c# examples");
            await page.GetByLabel("Google Search").First.ClickAsync();

            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Assertions.Expect(_resultPageToolsBTN).ToBeEnabledAsync(new() { Timeout = 4000 });
            await page.Locator("//div[@id='hdtb-tls']").ClickAsync();
            Thread.Sleep(2000);
            await page.Locator("//div[@id='hdtb-tls']").ClickAsync();
            await Assertions.Expect(page.Locator("//div[@id='result-stats']")).ToBeVisibleAsync(new() { Timeout = 3000, Visible = true });

            string _resultText = await page.Locator("//div[@id='result-stats']").InnerTextAsync();
            Console.WriteLine(_resultText);
            //string pattern = @"[0-9,]";

            ////System.Text.RegularExpressions.Regex
            ////string resultString = Regex.Match(_resultText, @"\d+").Groups[1].Value;

            ////string resultString = Regex.Match(_resultText, @",?\d+").Value;
            ////Console.WriteLine(resultString);

            ////Regex re = new Regex(@"\d+");
            ////Match m = re.Match(_resultText);
            ////Console.WriteLine(m.Value);

            //string[] numbers = Regex.Split(_resultText, @"\D+");
            //foreach (string value in numbers)
            //{
            //    if (!string.IsNullOrEmpty(value))
            //    {
            //        int i = int.Parse(value);
            //        Console.WriteLine("Number: {0}", i);
            //    }
            //}


            ////Your code goes here
            //Console.WriteLine(Regex.Match(_resultText, @"\d+\,*\d+").Value);
            ////Your code goes here
            //Console.WriteLine(Regex.Match(_resultText, @"\d+\.*\d+").Value);

            string[] result = _resultText.Split();
            string s = "123iuow45ss";
            var getNumbers = (from t in result[1]
                              where char.IsDigit(t)
                              select t).ToArray();
            Console.WriteLine(new string(getNumbers));
            Console.WriteLine(result[3].Replace("(", "").Replace(")", ""));

            var screenshotPath = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png";
            DateTime time = DateTime.Now;
            string dateToday = "_date_" + time.ToString("yyyy-MM-dd") + "_time_" + time.ToString("HH-mm-ssa");

            AllureApi.AddAttachment("data.txt", "text/plain", Encoding.UTF8.GetBytes("This is the file content."));

            //// Use regular expression to match the pattern
            //Match match = Regex.Match(_resultText, pattern);
            //// Check if the pattern is found
            //if (match.Success)
            //{
            //    // Extract the Work Order number from the matched groups
            //    string workOrderNumber = match.Groups[1].Value;
            //    Console.WriteLine(workOrderNumber);
            //}


            //"About 1,95,000 results (0.26 seconds)";

        }

        [Test]
        [Description("Testing iterate through list items ")]
        [Ignore("")]
        public async Task SampleTest2()
        {
            await page.GotoAsync("https://www.nytimes.com/");
            Thread.Sleep(3000);

            

        }

        //[Test]
        //[Description("Handle expected wait conditions")]
        //public void SampleTest3()
        //{

        //}

        //[Test]
        //[Description("Handle expected wait conditions")]
        //public void SampleTest4()
        //{

        //}








    }
}

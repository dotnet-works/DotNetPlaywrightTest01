using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;




namespace Tests
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.All)]
    public class DemoPlaywright1
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
            browser = await playwright.Firefox.LaunchAsync(new() { Headless = true, Timeout = 45000 });
            page = await browser.NewPageAsync();

            _searchBox = page.Locator("[name=q]");
            _resultPageToolsBTN = page.Locator("//div[@id='hdtb-tls']");
        }

        [TearDown]
        public async Task Cleanup() 
        {
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "../../../screenshot1.png" });
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
            await Assertions.Expect(_searchBox).ToBeEnabledAsync(new(){ Timeout =2500});

            await _searchBox.ClickAsync();
            await _searchBox.FillAsync("Playwright c# examples");
            await page.Keyboard.PressAsync("Enter");
            //Thread.Sleep(8000);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Assertions.Expect(_resultPageToolsBTN).ToBeEnabledAsync(new() { Timeout = 4000 });
            await page.Locator("//div[@id='hdtb-tls']").ClickAsync();
            Thread.Sleep(2000);
            await page.Locator("//div[@id='hdtb-tls']").ClickAsync();
            await Assertions.Expect(page.Locator("//div[@id='result-stats']")).ToBeVisibleAsync(new() { Timeout = 5000, Visible = true });
            //Thread.Sleep(8000);
            await Assertions.Expect(page.Locator("//div[contains(text(),'Any time')and @class='KTBKoe']")).ToBeVisibleAsync(new() { Visible = true });
            await page.Locator("//div[contains(text(),'Any time')and @class='KTBKoe']").ClickAsync();
            Thread.Sleep(3000);

            //IReadOnlyList<ILocator> eles = await page.Locator("g-menu-item.EpPYLd.GZnQqe,g-menu-item[jsname='NNJLud']").AllAsync();
            //IReadOnlyList<ILocator> eles = await page.Locator("g-menu[role='menu']").Locator("g-menu-item[jsname='NNJLud']").AllAsync();

            IReadOnlyList<ILocator> eles = await page.Locator("//g-menu-item[starts-with(@class,'EpPYLd') and @role='none']").AllAsync();

            //IReadOnlyList<ILocator> eles = await page.Locator(".EpPYLd.GZnQqe").AllAsync();
            Console.WriteLine(eles.Count());
            foreach (var e in eles)
            {
                
                //string x =await e.InnerTextAsync();
                //Console.WriteLine(x);
                if (await e.IsVisibleAsync())
                {
                    string x = await e.InnerTextAsync();
                    Console.WriteLine(x);
                    await e.HoverAsync(new LocatorHoverOptions { Timeout = 5000 });
                    Thread.Sleep(500);
                }
            }

            
            //Thread.Sleep(7000);



            ///* ##### Teardown ####  */
            //await page.ScreenshotAsync(new PageScreenshotOptions { Path = "../../../screenshot1.png" });
            //page.CloseAsync();
            //browser.CloseAsync();
            ///* #########  */


        }

        //[Test]
        //[Description("Testing iterate through list items ")]
        //public async Task SampleTest2()
        //{
        //    await page.GotoAsync("https://www.amazon.in/");
        //    Thread.Sleep(3000);

        //}

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

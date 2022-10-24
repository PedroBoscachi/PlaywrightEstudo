using Microsoft.Playwright.MSTest;

namespace MyUnitTests
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        [TestMethod]
        public async Task WhenDotNetCoreTutorialsSearchedOnGoole_firstResultIsDomainDotNetCoreTutorialsDotCom()
        {
            await Page.GotoAsync("https://www.google.com");

            await Page.FillAsync("[title='Search']", "dotnetcoretutorials.com");

            await Page.ClickAsync("[value='Google Search'] >> nth=1");

            var firstResult = await Page.Locator("//cite >> nth=0").InnerTextAsync();
            Assert.AreEqual("https://dotnetcoretutorials.com", firstResult);
        }
    }
}
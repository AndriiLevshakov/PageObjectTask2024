using PageObjectTask2024.PageObjects;
using PageObjectTask2024.TestFixtures;
using PageObjectTask2024.WebDriver;

namespace PageObjectTask2024.Tests
{
    public class Tests : BaseTestFixtures
    {
        [TestCase("C#", "All Locations")]
        public void Test1_Careers(string programmingLanguage, string location)
        {
            var homePage = new HomePage(WebDriverManager.Driver);

            homePage.ClickAcceptButton();

            homePage.ClickCareersLink();

            var careersPage = new CareersPage(WebDriverManager.Driver);

            careersPage.EnterKeywords(programmingLanguage);

            careersPage.OpenLocationDropDownMenu();

            careersPage.SelectAllLocations();

            careersPage.SelectRemoteOption();

            careersPage.ClickFindButton();

            careersPage.ClickSortingLabelByDate();

            careersPage.GetLatestResul();

            Assert.That(careersPage.IsPresentOnThePage(programmingLanguage),
                $"Programming language '{programmingLanguage}' not found on the page");
        }

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void Test2_GlobalSearch(string searchKeyword)
        {
            var homePage = new HomePage(WebDriverManager.Driver);

            homePage.ClickMagnifierIcon();

            homePage.SendSearchInputToGlobalSearch(searchKeyword);

            homePage.ClickFindButtonForGlobalSearch();

            Assert.That(homePage.IsSearchKeywordPresentOnThePage(searchKeyword));
        }

        [Test]
        public void Test3_ValidateFileDownload()
        {
            var homePage = new HomePage(WebDriverManager.Driver);

            var aboutPage = new AboutPage(WebDriverManager.Driver);

            homePage.ClickAcceptButton();

            homePage.ClickAboutLink();

            aboutPage.ClickDownloadButton();

            Assert.That(aboutPage.IsDownloaded("EPAM_Corporate_Overview_Q4_EOY.pdf"));
        }

        [Test]
        public void Test4_ValidateArticleTitleInCarousel()
        {
            var homePage = new HomePage(WebDriverManager.Driver);

            var insightsPage = new InsightsPage(WebDriverManager.Driver);

            homePage.ClickAcceptButton();

            homePage.ClickInsightsLink();

            insightsPage.SwipeCarouselTwice();

            insightsPage.ClickReadMoreButton();

            Assert.That(insightsPage.IsActiveSliderTextPresentInTheArticleText());
        }
    }
}
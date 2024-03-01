using PageObjectTask2024.WebDriver;

namespace PageObjectTask2024.TestFixtures
{
    public class BaseTestFixtures
    {
        public string BaseUrl { get; } = "https://www.epam.com/";

        [SetUp]
        public void SetUp()
        {
            WebDriverManager.Driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverManager.QuitDriver();
        }
    }
}

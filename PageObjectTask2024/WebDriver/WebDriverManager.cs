using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectTask2024.WebDriver
{
    public static class WebDriverManager
    {
        private static IWebDriver? _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string downloadPath = Path.Combine(userPath, "Downloads");

                    var options = new ChromeOptions();

                    options.AddArguments("--headless");
                    options.AddArguments("--window-size=1920,1080");
                    options.AddUserProfilePreference("download.default_directory", downloadPath);


                    _driver = new ChromeDriver(options);
                }

                return _driver;
            }
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();

                _driver = null;
            }
        }
    }
}

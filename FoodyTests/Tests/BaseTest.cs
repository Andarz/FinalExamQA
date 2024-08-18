using FoodyTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FoodyTests.Tests
{
	public class BaseTest
	{
		public IWebDriver driver;

		public Actions actions;

		public WebDriverWait wait;

		public LoginPage loginPage;

		public AddFoodPage addFoodPage;

		public HomePage homePage;

		public EditPage editPage;

		public SearchPage searchPage;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var chromeOptions = new ChromeOptions();

			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			chromeOptions.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(chromeOptions);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			actions = new Actions(driver);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

			loginPage = new LoginPage(driver);
			addFoodPage = new AddFoodPage(driver);
			homePage = new HomePage(driver);
			editPage = new EditPage(driver);
			searchPage = new SearchPage(driver);

			loginPage.OpenPage();
			loginPage.PerformLogin("andarz1", "123456");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		private const string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		public string GenerateRandomString(int length)
		{
			var random = new Random();
			return new string(Enumerable.Range(0, length)
										.Select(_ => CharSet[random.Next(CharSet.Length)])
										.ToArray());
		}
	}
}

using OpenQA.Selenium;

namespace FoodyTests.Pages
{
	public class AddFoodPage : BasePage
	{
        public AddFoodPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Food/Add";

        public IWebElement FoodnameInput => driver.FindElement(By.Id("name"));
        public IWebElement DescriptionInput => driver.FindElement(By.Id("description"));
        public IWebElement PicInput => driver.FindElement(By.Id("url"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement MainErrorMessage => driver.FindElement(By.CssSelector(".text-danger.validation-summary-errors li"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void AssertMainErrorMessage()
        {
            Assert.That(MainErrorMessage.Text, Is.EqualTo("Unable to add this food revue!"));
        }
    }
}

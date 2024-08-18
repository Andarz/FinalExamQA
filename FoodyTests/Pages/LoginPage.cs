using OpenQA.Selenium;

namespace FoodyTests.Pages
{
	public class LoginPage : BasePage
	{
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/User/Login";

        public IWebElement UsernameInput => driver.FindElement(By.Id("username"));
        public IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void PerformLogin(string username, string password)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButton.Click();
        }
    }
}

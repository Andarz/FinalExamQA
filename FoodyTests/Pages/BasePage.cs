using OpenQA.Selenium;

namespace FoodyTests.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;

		public string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

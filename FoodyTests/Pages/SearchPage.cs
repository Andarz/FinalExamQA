using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTests.Pages
{
	public class SearchPage : BasePage
	{
        public SearchPage(IWebDriver driver) : base(driver)
        {
            
        }

		public string Url => BaseUrl + "/";

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}

		public IWebElement SearchInput => driver.FindElement(By.CssSelector(".form-control.rounded.mt-5.xl"));
		public IWebElement SearchButton => driver.FindElement(By.CssSelector(".btn.btn-primary.rounded-pill.mt-5.col-2"));
		public IWebElement Message => driver.FindElement(By.CssSelector(".display-4"));
	}
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTests.Pages
{
	public class EditPage : BasePage
	{
        public EditPage(IWebDriver driver) : base(driver)
        {
            
        }

        public IWebElement EditNameInput => driver.FindElement(By.Id("name"));
        public IWebElement EditDescriptionInput => driver.FindElement(By.Id("description"));
        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@type='submit']"));
    }
}

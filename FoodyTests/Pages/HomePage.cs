using OpenQA.Selenium;

namespace FoodyTests.Pages
{
	public class HomePage : BasePage
	{
        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/";

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public IReadOnlyCollection<IWebElement> Foods => driver.FindElements(By.XPath("//*[@id=\"scroll\"]/div/div/div[2]/div"));

        public IWebElement lastFood => Foods.Last(); 
        public IWebElement FoodTitle => Foods.Last().FindElement(By.CssSelector(".display-4"));
        public IWebElement FoodEditButton => Foods.Last().FindElement(By.CssSelector("#scroll > div > div > div.col-lg-6.order-lg-1 > div > a:nth-child(4)"));
        public IWebElement FoodDeleteButton => Foods.Last().FindElement(By.CssSelector("#scroll > div > div > div:nth-child(2) > div > a:nth-child(5)"));
        public IWebElement AddFoodButton => Foods.Last().FindElement(By.XPath("//*[@id=\"navbarResponsive\"]/ul/ul/li[1]/a"));
        
    }
}

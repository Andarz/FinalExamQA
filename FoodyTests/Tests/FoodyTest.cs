using FoodyTests.Pages;

namespace FoodyTests.Tests
{
    public class FoodyTests : BaseTest
    {
		private static string? createdFoodTitle;
		private static string? createdFoodDescription;

		[Test, Order(1)]
        public void AddFoodWithInvalidData_Test()
        {
            addFoodPage.OpenPage();

            addFoodPage.FoodnameInput.Clear();
            addFoodPage.DescriptionInput.Clear();
            addFoodPage.AddButton.Click();

            Assert.That(driver.Url, Is.EqualTo(addFoodPage.Url));

            addFoodPage.AssertMainErrorMessage();
        }

        [Test, Order(2)]
        public void AddRandomFood_Test()
        {
            createdFoodTitle = GenerateRandomString(5);
			createdFoodDescription = GenerateRandomString(10);

            addFoodPage.OpenPage();

            addFoodPage.FoodnameInput.Clear();
            addFoodPage.FoodnameInput.SendKeys(createdFoodTitle);

            addFoodPage.DescriptionInput.Clear();
            addFoodPage.DescriptionInput.SendKeys(createdFoodDescription);

            addFoodPage.AddButton.Click();

            Assert.That(driver.Url, Is.EqualTo(homePage.Url), "Wrong redirection!");
            Assert.That(homePage.FoodTitle.Text, Is.EqualTo(createdFoodTitle), "Titles do not match!");
		}

        [Test, Order(3)]
        public void EditLastAddedFood_Test()
        {
            homePage.OpenPage();

            actions.ScrollToElement(homePage.lastFood).Perform();
            actions.ScrollToElement(homePage.FoodEditButton).Perform();

            homePage.FoodEditButton.Click();

            editPage.EditNameInput.Clear();
            editPage.EditNameInput.SendKeys("Edited");

            editPage.EditButton.Click();

            Assert.That(homePage.FoodTitle.Text, Is.EqualTo(createdFoodTitle));

            Console.WriteLine("title change won't be possible due to incomplete functionality");
        }

        [Test, Order(4)]
        public void SearchForFoodTitle_Test()
        {
            searchPage.OpenPage();

            actions.ScrollToElement(searchPage.SearchInput).Perform();
            searchPage.SearchInput.Clear();
            searchPage.SearchInput.SendKeys(createdFoodTitle);
            searchPage.SearchButton.Click();

            Assert.That(homePage.Foods.Count, Is.EqualTo(1));
            Assert.That(homePage.FoodTitle.Text, Is.EqualTo(createdFoodTitle));
        }

        [Test, Order(5)]
        public void DeleteLastAddedFood_Test()
        {
            homePage.OpenPage();

            var foodsInitialCount = homePage.Foods.Count;
			var lastFoodTitleBeforeDelete = homePage.FoodTitle.Text;

			//actions.ScrollToElement(homePage.lastFood).Perform();
			actions.ScrollToElement(homePage.FoodDeleteButton).Perform();

			homePage.FoodDeleteButton.Click();

            Assert.That(homePage.Foods.Count, Is.EqualTo(foodsInitialCount - 1));

			actions.ScrollToElement(homePage.lastFood).Perform();
			var lastFoodTitleAfterDelete = homePage.FoodTitle.Text;

			Assert.That(lastFoodTitleAfterDelete, Is.Not.EqualTo(lastFoodTitleBeforeDelete));
		}

        [Test, Order(6)]
        public void SearchForDeletedFood_Test()
        {
            homePage.OpenPage();

			actions.ScrollToElement(searchPage.SearchInput).Perform();
			searchPage.SearchInput.Clear();
			searchPage.SearchInput.SendKeys(createdFoodTitle);
			searchPage.SearchButton.Click();

			Assert.That(searchPage.Message.Text, Is.EqualTo("There are no foods :("));
            actions.MoveToElement(homePage.AddFoodButton).Perform();
            Assert.That(homePage.AddFoodButton.Displayed, Is.True);
		}
    }
}
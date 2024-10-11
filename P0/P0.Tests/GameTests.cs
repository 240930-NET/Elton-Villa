public class GameTests(){
    [Fact]
    public void Mashable_Game_IsGameMashable_Returns_True(){
        //Arrange
        List<string> testOptions = new List<string> {"1", "2", "3"};
        Category testCategory = new Category("Category", testOptions);
        List<Category> testCategories = new List<Category>{testCategory};
        Game test = new Game("Game", testCategories);;
        //Act
        bool result = test.isGameMashable();
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void NonMashable_Game_IsGameMashable_Returns_False(){
        //Arrange
        List<string> testOptions = new List<string> {"1"};
        Category testCategory = new Category("Category", testOptions);
        List<Category> testCategories = new List<Category>{testCategory};
        Game test = new Game("Game", testCategories);;
        //Act
        bool result = test.isGameMashable();
        //Assert
        Assert.False(result);
    }

    public void Empty_Game_IsGameMashable_Returns_False(){
        //Arrange
        List<Category> testCategories = new List<Category>{};
        Game test = new Game(null, testCategories);
        //Act
        bool result = test.isGameMashable();
        //Assert
        Assert.False(result);
    }
}
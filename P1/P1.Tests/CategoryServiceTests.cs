using P1.API.Repository;
using P1.API.Service;
using P1.API.Model;
using Moq;
using P1.API.Model.DTO;

namespace P1.Tests;

public class CategoryServiceTests
{
    [Fact]
    public void GetAllCategoriesReturnsAllCategories()
    {
        Mock<ICategoryRepository> mockRepo = new();
        CategoryService categoryService = new(mockRepo.Object);

        List<Category> cList = [
            new Category {Title = "SampleTitle", Options = {"A","B","C"}},
            new Category {Title = "Another Title", Options = {"1","2","3","4","5"}}
        ];

        mockRepo.Setup(repo => repo.GetAllCategories())
            .Returns(cList);

        var result = categoryService.GetAllCategories();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, e => e.Title!.Equals("SampleTitle"));
        Assert.Contains(result, e => e.Title!.Equals("Another Title"));
    }

    [Fact]
    public void GetAllCategoriesReturnsEmptyArrayWhenEmpty()
    {
        Mock<ICategoryRepository> mockRepo = new();
        CategoryService categoryService = new(mockRepo.Object);

        List<Category> cList = [];

        mockRepo.Setup(repo => repo.GetAllCategories())
            .Returns(cList);

        var result = categoryService.GetAllCategories();

        Assert.NotNull(result);
        Assert.Equal([], result);
    }

    [Fact]
    public void GetCategoryByIdThrowsExceptionIfNotFound()
    {
        Mock<ICategoryRepository> mockRepo = new();
        CategoryService categoryService = new(mockRepo.Object);

        List<Category> cList = [
            new Category {CategoryId = 1, Title = "M.A.S.H.", Options = {"Mansion","Apartment","Shack","House"}},
            new Category {CategoryId = 2, Title = "Jobs", Options = {"Doctor","Scientist","Teacher","Unemployed"}},
            new Category {CategoryId = 3, Title = "Pet", Options = {"Dog","Rat","Fly","Cat"}}
        ];

        mockRepo.Setup(repo => repo.GetCategoryById(4))
            .Returns(cList.FirstOrDefault(category => category.CategoryId == 4));

        Assert.Throws<Exception>(() => categoryService.GetCategoryById(4));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetCategoryByIdReturnsCorrectCategory(int id)
    {
        Mock<ICategoryRepository> mockRepo = new();
        CategoryService categoryService = new(mockRepo.Object);

        List<Category> cList = [
            new Category {CategoryId = 1, Title = "M.A.S.H.", Options = {"Mansion","Apartment","Shack","House"}},
            new Category {CategoryId = 2, Title = "Jobs", Options = {"Doctor","Scientist","Teacher","Unemployed"}},
            new Category {CategoryId = 3, Title = "Pet", Options = {"Dog","Rat","Fly","Cat"}}
        ];

        mockRepo.Setup(repo => repo.GetCategoryById(It.IsAny<int>()))!
            .Returns(cList.FirstOrDefault(category => category.CategoryId == id));

        var result = categoryService.GetCategoryById(id);

        Assert.NotNull(result);
        Assert.IsType<Category>(result);
        Assert.Equal(id, result.CategoryId);
    }

    [Fact]
    public void AddCategoryThrowsExceptionWithNoTitle(){
        Mock<ICategoryRepository> mockRepo = new();
        CategoryService categoryService = new(mockRepo.Object);

        int gameId = 2;
        List<Category> cList = [];
        Category notTitleCategory = new Category {Title = "", Options = ["A","B","C"], GameId = gameId};
        NewCategoryDTO noTitleCategoryDTO = new NewCategoryDTO{Title = notTitleCategory.Title, Options = notTitleCategory.Options};

        mockRepo.Setup(repo => repo.AddCategory(It.IsAny<Category>()))!
            .Callback(() => cList.Add(notTitleCategory));

        Assert.Throws<Exception>(() => categoryService.AddCategory(noTitleCategoryDTO, gameId));
    }

    [Fact]
    public void AddCategoryThrowsExceptionWithNoOptions(){
        Mock<ICategoryRepository> mockRepo = new();
        CategoryService categoryService = new(mockRepo.Object);

        int gameId = 2;
        List<Category> cList = [];
        Category notTitleCategory = new Category {Title = "Sample Title", Options = [], GameId = gameId};
        NewCategoryDTO noTitleCategoryDTO = new NewCategoryDTO{Title = notTitleCategory.Title, Options = notTitleCategory.Options};

        mockRepo.Setup(repo => repo.AddCategory(It.IsAny<Category>()))!
            .Callback(() => cList.Add(notTitleCategory));

        Assert.Throws<Exception>(() => categoryService.AddCategory(noTitleCategoryDTO, gameId));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void DeleteCategoryByIdDeletesCorrectCategory(int id){
        Mock<ICategoryRepository> mockRepo = new();
        CategoryService categoryService = new(mockRepo.Object);

        List<Category> cList = [
            new Category {CategoryId = 1, Title = "M.A.S.H.", Options = {"Mansion","Apartment","Shack","House"}},
            new Category {CategoryId = 2, Title = "Jobs", Options = {"Doctor","Scientist","Teacher","Unemployed"}},
            new Category {CategoryId = 3, Title = "Pet", Options = {"Dog","Rat","Fly","Cat"}}
        ];

        Category categoryToDelete = cList.First(category => category.CategoryId == id);

        mockRepo.Setup(repo => repo.DeleteCategory(It.IsAny<Category>()))
            .Callback(() => cList.Remove(categoryToDelete));
        mockRepo.Setup(repo => repo.GetCategoryById(It.IsAny<int>()))!
            .Returns(cList.FirstOrDefault(category => category.CategoryId == id));

        categoryService.DeleteCategoryById(id);

        Assert.DoesNotContain(categoryToDelete, cList);
    }
}
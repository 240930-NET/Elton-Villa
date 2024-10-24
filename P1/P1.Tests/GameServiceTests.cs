using P1.API.Repository;
using P1.API.Service;
using P1.API.Model;
using Moq;

public class GameServiceTests{

    [Fact]
    public void GetAllGamesReturnsEmptyArrayWhenEmpty(){
        Mock<IGameRepository> mockRepo = new();
        GameService gameService = new(mockRepo.Object);

        List<Game> gList = [];

        mockRepo.Setup(repo => repo.GetAllGames())
            .Returns(gList);

        var result = gameService.GetAllGames();

        Assert.NotNull(result);
        Assert.Equal([], result);
    }

}
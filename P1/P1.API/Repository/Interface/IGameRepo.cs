using P1.API.Model;

namespace P1.API.Repository;

public interface IGameRepository
{
    public List<Game> GetAllGames();
    public Game GetGameByName(string name);
    public void AddGame(Game game);
    public void DeleteGame(Game game);
}
using P1.API.Model;

namespace P1.API.Service;

public interface IGameService
{
    public IEnumerable<Game> GetAllGames();
    public Game GetGameByName(string name);
    public void AddGame(Game game);
    public void DeleteGameByName(string name);
}
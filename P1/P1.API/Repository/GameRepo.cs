using P1.API.Data;
using P1.API.Model;

namespace P1.API.Repository;

public class GameRepository : IGameRepository
{
    private readonly MASHContext _mashContext;

    public GameRepository(MASHContext mashContext) => _mashContext = mashContext;

    public IEnumerable<Game> GetAllGames()
    {
        return _mashContext.Games.ToList();
    }

    public Game GetGameByName(string name)
    {
        return _mashContext.Games.FirstOrDefault(game => game.Name == name);
    }

    public void AddGame(Game game)
    {
        _mashContext.Games.Add(game);
        _mashContext.SaveChanges();
    }

    public void DeleteGame(Game game){
        _mashContext.Games.Remove(game);
        _mashContext.SaveChanges();
    }
}
using P1.API.Migrations;
using P1.API.Model;
using P1.API.Repository;

namespace P1.API.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository) => _gameRepository = gameRepository;

    public IEnumerable<Game> GetAllGames()
    {
        return _gameRepository.GetAllGames();
    }

    public Game GetGameByName(string name)
    {
        return _gameRepository.GetGameByName(name);
    }

    public void AddGame(Game game)
    {
        _gameRepository.AddGame(game);
    }

    public void DeleteGameByName(string name)
    {
        Game gameToDelete = _gameRepository.GetGameByName(name);
        if(gameToDelete == null){
            throw new Exception($"The game: {name} does not exist and cannot be deleted.");
        }
        _gameRepository.DeleteGame(gameToDelete);
    }
}
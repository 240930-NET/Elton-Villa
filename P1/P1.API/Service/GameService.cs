using P1.API.Migrations;
using P1.API.Model;
using P1.API.Model.DTO;
using P1.API.Repository;

namespace P1.API.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository) => _gameRepository = gameRepository;

    public List<Game> GetAllGames()
    {
        return _gameRepository.GetAllGames();
    }

    public Game GetGameByName(string name)
    {
        return _gameRepository.GetGameByName(name);
    }

    public void AddGame(NewGameDTO gameDTO)
    {
        if(gameDTO.Name == "" || gameDTO.Name == null){
            throw new Exception("Game cannot be added due to missing name.");
        }
        Game game = new Game ();
        game.Name = gameDTO.Name;

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
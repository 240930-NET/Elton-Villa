using P1.API.Model;
using P1.API.Model.DTO;

namespace P1.API.Service;

public interface IGameService
{
    public List<Game> GetAllGames();
    public Game GetGameByName(string name);
    public void AddGame(NewGameDTO gameDTO);
    public void DeleteGameByName(string name);
}
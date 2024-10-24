using Microsoft.AspNetCore.Mvc;
using P1.API.Model;
using P1.API.Model.DTO;
using P1.API.Service;

namespace P1.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService) => _gameService = gameService;

    [HttpGet("GetGames")]
    public IActionResult GetAllGames()
    {
        var games = _gameService.GetAllGames();
        return Ok(games);
    }

    [HttpGet("GetGame/{name}")]
    public IActionResult GetGameByName(string name)
    {
        var game = _gameService.GetGameByName(name);
        if(game == null){
            return BadRequest("Could not find a game by that name.");
        }
        return Ok(game);
    }

    [HttpPost("AddGame")]
    public IActionResult AddGame([FromBody] NewGameDTO gameDTO){

        try{
            _gameService.AddGame(gameDTO);
            return Ok("Game added.");
        }
        catch(Exception e){
            return BadRequest("Could not add game: " + e.Message);
        }
    }

    [HttpDelete("DeleteGame/{name}")]
    public IActionResult DeleteGameByName(string name){
        try{
            _gameService.DeleteGameByName(name);
            return Ok("Game deleted.");
        }
        catch(Exception e){
            return BadRequest("Could not delete game: " + e.Message);
        }
    }
}
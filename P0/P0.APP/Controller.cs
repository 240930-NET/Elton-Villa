using System.Text.Json;

public static class Controller{
    const string FILE_PATH = "games.txt";

    public static void CreateGame(){
        Game createdGame = UI.GetUserGame();

        string dataFromFile = FileReader.ReadFile(FILE_PATH);
        List<Game>? games = JsonSerializer.Deserialize<List<Game>>(dataFromFile);

        games.Add(createdGame);
        Console.WriteLine("Game named " + createdGame.Name + " was created and stored.\n");
        
        string jsonString = JsonSerializer.Serialize(games);
        FileWriter.WriteFile(FILE_PATH, jsonString);
    }

    public static void DeleteGame(){
        string dataFromFile = FileReader.ReadFile(FILE_PATH);
        List<Game>? games = JsonSerializer.Deserialize<List<Game>>(dataFromFile);

        Console.WriteLine("Please enter the name of the game(s) you would like to delete.\n");
        string? gameToDelete = Console.ReadLine();
        int removed = games.RemoveAll(game => game.Name == gameToDelete);
        if(removed == 0){
            Console.WriteLine("No games were found with that name. No game was deleted.\n");
        }

        string jsonString = JsonSerializer.Serialize(games);
        FileWriter.WriteFile(FILE_PATH, jsonString);
    }

    public static void EditGame(){
        string dataFromFile = FileReader.ReadFile(FILE_PATH);
        List<Game>? games = JsonSerializer.Deserialize<List<Game>>(dataFromFile);

        Console.WriteLine("Please enter the name of the game you would like to edit.\n");
        string? gameToEdit = Console.ReadLine();
        int index = games.FindIndex(game => game.Name == gameToEdit);
        if(index == -1){
            Console.WriteLine("No games were found with that name.\n");
        }
        else{
            Console.WriteLine("Editing game... please enter all the new values.\n");
            games[index] = UI.GetUserGame();
        }

        string jsonString = JsonSerializer.Serialize(games);
        FileWriter.WriteFile(FILE_PATH, jsonString);
    }

    public static void PlayGame(){
        //Pick game from file
        //Perform M.A.S.H. algorithm
    }
}
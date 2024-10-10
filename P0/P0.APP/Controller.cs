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
        string dataFromFile = FileReader.ReadFile(FILE_PATH);
        List<Game>? games = JsonSerializer.Deserialize<List<Game>>(dataFromFile);
        Console.WriteLine("Games available to play:");
        foreach(var game in games){
            Console.WriteLine("-" + game.Name);
        }

        Console.WriteLine("Please enter the name of the game you would like to play.\n");
        string? gameToPlay = Console.ReadLine();
        int index = games.FindIndex(game => game.Name == gameToPlay);
        if(index == -1){
            Console.WriteLine("No games were found with that name.\n");
        }
        else{
            Console.WriteLine("Let's play M.A.S.H.!\n");
            Console.WriteLine("Please enter a magic number between 3-10 to play.");
            int steps = Convert.ToInt32(Console.ReadLine());

            MASHAlgorithm(games[index], steps);
        }
    }

    public static void MASHAlgorithm(Game gameToPlay, int steps){
        //Keep track of traversal through different categories
        int remainingSteps = steps;

        while(gameToPlay.isGameMashable()){
            foreach(var category in gameToPlay.Categories){
                if(category.Options.Count == 1){
                    //Skip over this category, no spaces were taken
                }
                else if(category.Options.Count < remainingSteps){
                    //Account for spaces taken through this category
                    remainingSteps -= category.Options.Count;
                }
                else if(category.Options.Count >= remainingSteps){
                    //Make sure you eliminate all options possible within this category
                    for(int i = remainingSteps-1; i <= category.Options.Count - 1; i += steps - 1){
                        category.Options.RemoveAt(i);
                        remainingSteps = steps - (category.Options.Count - i);
                    }
                }
            }
        }
        gameToPlay.PrintGameResults();
    }

}
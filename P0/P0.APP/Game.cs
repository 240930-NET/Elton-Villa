public class Game{

    public string? Name {get; set; }

    public List<Category>? Categories {get; set; }

    public Game(string? name, List<Category> categories){
        Name = name;
        Categories = categories;
    }

    public void PrintGame(){
        Console.WriteLine("\nGame: " + Name);
        foreach(var category in Categories){
            category.PrintCategory();
        };
    }

    public void PrintGameResults(){
        Console.WriteLine("Your M.A.S.H. game results are...");
        foreach(var category in Categories){
            Console.WriteLine("Your " + category.Title + " will be " + category.Options[0] + ".");
        };
        Console.WriteLine();
    }

    public bool isGameMashable(){
        foreach(var category in Categories){
            //If any category has more than one option, you can play MASH with this game
            if(category.Options.Count > 1){
                return true;
            }
        }

        return false;
    }
}
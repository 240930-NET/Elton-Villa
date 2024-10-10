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
    }
}
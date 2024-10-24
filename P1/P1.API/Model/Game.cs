namespace P1.API.Model;

public class Game{

    public int Id { get; set; }
    public string Name {get; set; } = "";
    public List<Category> Categories {get; set; } = [];

    public void PrintGame(){
        Console.WriteLine("\nGame: " + Name);
        foreach(var category in Categories){
            category.PrintCategory();
        };
    }
}
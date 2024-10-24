namespace P1.API.Model;

public class Category{

    public int CategoryId {get; set; }
    public string Title {get; set; } = "";
    public List<string> Options {get; set; } = [];

    public int GameId {get; set; }
    public required Game Game {get; set; }

    public void PrintCategory(){
        Console.WriteLine("\n---" + Title + "---");
        foreach(var option in Options){
            Console.WriteLine(option);
        };
    }
}
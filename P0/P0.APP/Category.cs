public class Category{

    public string? Title {get; set; }
    public List<string>? Options {get; set; }

    public Category(string title, List<string> options){
        Title = title;
        Options = options;
    }

    public void PrintCategory(){
        Console.WriteLine("\n---" + Title + "---");
        foreach(var option in Options){
            Console.WriteLine(option);
        };
    }
}
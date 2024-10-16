public static class UI{
    const int NUM_MENU_OPTIONS = 5;
    const int MAX_NUM_CATEGORIES = 10;

    public static void Greetings(){
        Console.WriteLine("\nWelcome! Let's play a game of M.A.S.H.!");
    }

    public static int MenuSelection(){
        Console.WriteLine(@"Please enter a number to make a selection...

1. Play M.A.S.H.
2. Add a game
3. Edit a game
4. Delete a game
0. Exit
        ");

        int selection = GetUserMenuOption();
        return selection;
    }

    public static int GetUserMenuOption(){
        int i = 0;
        string? input = Console.ReadLine();
        bool isInt = int.TryParse(input, out i); //TryParse returns false and sets i to 0 if conversion to int fails

        while(isInt == false || 0 > i || i >= NUM_MENU_OPTIONS){
            if(isInt == false){
                Console.Write("You did not enter a number. ");
            }
            Console.WriteLine($"Please enter a valid number between 0 and {NUM_MENU_OPTIONS-1}.");
            input = Console.ReadLine(); 
            isInt = int.TryParse(input, out i);
        }

        return i;
    }

    public static List<string> GetUserCategoryOptions(){
        Console.WriteLine("\nPlease enter all options for this category. (Separated by ,)");
        Console.WriteLine("e.g. Doctor, Lawyer, Clown\n");

        string[] userOptions = Console.ReadLine().Split(", ");
        while(userOptions.Length == 1 && userOptions[0] == ""){
            Console.WriteLine("Options cannot be empty.\n");
            userOptions = Console.ReadLine().Split(", ");
        }
        List<string> listOptions = [.. userOptions];
        return listOptions;
    }

    public static Category GetUserCategory(){
        Console.WriteLine("\nPlease enter the title of this category!");
        Console.WriteLine("e.g. Job, Car, Number of Kids\n");
        string? title = Console.ReadLine();

        while(title == ""){
            Console.WriteLine("Title cannot be empty.\n");
            title = Console.ReadLine();
        }

        List<string>? options = GetUserCategoryOptions();
        
        Category userCategory = new Category(title, options);
        return userCategory;
    }

    public static Game? GetUserGame(){
        Console.WriteLine("\nPlease enter the name of this game!\n");
        string? name = Console.ReadLine();

        while(name == ""){
            Console.WriteLine("Name cannot be empty.\n");
            return null;
        }

        Console.WriteLine("\nHow many categories would you like to add?\n");
        string? numberOfCategories = Console.ReadLine();

        int i = 0;
        bool isInt = int.TryParse(numberOfCategories, out i); //TryParse returns false and sets i to 0 if conversion to int fails

        while(isInt == false || 1 > i || i > MAX_NUM_CATEGORIES){
            if(isInt == false){
                Console.Write("You did not enter a number. ");
            }
            Console.WriteLine($"Please enter a valid number between 1 and {MAX_NUM_CATEGORIES}.");
            numberOfCategories = Console.ReadLine(); 
            isInt = int.TryParse(numberOfCategories, out i);
        }

        List<Category>? categories = new List<Category>();

        while(i > 0){
            Category temp = UI.GetUserCategory();
            categories.Add(temp);
            i -= 1;
        }

        Game userGame = new Game(name, categories);
        return userGame;
    }
}
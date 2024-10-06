public static class UI{
    const int NUM_MENU_OPTIONS = 5;

    public static void Greetings(){
        Console.WriteLine("\nWelcome [Player]! Let's play a game of M.A.S.H.!");
    }

    public static int MenuSelection(){
        Console.WriteLine(@"Please enter a number to make a selection...

1. Play M.A.S.H.
2. Edit a category
3. Add a category
4. Delete a category
0. Exit
        ");

        //Change to GetUserInt method
        int selection = GetUserInt();
        return selection;
    }

    public static int GetUserInt(){
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
}
class Program{
    static void Main(string[] args){
        Console.WriteLine("Let's play Rock, Paper, Scissors!\n");
        Console.WriteLine("Please enter a number to pick rock, paper, or scissors...");
        Console.WriteLine("1)Rock\n2)Paper\n3)Scissors\n");

        //User picks rock, paper, or scissors
        int selectionInt = Convert.ToInt32(Console.ReadLine());
        string selectionString = ConvertSelection(selectionInt);

        //Enemy player picks rock, paper, or scissors
        Random random = new Random();
        int enemyInt = random.Next(1,4);
        string enemyString = ConvertSelection(enemyInt);

        Console.WriteLine($"\nYou picked {selectionString} and your opponent picked {enemyString}!");

        switch(selectionInt){
            case 1:
                if(enemyInt == 3){
                    Console.WriteLine("You win!");
                }
                else{
                    Console.WriteLine("Try again...");
                }
                break;
            case 2:
                if(enemyInt == 1){
                    Console.WriteLine("You win!");
                }
                else{
                    Console.WriteLine("Try again...");
                }
                break;
            case 3:
                if(enemyInt == 2){
                    Console.WriteLine("You win!");
                }
                else{
                    Console.WriteLine("Try again...");
                }
                break;
        }
    }

    static string ConvertSelection (int n){
        string s = "nothing";
        if(n == 1){
            s = "rock";
        }
        else if(n == 2){
            s = "paper";
        }
        else if(n == 3){
            s = "scissors";
        }
        return s;
    }
}
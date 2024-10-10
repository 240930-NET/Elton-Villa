namespace P0.APP;

class Program
{
    static void Main(string[] args)
    {
        UI.Greetings();
        int selection = UI.MenuSelection();

        while(selection != 0){
            switch(selection){
                case 1:
                    //Play M.A.S.H.
                    break;
                case 2:
                    //Add game
                    Controller.CreateGame();
                    break;
                case 3:
                    //Edit game
                    Controller.EditGame();
                    break;
                case 4:
                    //Delete game
                    Controller.DeleteGame();
                    break;
                
            }
            selection = UI.MenuSelection();
        }
    }
}

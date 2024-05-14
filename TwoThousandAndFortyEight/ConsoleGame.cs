using System;
class ConsoleGame
{
    private Game game;

    public ConsoleGame(int n)
    {
        game = new Game(n);
        game.ResetGame();
    }

    public void MainGame()
    {
        while(game.GetGameStatus() == Globals.GameStatus.Idle)
        {
            GamePrintOut();
            Console.WriteLine("Press one of the arrow keys to choose which direction you want to move the board");
            while(!GetAndProcessInput())
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Press one of the arrow keys to choose which direction you want to move the board");
            }
        }
        if(game.GetGameStatus() == Globals.GameStatus.Lose)
        {
            GamePrintOut();
            Console.WriteLine("GAME OVER :(");
            Console.WriteLine("To play again press enter");
        }

        if(game.GetGameStatus() == Globals.GameStatus.Win)
        {
            Console.WriteLine("YOU WIN !!");
            Console.WriteLine("To continue playing press enter");
        }
    }

    public void GamePrintOut()
    {   
        Console.WriteLine(game.ToString());
    }

    public bool GetAndProcessInput()
    {
        ConsoleKey pressedKey = Console.ReadKey().Key;
        if(Enum.IsDefined(typeof(Globals.Direction), (Globals.Direction)pressedKey)){
            game.Move((Globals.Direction)pressedKey);
            return true;
        }
        else if(pressedKey == ConsoleKey.Enter)
        {
            if(game.GetGameStatus() == Globals.GameStatus.Lose)
            {
                game.ResetGame();
            }
            else if(game.GetGameStatus() == Globals.GameStatus.Win)
            {
                game.FreePlayMode();
            }
        }
        return false;
    }
}
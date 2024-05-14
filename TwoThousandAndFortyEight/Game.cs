class Game
{
    private Board gameBoard;
    private Globals.GameStatus gameStatus;
    private int points;

    public Game(int n)
    {
        gameStatus = Globals.GameStatus.Idle;
        points = 0;
        gameBoard = new Board(n);
    }

    public override string ToString()
    {
        string st = gameBoard.ToString();
        st += $"points: {points}";
        return st;
    }

    public void ResetGame()
    {
        points = 0;
        gameStatus = Globals.GameStatus.Idle;
        gameBoard.IntialiseBoard();
    }

    public void FreePlayMode()
    {
        gameStatus = Globals.GameStatus.FreePlay;
    }

    public Globals.GameStatus GetGameStatus()
    {
        return gameStatus;
    }

    public void Move(Globals.Direction direction)
    {
        if(gameStatus != Globals.GameStatus.Lose)
        {
            points += gameBoard.Move(direction);
            if(gameStatus != Globals.GameStatus.FreePlay && gameBoard.Contains(2048))
            {
                gameStatus = Globals.GameStatus.Win;
            }

            else if(!gameBoard.IsSpacesLeft() && !gameBoard.IsMatchingAdjcents())
            {
                gameStatus = Globals.GameStatus.Lose;
            }
        }
    }

    public int GetPoints()
    {
        return points;
    }
}
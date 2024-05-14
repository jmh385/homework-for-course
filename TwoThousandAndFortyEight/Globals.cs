using System;
static class Globals
{
    public enum Direction
    {
        Left = ConsoleKey.LeftArrow,
        Up = ConsoleKey.UpArrow,
        Right = ConsoleKey.RightArrow,
        Down = ConsoleKey.DownArrow
    }

    public enum GameStatus
    {
        Win,
        Lose,
        Idle,
        FreePlay
    }
}
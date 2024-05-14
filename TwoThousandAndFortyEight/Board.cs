using System.Collections.Generic;
using System.Linq;
using System;
class Board
{
    private int[,] numBoard;
    private int n; 

    public Board(int n)
    {
        // marks the dimension of the board
        numBoard = new int[n, n];
        this.n = n;

    }

    public override string ToString()
    {
        string st = "";
        for (int row = 0; row < numBoard.GetLength(0); row++)
        {
            st += "|";
            for (int col = 0; col < numBoard.GetLength(0); col++)
            {
                st += $"{numBoard[row, col],5}|";
            }
            st += "\n--------------------\n";            
        }
        return st;
    }

    public void IntialiseBoard()
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                numBoard[row, col] = 0;
            }
        }

        Random random = new Random();
        int rolledRow = random.Next(n);
        int rolledCol = random.Next(n);

        numBoard[rolledRow, rolledCol] = (int)Math.Pow(2, random.Next(1, 3));
        rolledRow = random.Next(n);
        rolledCol = random.Next(n);

        while(numBoard[rolledRow, rolledCol] != 0)
        {        
            rolledRow = random.Next(n);
            rolledCol = random.Next(n);
        }
        numBoard[rolledRow, rolledCol] = (int)Math.Pow(2, random.Next(1, 3));
    }

    private int MoveArr(int[] arr)
    {
        // Array.ForEach(arr, Console.Write);
        // Console.WriteLine();
        int pointsGained = 0;
        int lastFreeSpot = 0;
        int pos = 0;
        while(pos < n)
        {
            while(pos < n && arr[pos] == 0) // find next number to push back
            {
                pos++;
            }

            if(pos != n) // if we found a number we must push it back to last open slot
            {
                //first check if there is a number to combine with it
                int testPos = pos+1;
                while(testPos < n && arr[testPos] == 0)
                {
                    testPos++;
                }

                if(testPos != n && arr[testPos] == arr[pos]) // if we found a number combine them
                {
                    arr[pos] *= 2;
                    arr[testPos] = 0;
                    pointsGained += arr[pos];
                }

                if(lastFreeSpot != pos) // if it is not already there move back number to last open spot
                {
                    arr[lastFreeSpot] = arr[pos];
                    arr[pos] = 0;
                }

                lastFreeSpot++; //the next open spot has now been moved one forward as the current one has just been populated
                pos = testPos; // we can start looking from where we found the next number closest to the first
            }
        }
        // Array.ForEach(arr, Console.Write);
        // Console.WriteLine();
        return pointsGained;
    }
    public int Move(Globals.Direction direction)
    {
        int pointsGained = 0;
        int[] tempArr = new int[n];
        switch(direction)
        {
            case Globals.Direction.Left:
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        tempArr[col] = numBoard[row, col];
                    }

                    pointsGained += MoveArr(tempArr);
                    
                    for (int col = 0; col < n; col++)
                    {
                        numBoard[row, col] = tempArr[col];
                    }
                }
                break;

            case Globals.Direction.Down:
                for (int col = 0; col < n; col++)
                {
                    for (int row = 0; row < n; row++)
                    {
                        tempArr[n-1-row] = numBoard[row, col];
                    }

                    pointsGained += MoveArr(tempArr);
                    
                    for (int row = 0; row < n; row++)
                    {
                        numBoard[row, col] = tempArr[n-1-row];
                    }
                }
                break;

            case Globals.Direction.Right:
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        tempArr[n-1-col] = numBoard[row, col];
                    }

                    pointsGained += MoveArr(tempArr);
                    
                    for (int col = 0; col < n; col++)
                    {
                        numBoard[row, col] = tempArr[n-1-col];
                    }
                }
                break;
            
            case Globals.Direction.Up:
                for (int col = 0; col < n; col++)
                {
                    for (int row = n-1; row >= 0; row--)
                    {
                        tempArr[row] = numBoard[row, col];
                    }

                    pointsGained += MoveArr(tempArr);
                    
                    for (int row = 0; row < n; row++)
                    {
                        numBoard[row, col] = tempArr[row];
                    }
                }
                break;
        
        }
        List<int[]> freeSpaces = GetFreeSpaces();
        int Length = freeSpaces.Count;
        if(Length > 0 )
        {
            Random random = new();
            int posInList = random.Next(Length);
            int[] coordinates = freeSpaces[posInList];
            numBoard[coordinates[0], coordinates[1]] = (int)Math.Pow(2, random.Next(1, 3));
        }


        return pointsGained;
    }

    public List<int[]> GetFreeSpaces()
    {
        //finds all free spaces without tiles
        List<int[]> freeSpaces = [];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if(numBoard[row, col] == 0)
                {
                    
                    freeSpaces.Add([row, col]);
                }
            }
        }
        return freeSpaces;
    }

    public bool IsSpacesLeft()
    {
        List<int[]> freeSpaces = GetFreeSpaces();
        return freeSpaces.Count() != 0;
    }

    public bool IsMatchingAdjcents()
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if((row > 0 && numBoard[row-1, col] == numBoard[row, col])
                    || (row < n-1 && numBoard[row+1, col] == numBoard[row, col])
                    || (col > 0 && numBoard[row, col-1] == numBoard[row, col]) 
                    || (col < n-1 && numBoard[row, col+1] == numBoard[row, col]))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool Contains(int num)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if(numBoard[row, col] == num)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public int[,] GetNumBoard()
    {
        return numBoard;
    }
}
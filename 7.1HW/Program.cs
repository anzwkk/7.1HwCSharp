using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';
    static void Main()
    {
        int move;
        bool gameRunning = true;
        while (gameRunning)
        {
            PrintBoard();
            Console.Write($"Гравець {currentPlayer}, виберіть клітинку (1-9): ");
            if (int.TryParse(Console.ReadLine(), out move))
            {
                if (move >= 1 && move <= 9)
                {
                    if (board[move - 1] == (char)(move + '0'))
                    {
                        board[move - 1] = currentPlayer;

                        if (CheckWin())
                        {
                            PrintBoard();
                            Console.WriteLine($"Переміг гравець {currentPlayer}!");
                            gameRunning = false;
                        }    
                    }

                }
            }    

        }
    }
    static bool CheckWin()
    {
        int[,] win = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
            {0, 4, 8}, {2, 4, 6}
        };

        for (int i = 0; i < win.GetLength(0); i++)
        {
            if (board[win[i, 0]] == currentPlayer &&
                board[win[i, 1]] == currentPlayer &&
                board[win[i, 2]] == currentPlayer)
            {
                return true;
            }
        }
        return false;
    }
    static void PrintBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }
}


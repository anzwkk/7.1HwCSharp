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
            Console.Write($"Гравець {currentPlayer}, виберіть клітинку (1-9): ");
            if (int.TryParse(Console.ReadLine(), out move))
            {
                if (move >= 1 && move <= 9)
                {
                    if (board[move - 1] == (char)(move + '0'))
                    {
                        board[move - 1] = currentPlayer;
                    }

                }
            }    

        }
    }
}


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
            Console.Clear();
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
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine($"Переміг гравець {currentPlayer}!");
                            gameRunning = false;
                        }
                        else
                        {
                            bool allFilled = true;
                            foreach (char cell in board)
                            {
                                if (cell == '1' || cell == '2' || cell == '3' || cell == '4' ||
                                    cell == '5' || cell == '6' || cell == '7' || cell == '8' ||
                                    cell == '9')
                                {
                                    allFilled = false;
                                    break;
                                }
                            }

                            if(allFilled)
                            {
                                Console.Clear();
                                PrintBoard();
                                Console.WriteLine("Нічия!");
                                gameRunning = false;
                            }
                            else
                            {
                                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                            }    
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ця клітинка вже зайнята. Спробуйте іншу");
                    }
                }
                else
                {
                    Console.WriteLine("Некоректний ввід. Виберіть клітинку від 1 до 9");
                }

            }
            else
            {
                Console.WriteLine("Некоректний ввід. Виберіть клітинку від 1 до 9");
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


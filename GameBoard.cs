using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class GameBoard
    {
        //поле 3х3
        private char[,] board;

        public GameBoard()
        {
            board = new char[3, 3];
            Clear();
        }

        //Очистка поля
        public void Clear()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        //само поле
        public void Show()
        {
            Console.WriteLine("=== Крестики-Нолики ===");
            //номера столбцов и верхняя граница

            Console.WriteLine("    1   2   3 ");
            Console.WriteLine("  ╠═══╬═══╬═══╣");

            for (int row = 0; row < 3; row++)
            {
                Console.Write($"  ║");
                for (int col = 0; col < 3; col++)
                {
                    char cell = board[row, col];
                    Console.Write(cell == ' ' ? "   " : $" {cell} ");

                    if (col < 2) 
                        Console.Write("║");
                }
                Console.WriteLine($"║{row + 1}");

                if (row < 2)
                    Console.WriteLine("  ╠═══╬═══╬═══╣");
            }
            Console.WriteLine("  ╚═══╩═══╩═══╝");
        }

        //ход
        public bool Move(int row, int col, char symbol)
        {
            //проверка, корды ли в пределах поля
            if (row < 0 || row > 2 || col < 0 || col > 2)
                return false;

            //проверка пустой клетки
            if (board[row, col] != ' ')
                return false;

            //ставим символ
            board[row, col] = symbol;
            return true;
        }

        //проверка победы
        public bool CheckWin(char symbol)
        {
            //проверка строк
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == symbol && 
                    board[row, 1] == symbol &&
                    board[row, 2] == symbol)
                    return true;
            }

            //проверка столбцов
            for (int col = 0; col < 3; col++)
            {
                if (board[col, 0] == symbol &&
                    board[col, 1] == symbol &&
                    board[col, 2] == symbol)
                    return true;
            }
            
            //проверка диагоналей
            if (board[0, 0] == symbol && 
                board[1, 1] == symbol && 
                board[2, 2] == symbol)
                return true;

            if (board[0, 2] == symbol && 
                board[1, 1] == symbol && 
                board[2, 0] == symbol)
                return true;

            return false;
        }

        public bool isFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                        return false;
                }
            }
            return true;
        }
    }
}

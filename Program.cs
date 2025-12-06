namespace ConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Крестики-Нолики ===");

            //создаем игроков
            Player player1 = new Player("Игрок 1", 'X');
            Player player2 = new Player("Игрок 2", 'O');

            GameBoard board = new GameBoard();

            //текущий игрок
            Player currentPlayer = player1;

            //основной игровой цикл
            bool gameOver = false;

            while (!gameOver)
            {
                board.Show();

                //ход игрока
                bool move = false;
                while (!move)
                {
                    Console.WriteLine($"{currentPlayer.Name} - {currentPlayer.Symbol}: Ваш ход.");

                    //получаем корды от игрока
                    int row = GetCord("строку");
                    int col = GetCord("столбец");

                    //делаем ход
                    move = board.Move(row - 1, col - 1, currentPlayer.Symbol);

                    if (!move)
                    {
                        Console.WriteLine("Ошибка! Попробуй сделать ход снова.");
                    }
                }


                //победа или нет
                if (board.CheckWin(currentPlayer.Symbol))
                {
                    board.Show();
                    Console.WriteLine($"Поздравляем с победой {currentPlayer.Name} - ({currentPlayer.Symbol})!");
                    gameOver = true;
                }
                //ничья или нет?
                else if (board.isFull())
                {
                    board.Show();
                    Console.WriteLine("Ничья! Ваше игровое поле заполнено.");
                    gameOver = true;
                }
                //меняем игрока
                else
                {
                    currentPlayer = (currentPlayer == player1) ? player1 : player2;
                }
            }

            Console.WriteLine("\nИгра окончена!");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        //метод чтобы получить корды от игрока
        static int GetCord(string cordName)
        {
            int number;

            while (true)
            {
                Console.Write($"Введите номер {cordName} (от 1 до 3): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number) && number >= 1 && number <= 3)
                {
                    return number;
                }

                Console.WriteLine("Ошибка! Введите число от 1 до 3.");
            }
        }
    }
}

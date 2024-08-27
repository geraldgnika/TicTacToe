using System;
using System.Linq;

namespace TicTacToe
{
    internal class Program
    {
        public static string[,] board = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        public static bool is_over = false;
        public static int turn = 1;
        public static string sign = null;
        public static bool first_time = true;

        static void Main(string[] args)
        {
            print_board();
            
            while (!is_over) {
                check_if_over();

                if (is_over)
                {
                    break;
                }

                Console.WriteLine();

                Console.WriteLine("Type 'e' and press ENTER anytime you want to exit the console.");

                Console.WriteLine();

                if (first_time)
                {
                    Console.WriteLine("Player " + turn + ": Choose your field!");
                } else
                {
                    Console.WriteLine("Player " + turn + ": Your turn!");
                }

                sign = turn == 1 ? "X" : "O";

                string player_input = Console.ReadLine();

                if (player_input == "e")
                {
                    Environment.Exit(0);
                }

                int position = int.Parse(player_input) - 1;
                int row = position / 3;
                int col = position % 3;

                board[row, col] = sign;
                first_time = false;

                Console.Clear();
                print_board();

                turn = turn == 1 ? 2 : 1;
            }

            Console.Read();
        }

        public static void print_board()
        {
            string separator = " -------------------------";
            string emptyRow = " |       |       |       |";

            Console.WriteLine(separator);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(emptyRow);
                Console.Write(" |   ");

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + "   |   ");
                }

                Console.WriteLine();
                Console.WriteLine(emptyRow);
                Console.WriteLine(separator);
            }
        }

        public static void check_if_over()
        {
            for (int i = 0; i < 3; i++)
            {
                if (are_equal(board[i, 0], board[i, 1], board[i, 2]) ||
                    are_equal(board[0, i], board[1, i], board[2, i]))
                {
                    announce_winner();
                    return;
                }
            }

            if (are_equal(board[0, 0], board[1, 1], board[2, 2]) ||
                are_equal(board[0, 2], board[1, 1], board[2, 0]))
            {
                announce_winner();
            }
        }

        private static bool are_equal(params string[] values)
        {
            return values.All(v => v == values[0]);
        }

        public static void announce_winner()
        {
            is_over = true;

            Console.Clear();
            Console.WriteLine(sign == "X" ? "Player 1 is the Winner!!!" : "Player 2 is the winner!!!");
            Console.WriteLine("Press ENTER to exit.");
        }
    }
}

using MineSweeperClasses;

namespace MineSweeperConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to Minesweeper");
            // size 10 and difficulty 0.1
            Board board = new Board(10, 0.1f);
            Console.WriteLine("Here is the answer key for the first board.");
            PrintAnswers(board);

            // Size 15 and difficulty 0.15
            board = new Board(15, 0.15f);
            Console.WriteLine("Here is the answer key for the second board.");
            PrintAnswers(board);


        }
        // Method to print the board answers
        static void PrintAnswers(Board board)
        {
            // Print column numbers
            Console.WriteLine(" ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write(" " + col);
            }
            Console.WriteLine();

            // Print divider line
            Console.WriteLine(new string('-', board.Size * 2 + 3));

            // Print the rows and cells
            for (int row = 0; row < board.Size; row++)
            {
                // Print row number
                Console.Write($"{row}| ");
                // Print the cells
                for (int col = 0; col < board.Size; col++)
                {
                    // Print the bomb if it is a bomb
                    if (board.Cells[row, col].IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B ");
                    }
                    // Print the number 1-8 if it is not a bomb
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else if (board.Cells[row, col].NumberOfBombNeighbors == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"{board.Cells[row, col].NumberOfBombNeighbors} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(". ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', board.Size * 2 + 3));
        }
    }
}

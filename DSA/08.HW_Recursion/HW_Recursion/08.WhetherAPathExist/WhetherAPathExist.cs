using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.WhetherAPathExist
{
    class WhetherAPathExist
    {
        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();
        private static char[,] lab;

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                Console.WriteLine("Exit found!");
                Environment.Exit(0);
            }

            if (lab[row, col] != ' ')
            {
                return;
            }

            lab[row, col] = 's';
            path.Add(new Tuple<int, int>(row, col));

            // Invoke recursion the explore all possible directions
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down

            // Mark back the current cell as free
            // Comment the below line to visit each cell at most once
            lab[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath(int finalRow, int finalCol)
        {
            Console.Write("Found the exit: ");
            foreach (var cell in path)
            {
                Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
            }
            Console.WriteLine("({0},{1})", finalRow, finalCol);
            Console.WriteLine();
        }

        private static bool ValidatePoint(int pointRow, int pointCol)
        {
            if (!InRange(pointRow, pointCol))
            {
                Console.WriteLine("The point is out of the labyrinth");
                return false;
            }
            if (lab[pointRow, pointCol] != ' ')
            {
                Console.WriteLine("Try put point to the non-passable cell");
                return false;
            }

            return true;
        }

        static void Main()
        {
            int size = 100;
            lab = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    lab[row, col] = ' ';
                }
            }

            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    Console.Write("|{0}|",lab[i,j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Enter coordinate to start: ");
            Console.Write("Enter row: ");
            int startPRow=int.Parse(Console.ReadLine());
            Console.Write("Enter col: ");
            int startPCol = int.Parse(Console.ReadLine());
            bool validStart = ValidatePoint(startPRow, startPCol);

            Console.WriteLine("Enter coordinate to end: ");
            Console.Write("Enter row: ");
            int endPRow = int.Parse(Console.ReadLine());
            Console.Write("Enter col: ");
            int endPCol = int.Parse(Console.ReadLine());
            bool validEnd = ValidatePoint(endPRow, endPCol);          
            
            
            if (startPRow == endPRow && startPCol == endPCol)
            {
                Console.WriteLine("Start and end cells shoud be different.");
                return;
            }
            if (validStart && validEnd)
            {
                lab[endPRow, endPCol] = 'e';
                FindPathToExit(startPRow, startPCol);
            }
            
        }
    }
}

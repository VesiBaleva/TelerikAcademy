using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AllAreasOfPassableCells
{
    class AllAreasOfPassableCells
    {
        static char[,] lab = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', '*'},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', '*', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', '*', ' ', 'e'},
        };

        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        private static bool[,] visited;

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static int FindConnectedArea(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return 0;
            }

            if (lab[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return 0;
            }

            if (visited[row, col])
            {
                // The current cell has already been visited
                return 0;
            }

            visited[row, col] = true;
            int count = 1;


            // Invoke recursion the explore all possible directions
            count += FindConnectedArea(row, col - 1); // left
            count += FindConnectedArea(row - 1, col); // up
            count += FindConnectedArea(row, col + 1); // right
            count += FindConnectedArea(row + 1, col); // down

            return count;
        }

        static void Main()
        {
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    Console.Write("|{0}|", lab[i, j]);
                }
                Console.WriteLine();
            }

            int rowsCount = lab.GetLength(0);
            int colsCount = lab.GetLength(1);

            visited = new bool[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (lab[row, col] == ' ' && !visited[row, col])
                    {
                        int count = FindConnectedArea(row, col);

                        Console.WriteLine("The area contains {0} empty cells.", count);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Salaries
{
    class Program
    {
        static bool[,] adjMatrix;
        static long[] cashe;

        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());

            adjMatrix = new bool[nodes, nodes];
            cashe = new long[nodes];

            for (int i = 0; i < nodes; i++)
            {
                string connections = Console.ReadLine();

                for (int j = 0; j < connections.Length; j++)
                {
                    if (connections[j] == 'Y')
                    {
                        adjMatrix[i, j] = true;
                    }
                }
            }

            long sumOfSalaries = 0;

            for (int i = 0; i < nodes; i++)
            {
                sumOfSalaries += FindSalary(i,nodes);
            }

            Console.WriteLine(sumOfSalaries);
        }

        static long FindSalary(int employee,int nodes)
        {
            if (cashe[employee] > 0)
            {
                return cashe[employee];
            }

            long salary = 0;

            for (int i = 0; i < nodes; i++)
            {
                if (adjMatrix[employee,i])
                {
                    salary += FindSalary(i,nodes);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }
            cashe[employee] = salary;
            return salary;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AcademyTasks
{
    class Program
    {
        static List<int> tasks = new List<int>();
        static int variaty = int.MinValue;
        static int solvedTasks = 0;
        static int bestSolution=int.MaxValue;
        static int maxIndex;

        static void Main()
        {
            string taskAsString = Console.ReadLine();
            string[] tasksAsArray = taskAsString.Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in tasksAsArray)
            {
                tasks.Add(int.Parse(item));
            }

            variaty = int.Parse(Console.ReadLine());

            int currentMin = tasks[0];
            int currentMax = tasks[0];
            bestSolution = tasks.Count;

            maxIndex = -1;

            for (int i = 0; i < tasks.Count; i++)
            {
                currentMin = Math.Min(currentMin, tasks[i]);
                currentMax = Math.Max(currentMax, tasks[i]);
                if (Math.Abs(currentMax - currentMin) >= variaty)
                {
                    maxIndex = i;
                    break;
                }
            }
            if (maxIndex == -1)
            {
                Console.WriteLine(tasks.Count);
                return;
            }


            Solve(0,tasks[0],tasks[0],1);
            Console.WriteLine(bestSolution);
        }

        static void Solve(int start,int currentMin, int currentMax,int solvedTasks)
        {
            if (Math.Abs(currentMax - currentMin) >= variaty)
            {

                bestSolution = Math.Min(bestSolution, solvedTasks);

                return;
            }

            if (start >= maxIndex)
            {
                return;
            }

            
            for (int i = 2; i >= 1; i--)
            {
                if (start + i < tasks.Count)
                {
                    Solve(start + i, Math.Min(currentMin,tasks[start+i]), Math.Max(
                        currentMax,tasks[start+i]), solvedTasks + 1);
                    if (bestSolution != tasks.Count)
                    {
                        return;
                    }
                }
            }
        }

    }
}

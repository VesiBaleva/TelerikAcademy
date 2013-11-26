using System;

    class OddNumber
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());

            long x, findNumber = 0;
            
            for (int i = 0; i < n; i++)
            {
                x = long.Parse(Console.ReadLine());
                findNumber ^= x;
            }

             Console.WriteLine(findNumber);
        }
    }


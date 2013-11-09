using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            
            long keys = pass.Count(x => x == '*');

            long answer = 1;

            for (int i = 1; i <=keys; i++)
            {
                answer *= 2;
            }

            Console.WriteLine(answer);
            
            
        }
    }
}

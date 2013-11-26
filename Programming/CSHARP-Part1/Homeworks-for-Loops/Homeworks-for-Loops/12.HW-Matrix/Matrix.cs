using System;

class Matrix
{
    static void Main()
    {
        int number;
        do
        {
            Console.Write("Enter number from 1 to 20: ");
            number = int.Parse(Console.ReadLine());
        } while (number <= 0);
        for (int i = 1; i <= number; i++)
        {
            for (int j = i; j < number + i; j++)
            {
                Console.Write("---");           
               
            }
            Console.Write("-");
            Console.WriteLine();
            Console.Write("|");
            for (int j = i; j < number+i; j++)
            {

                if (j <= 9)
                {
                    Console.Write(j + " |");
                }
                else
                {
                    Console.Write(j + "|");
                }

            }

            Console.WriteLine();
        }
        for (int i = 1; i <= number; i++)
        {
            Console.Write("---");
        }
        Console.WriteLine("-");
    }
}


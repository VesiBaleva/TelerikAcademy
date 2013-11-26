using System;

class Print1toN
{
    static void Main()
    {
        Console.Write("Enter any number N greater then or equal 1  - ");
        int n = int.Parse(Console.ReadLine());
        if (n >= 1)
        {
            int counter = 1;
            do
            {
                Console.Write(counter + " ");
                counter++;
            } while (counter <= n);
        }
        else
        {
            Console.WriteLine("End program without any calculations !!!");
        }
    }
}

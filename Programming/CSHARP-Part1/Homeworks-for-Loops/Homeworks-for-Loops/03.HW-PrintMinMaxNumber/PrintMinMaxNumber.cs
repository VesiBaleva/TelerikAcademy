using System;

class PrintMinMaxNumber
{
    static void Main()
    {
        int n=1;
        Console.WriteLine("Enter 10 numbers!");
        Console.WriteLine("Enter number: ");
        int num = int.Parse(Console.ReadLine());
        int min = num;
        int max = num;      
        do
        {
            num = int.Parse(Console.ReadLine());
            if (min>num)
            {
                min=num;
            }
            if (max<num)
            {
                max=num;
            }
            n++;
        } while(n<=9);
        Console.WriteLine("Minimum number is {0}",min);
        Console.WriteLine("Maximum number is {0}",max);
    }
}

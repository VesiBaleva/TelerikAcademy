using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        byte a1 = byte.Parse(Console.ReadLine());
        byte a2 = byte.Parse(Console.ReadLine());
        byte a3 = byte.Parse(Console.ReadLine());
        byte a4 = byte.Parse(Console.ReadLine());
        byte a5 = byte.Parse(Console.ReadLine());
        int temp = 0;
        int i;
        uint maxMultiple =(uint)( a1 * a2 * a3 * a4 * a5);
        for (i = 1; i <= maxMultiple; i++,temp=0)
        {
            if (i % a1 == 0) temp++;
            if (i % a2 == 0) temp++;
            if (i % a3 == 0) temp++;
            if (i % a4 == 0) temp++;
            if (i % a5 == 0) temp++;
            if (temp >= 3) break;
        }
        Console.WriteLine(i);
      
    }
}


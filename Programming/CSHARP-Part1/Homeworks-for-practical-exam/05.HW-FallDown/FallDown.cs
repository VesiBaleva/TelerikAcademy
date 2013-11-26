using System;

    class FallDown
    {
        static void Main()
        {
            int[] num = new int[8];
            for (int i = 0; i <= 7; i++)
                num[i] = int.Parse(Console.ReadLine());
            int k = 7;
            for (int i = 0; i <= 7; i++)
            {
                for (int p = 0; p <= 7; p++)
                {
                    int bit=(num[i] & (1<<p))>>p;
                    if (bit == 1)
                    {
                        int bit2=1;
                        k = 7;
                        do
                        {
                            bit2 = (num[k] & (1 << p)) >> p;
                            k--;
                        } while (bit2 == 1 && k>=i);
                        if ( k>=i && bit2==0)
                        {
                            num[i] = num[i] & (~(1 << p));
                            k++;
                            num[k]=num[k]|(1<<p);
                        }
                    }
                }
            }
            for (int i = 0; i <= 7;i++ )
                Console.WriteLine(num[i]);
        }
    }


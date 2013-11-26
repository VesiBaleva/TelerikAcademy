using System;

    class ShipDamage
    {
        static void Main()
        {
            int sx1 = int.Parse(Console.ReadLine());
            int sy1 = int.Parse(Console.ReadLine());
            int sx2 = int.Parse(Console.ReadLine());
            int sy2 = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int cx1 = int.Parse(Console.ReadLine());
            int cy1 = int.Parse(Console.ReadLine());
            int cx2 = int.Parse(Console.ReadLine());
            int cy2 = int.Parse(Console.ReadLine());
            int cx3 = int.Parse(Console.ReadLine());
            int cy3 = int.Parse(Console.ReadLine());
            int total = 0;
            int temp = 0;
            if (sx2 < sx1)
            {
                temp = sx2;
                sx2 = sx1;
                sx1 = temp;
            }
            if (sy2 > sy1)
            {
                temp = sy2;
                sy2 = sy1;
                sy1 = temp;
            }
            cy1 = 2 * h - cy1;
            cy2 = 2 * h - cy2;
            cy3 = 2 * h - cy3;
            if (sx1 < cx1 && cx1 < sx2)
            {
                if (sy2 < cy1 && cy1 < sy1)
                {
                    total += 100;
                }
                else if (sy2 == cy1 || cy1 == sy1)
                {
                    total += 50;
                }
                else
                    total+=0;
            }
            else if (sx1 == cx1 || cx1 == sx2)
            {
                    if (sy2 == cy1 || cy1 == sy1)
                    {
                        total += 25;
                    }
                    else if (sy2 < cy1 && cy1< sy1)
                    {
                        total += 50;
                    }
                    else
                        total+=0;
            }
                else
                    total+=0;
            if (sx1 < cx2 && cx2 < sx2)
            {
                if (sy2 < cy2 && cy2 < sy1)
                {
                    total += 100;
                }
                else if (sy2 == cy2 || cy2 == sy1)
                {
                    total += 50;
                }
                else
                    total += 0;
            }
            else if (sx1 == cx2 || cx2 == sx2)
            {
                if (sy2 == cy2 || cy2 == sy1)
                {
                    total += 25;
                }
                else if (sy2 < cy2 && cy2 < sy1)
                {
                    total += 50;
                }
                else
                    total += 0;
            }
            else
                total += 0;
            if (sx1 < cx3 && cx3 < sx2)
            {
                if (sy2 < cy3 && cy3 < sy1)
                {
                    total += 100;
                }
                else if (sy2 == cy3 || cy3 == sy1)
                {
                    total += 50;
                }
                else
                    total += 0;
            }
            else if (sx1 == cx3 || cx3 == sx2)
            {
                if (sy2 == cy3 || cy3 == sy1)
                {
                    total += 25;
                }
                else if (sy2 < cy3 && cy3 < sy1)
                {
                    total += 50;
                }
                else
                    total += 0;
            }
            else
                total += 0;

            Console.WriteLine(total+"%");
        }
    }


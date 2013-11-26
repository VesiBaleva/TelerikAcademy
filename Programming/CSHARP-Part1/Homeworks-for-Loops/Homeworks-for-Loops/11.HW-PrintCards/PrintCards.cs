using System;

class PintCards
    {
        static void Main()
        {           
            for (int i = 2; i<=14;i++ )
            {
                for (int j = 1; j <= 4;j++ )
                {
                    switch (i)
                    {
                        case 2:
                            Console.Write("Two   of ");
                            break;
                        case 3:
                            Console.Write("Three of ");
                            break;
                        case 4:
                            Console.Write("Four  of ");
                            break;
                        case 5:
                            Console.Write("Five  of ");
                            break;
                        case 6:
                            Console.Write("Six   of ");
                            break;
                        case 7:
                            Console.Write("Seven of ");
                            break;
                        case 8:
                            Console.Write("Eight of ");
                            break;
                        case 9:
                            Console.Write("Nine  of ");
                            break;
                        case 10:
                            Console.Write("Ten   of ");
                            break;
                        case 11:
                            Console.Write("Jack  of ");
                            break;
                        case 12:
                            Console.Write("Queen of ");
                            break;
                        case 13:
                            Console.Write("King  of ");
                            break;
                        case 14:
                            Console.Write("Ace   of ");
                            break;
                        default:
                            Console.Write("Error card!");
                            break;
                    }
                    switch (j)
                    {
                        case 1:
                            Console.Write("Spades;   ");
                            break;
                        case 2:
                            Console.Write("Harts;   ");
                            break;
                        case 3:
                            Console.Write("Diamonds;   ");
                            break;
                        case 4:
                            Console.Write("Clubs;    ");
                            break;
                        default:
                            Console.Write("Error in suit!");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }


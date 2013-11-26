/* Write a program that converts a number in the range [0...999] to a text corresponding
 * to its English pronunciation. Examples:
	0  "Zero"
	273  "Two hundred seventy three"
	400  "Four hundred"
	501  "Five hundred and one"
	711  "Seven hundred and eleven"
*/
using System;
using System.Threading;
using System.Globalization;

class NumberToText
{
    static string NumText(ushort number)
    {
        string txt="" ; 
        switch (number)
        {
            case 0: txt = "zero"; break;
            case 1: txt = "one"; break;
            case 2: txt = "two"; break;
            case 3: txt = "three"; break;
            case 4: txt = "four"; break;
            case 5: txt = "five"; break;
            case 6: txt = "six"; break;
            case 7: txt = "seven"; break;
            case 8: txt = "eight"; break;
            case 9: txt = "nine"; break;
            case 10: txt = "ten"; break;
            case 11: txt = "eleven"; break;
            case 12: txt = "twelve"; break;
            case 13: txt = "thirteen"; break;
            case 14: txt = "fourteen"; break;
            case 15: txt = "fifteen"; break;
            case 16: txt = "sixteen"; break;
            case 17: txt = "seventeen"; break;
            case 18: txt = "eighteen"; break;
            case 19: txt = "nineteen"; break;
            case 20: txt = "twenty"; break;
            case 30: txt = "thirty"; break;
            case 40: txt = "fourty"; break;
            case 50: txt = "fifty"; break;
            case 60: txt = "sixty"; break;
            case 70: txt = "seventy"; break;
            case 80: txt = "eighty"; break;
            case 90: txt = "ninety"; break;
        }
        return txt;
    }
    static void Main()
    {
        Console.WriteLine("Enter number in range [0...999]: ");
        ushort num = 0;
        string textH = "hundred";
        string textNumber = "";
        ushort digit=0;
        bool parseSuccess = ushort.TryParse(Console.ReadLine(), out num);
        if (parseSuccess && (ushort)(num /1000)==0)
        {
            if (num == 0)
            {
                textNumber = NumText(digit);
            }
            else
            {
                if (num / 100 > 0)
                {
                    digit = (ushort)(num / 100);
                    textNumber = NumText(digit) + " " + textH;
                }
                if (num % 100 > 0)
                {
                    digit = (ushort)(num % 100);
                    if (digit >= 1 && digit <= 11)
                    {
                        if (textNumber == "")
                        {
                            textNumber = textNumber + NumText(digit);
                        }
                        else
                        {
                            textNumber = textNumber + " and " + NumText(digit);
                        }
                    }
                    else if (digit > 11 && digit <= 19)
                    {
                        textNumber = textNumber + NumText(digit);
                    }
                    else if (digit > 19 && (digit % 10) > 0)
                    {
                        textNumber = textNumber + " " + NumText((ushort)((digit / 10) * 10)) + " " + NumText((ushort)(digit % 10));
                    }
                    else
                    {
                        if (textNumber == "")
                        {
                            textNumber = textNumber + NumText(digit);
                        }
                        else
                        {
                            textNumber = textNumber + " and " + NumText(digit);
                        }
                    }
                }
            }
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            Console.WriteLine("{0} -> {1}",num,textInfo.ToTitleCase(textNumber));
        }
        else
        {
            Console.WriteLine("Enter valid number in range!");
        }
    }
}


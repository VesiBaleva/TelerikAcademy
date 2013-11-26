/* Declare two string variables and assign them with following value:
   The "use" of quotations causes difficulties.
	Do the above in two different ways: with and without using quoted strings.*/
using System;

class DeclareTwoStrings
{
    static void Main()
    {
        string withQuoted="The \"use\" of quotations causes difficulties.";
        Console.WriteLine();
        Console.WriteLine(withQuoted);
        string withoutQuoted = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(withoutQuoted);
    }
}


/* A bank account has a holder name (first name, middle name and last name), 
 * available amount of money (balance), bank name, IBAN, BIC code and
 * 3 credit card numbers associated with the account.
 * Declare the variables needed to keep the information for a single bank account
 * using the appropriate data types and descriptive names.
*/
using System;

class BankAccount
{
    static void CheckValidCreditCard(string creditCard)
    {
        string[] card = creditCard.Split(' ');
        string cardFul = card[0] + card[1] + card[2] + card[3];        
        byte[] newCard = new byte[16];
        int sum = 0;
        for (int i = 1; i <= 16; i++)
        {
            if (i % 2 == 0)
            {
                newCard[i - 1] = Convert.ToByte(cardFul.Substring(i - 1, 1));
            }
            else
            {
                newCard[i - 1] = (byte)(2 * Convert.ToByte(cardFul.Substring(i - 1, 1)));
            }
            if (newCard[i - 1] >= 10) newCard[i - 1] = (byte)(1 + (newCard[i - 1] - 10));            
            sum += newCard[i - 1];
        }        
        if (sum % 10 != 0) Console.WriteLine("This credit card is invalid");
    }
    static void Main()
    {
        string firstName = "Ivan";
        string middleName = "Petrov";
        string lastName = "Todorov";
        Console.WriteLine("{0} {1} {2}",firstName,middleName,lastName);
        decimal moneyBalance = 850.50m;
        Console.WriteLine("{0:C}", moneyBalance);
        string bankName="DSK bank";
        string iban="BG20STSA93000015936830";
        string bicCode = "STSABGSF";
        Console.WriteLine("{0}\t{1}\t{2}",bankName,iban,bicCode);
        //declare crad number as string because only use numbers digits for check 
        string firstCreditCard = "4552 7204 1234 5677";
        Console.WriteLine("CARD NUMBER 1: {0}", firstCreditCard);
        //check for valide card number
        CheckValidCreditCard(firstCreditCard);
        string secondCreditCard = "5824 8720 6952 1234";
        Console.WriteLine("CARD NUMBER 2: {0}", secondCreditCard);
        //check for validate second card number
        CheckValidCreditCard(secondCreditCard);
        string thirdCreditCard = "6521 8963 1251 1234";
        Console.WriteLine("CARD NUMBER 3: {0}", thirdCreditCard);
        //check for validate third card number
        CheckValidCreditCard(thirdCreditCard);



    }
}


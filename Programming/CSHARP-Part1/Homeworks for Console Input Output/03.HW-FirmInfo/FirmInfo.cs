/* A company has name, address, phone number, fax number, web site and manager.
 * The manager has first name, last name, age and a phone number.
 * Write a program that reads the information about a company and its manager and prints them on the console.*/
using System;
class FirmInfo
{
    static void Main()
    {
        Console.Write("Name of Company: ");
        string compName = Console.ReadLine();
        Console.Write("Address of Company: ");
        string compAddress = Console.ReadLine();
        Console.Write("Company Phone Number /000-0-000-000-000/: ");
        string compPhone = Console.ReadLine();
        string[] numbers = compPhone.Split('-');
        int partNum;
        foreach (string group in numbers)
        {
            try
            {
                partNum = Convert.ToInt32(group);
            }
            catch
            {
                Console.WriteLine("Enter valid format telephone number !!!");
            }
        }
        Console.Write("Company Fax Number /000-0-000-000-000/: ");
        string compFax = Console.ReadLine();
        numbers = compFax.Split('-');
        foreach (string group in numbers)
        {
            try
            {
                partNum = Convert.ToInt32(group);
            }
            catch
            {
                Console.WriteLine("Enter valid format fax number !!!");
            }
        }
        Console.Write("Company web site: ");
        string webSite = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Manager - First Name: ");
        string firstNameManager = Console.ReadLine();
        Console.Write("Manager - Last Name: ");
        string LastNameManager = Console.ReadLine();
        Console.Write("Manager - age: ");
        int ageManager = int.Parse(Console.ReadLine());
        Console.Write("Manager Phone Number /000-0-000-000-000/: ");
        string phoneManager = Console.ReadLine();
        numbers = phoneManager.Split('-');
        foreach (string group in numbers)
        {
            try
            {
                partNum = Convert.ToInt32(group);
            }
            catch
            {
                Console.WriteLine("Enter valid format for telefone number !!!");
            }
        }
        Console.Clear();
        Console.WriteLine("{0} \n{1} \n{2} \n{3} \n{4}",compName,compAddress,compPhone,compFax, webSite);
        Console.WriteLine();
        Console.WriteLine("{0} {1} {2} \n{3}", firstNameManager, LastNameManager, ageManager, phoneManager);

    }
}


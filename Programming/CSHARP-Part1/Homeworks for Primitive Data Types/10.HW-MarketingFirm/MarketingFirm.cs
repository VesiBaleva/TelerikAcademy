/* A marketing firm wants to keep record of its employees.
 * Each record would have the following characteristics – 
 * first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999).
 * Declare the variables needed to keep the information for a single employee
 * using appropriate data types and descriptive names.
*/
using System;

class MarketingFirm
{
    static void Main()
    {
        string employeeFirstName = "Ivan";
        string employeeFamilyName = "Ivanov";
        byte employeeAge = 36;
        char employeeGender = 'm';
        uint employeeIDnumber = 69999;
        uint employeeNumber = 27569999;
        Console.WriteLine("Employee: {4} {0} {1} {3} {2}", employeeFirstName,employeeFamilyName,employeeAge, employeeGender, employeeNumber);
    }
}


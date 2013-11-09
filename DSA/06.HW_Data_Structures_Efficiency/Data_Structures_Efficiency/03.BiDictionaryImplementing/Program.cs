using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BiDictionaryImplementing
{
    class Program
    {
        static void Main(string[] args)
        {
            BiDictionary<string, string, string> dictionary = new BiDictionary<string, string, string>();
            dictionary.Add("Sofia", "man", "Ivo Ivanov");
            dictionary.Add("Sofia", "woman", "Maria Ivanova");
            dictionary.Add("Plovdiv", "man", "Peter Petrov");
            dictionary.Add("Plovdiv", "woman", "Lili Georgieva");
            
            Console.WriteLine("\nAll from Sofia");
            var fromSofia = dictionary.FindByFistKey("Sofia");
            foreach (var item in fromSofia)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nAll man");
            var manGender = dictionary.FindBySecondKey("man");
            foreach (var item in manGender)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nAll Plovdiv and man");
            var manFromPlovdiv = dictionary.FindByBothKeys("Plovdiv", "man");
            foreach (var item in manFromPlovdiv)
            {
                Console.WriteLine(item);
            }
        }
    }
}

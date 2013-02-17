/*Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Palindromes
    {
        static void Main(string[] args)
        {
            string text = "Lorem ipsum dolor sit amet !lamal, ;;;consectetuer adipiscing ABBA- elit,exe sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi lamal. Nam liber lamal tempor cum soluta nobis exe eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum exe.";
            StringBuilder separatorBuild=new StringBuilder();
            char[] letters = text.ToCharArray();
            
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsPunctuation(letters[i]) || Char.IsSeparator(letters[i]))
                {
                    separatorBuild.Append(letters[i]);
                }
            }
            //Console.WriteLine(separatorBuild.ToString());
            char[] separators = separatorBuild.ToString().ToCharArray();
            string[] words = text.Split(separators,StringSplitOptions.RemoveEmptyEntries);
            StringBuilder palindromesBuild = new StringBuilder();
            foreach (var item in words)
            {
                //Console.WriteLine(item);
                
                bool isPalindrom = true;
                for (int i = 0; i < item.Length/2; i++)
                {

                    if (item[i] != item[item.Length - i - 1])
                    {
                        isPalindrom = false;
                        break;
                    }
                }
                if (isPalindrom)
                {
                    palindromesBuild.AppendFormat("{0}, ", item);
                }                
            }

            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("All palindromes: {0}",palindromesBuild.ToString());

            var splitPalindromes = palindromesBuild.ToString().Split(separators,StringSplitOptions.RemoveEmptyEntries);
            List<string> distinctWords = new List<string>(splitPalindromes.Distinct());
            Console.WriteLine("Finally unique: ");
            foreach (var item in distinctWords)
            {
                Console.Write("{0} ", item.ToString());
            }
            Console.WriteLine();

        }
    }

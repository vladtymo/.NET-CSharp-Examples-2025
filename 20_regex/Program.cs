using System.Text.RegularExpressions;

namespace _20_regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------- Regular Expression --------------
            // Example:
            // email address: \w{2,}@\w+.\w+
            // phone number: \+380\(\d{2}\)\d{3}\-?\d{2}\-?\d{2}
            // word: [A-Z]\w+\-?\w*

            Regex regex = null;

            // ^ - початок тексту повинен відповідати шаблону
            // $ - кінець тексту повинен відповідати шаблону

            bool isValid = false;
            do
            {
                Console.Write("Enter your email address: ");
                string email = Console.ReadLine();

                regex = new Regex(@"\w{2,}@\w+\.\w+");

                isValid = regex.IsMatch(email);

                Console.WriteLine(isValid ? "Email is valid!" : "Not valid!");

            } while (!isValid);

            /* -------------- Character classes --------------
                .	    any character except newline
                \w\d\s	word, digit, whitespace
                \W\D\S	not word, digit, whitespace
                [abc]	any of a, b, or c
                [^abc]	not a, b, or c
                [a-g]	character between a & g
             */
            regex = new Regex("[A-Z][a-z]*");

            Console.WriteLine("\n\n");
            while (true)
            {
                Console.WriteLine("Enter string: ");
                string input = Console.ReadLine();

                if (input == "exit")
                    break;

                Console.WriteLine(
                    input != null && regex.IsMatch(input)
                        ? $"String \"{input}\" matched"
                        : $"String \"{input}\" NOT matched");

                Console.WriteLine(new string('-', 50));
            }

            // Regex.Replace() - замінює текст, який відповідає шаблону

            string text = "blalba 847563981 argg aeg aegha 454545451 ajerg ia 987654321 Bye!";
            string output = Regex.Replace(text, @"(\d{2})(\d{2})(\d{2})(\d{3})", "+38 (0$1)-$2-$3-$4");
            //string output = Regex.Replace(text, @"\d{9}", (m) => string.Format("{0:+38 (0##)-##-##-###}", Convert.ToInt64(m.Value)));
            Console.WriteLine(output);
        }
    }
}
using System;

namespace learningprojectserver.learning
{
    public class sepratenumberapha
    {

        public static void SeparateAlphaNumber()
        {
            string str = "NGHujyweu7875";

            string letters = "";
            string digits = "";

            foreach (char ch in str)
            {
                if (ch >= '0' && ch <= '9')
                {
                    digits += ch;
                }
                else if (
                    (ch >= 'a' && ch <= 'z') ||
                    (ch >= 'A' && ch <= 'Z')
                )
                {
                    letters += ch;
                }
            }

            Console.WriteLine(letters); // NGHujyweu
            Console.WriteLine(digits);  // 7875
        }

        public static void LINQSepration() {
            string input = "NGHujyweu7875";

            string letters = new string(input.Where(char.IsLetter).ToArray());
            string numbers = new string(input.Where(char.IsDigit).ToArray());

            Console.WriteLine(letters);
            Console.WriteLine(numbers);

        }




    }
}
    
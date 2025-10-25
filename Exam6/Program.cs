using System;

namespace Exam
{
    class Program
    {
        public static bool TryParse(string str, out int number) {
            number = 0;
            bool flag = true;
            for (int i = 0; i < str.Length; i++) {
                if (Char.IsDigit(str[i])==false) {
                    flag = false;
                    break;
                }
            }
            if (flag == true) {
                number = int.Parse(str);
            }
            return flag;

        }
        static void Main(string[] args)
        {   
            Console.WriteLine(TryParse("1232", out int number));
        }
    }
}
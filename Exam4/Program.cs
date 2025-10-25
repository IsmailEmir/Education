using System;

namespace Exam
{
    class Program
    {
        public static bool IsPalindrome(int x) {
            string s = x.ToString();
            for (int i = 0; i < s.Length / 2; i++) {
                if (s[i] != s[s.Length - 1 - i]) {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome(1111111));
        }
    }
}

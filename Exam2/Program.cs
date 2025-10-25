using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "BananaRama";
            int cnt = 0;
            for (int i = 0; i < s.Length; i++) {
                if (Char.IsLower(s[i])) {
                    cnt += 1;
                }
            }
            Console.WriteLine(cnt);
        }
    }
}

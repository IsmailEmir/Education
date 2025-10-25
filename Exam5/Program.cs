using System;

namespace Exam
{
    class Program
    {
        public static int[] RunningSum(int[] nums) {
            int[] result = new int[nums.Length];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++) {
                    result[i] += sum;
                    sum += nums[i];
            }
            return result; // ну условный вывод
        }
        static void Main(string[] args)
        {
            int[] nums = {0, 3, 14, 8, 2, 94};
            int[] result = new int[nums.Length];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++) {
                    result[i] += sum;
                    sum += nums[i];
            }
            for (int i = 0; i < nums.Length; i++) {
                Console.WriteLine(result[i]);
            }
        }
    }
}

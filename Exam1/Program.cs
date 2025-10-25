using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {3, 15, 1, 14};
            int temp = nums[0];
            for (int i = 0; i < nums.Length; i++) {
                    if (temp > nums[i]) {
                        temp = nums[i];
                }
            }
            Console.WriteLine(temp);
        }
    }
}

using System;

namespace September;

class Program
{
    public static void Main()
    {
    int a = int.Parse(Console.ReadLine());
    int b = int.Parse(Console.ReadLine());
    double leap = (double)(b-a+1)/4;
    Console.WriteLine((int)leap);
    }
}
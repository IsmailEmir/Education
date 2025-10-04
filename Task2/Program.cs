namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine((a % 100 % 10) * 100 + (a / 10 % 10) * 10 + a / 100);

        //125
        //5 = (a % 100 % 10) * 100
        //2 = (a / 10 % 10) * 10
        //1 = a / 100
    }
}

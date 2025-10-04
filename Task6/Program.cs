namespace Task6;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Type x1");
        int x1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Type y1");
        int y1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Type x2");
        int x2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Type y2");
        int y2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Type Point1");
        int p1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Type Point2");
        int p2 = int.Parse(Console.ReadLine());
        double chisl = Math.Abs((y2 - y1) * p1 - (x2 - x1) * p2 + x2 * y1 - y2 * x1);
        double znam = Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
        double distance = numerator / denominator;

        Console.WriteLine(distance);

    }
}

namespace Task3;

class Program
{
    static void Main(string[] args)
    {
        int hours = int.Parse(Console.ReadLine());
        if (hours > 12) {
            hours -= 12;
        }
        int degrees = hours * 30;
        if (degrees > 180) {
            degrees = 180 - ((hours - 6) * 30);
        }
        Console.WriteLine(degrees);
    }
}

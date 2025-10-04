namespace Task1;

class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 9;
        (a, b) = (b, a);
        Console.WriteLine(a);
        Console.WriteLine(b);
        //Можно, но не стоит, так как уменьшается читаемость кода, и в целом возникает дискомфорт
    }
}

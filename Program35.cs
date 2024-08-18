class test
{
    public int x { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        test test1 = new test();
        Console.WriteLine(test1.x);
    }
}
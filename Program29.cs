class pracownik
{
    public virtual void Pracuj()
    {
        Console.WriteLine("pracownik pracuje");
    }
}
class Programista : pracownik
{
    public override void Pracuj()
    {
        Console.WriteLine("Programista pracuje");
    }
}
class Księgowy : pracownik
{
    public override void Pracuj()
    {
        Console.WriteLine("Księgowy pracuje");
    }
}
class Projektant : pracownik
{
    public override void Pracuj()
    {
        Console.WriteLine("Projektant  pracuje");
    }
}
class program
{
    static void Main(string[] args)
    {
        Projektant p1= new Projektant();
        Programista p2 = new Programista();
        Księgowy p3 = new Księgowy();
        List<pracownik> lista = new List<pracownik>();
        lista.Add(p1);
        lista.Add(p2);
        lista.Add(p3);
        foreach(pracownik p in lista)
        {
            p.Pracuj();
        }


    }
}
using static System.Net.Mime.MediaTypeNames;

interface zadania
{
    void JakSiePoruszam();
    void CoJem();
}
interface IClonable
{

}
class Zwierzę : zadania
{
    public virtual void JakSiePoruszam()
    {
        Console.WriteLine("poruszam się na czterech łapach");
    }
    public virtual void CoJem()
    {
        Console.WriteLine("co słychać");
    }
    public Object Clone()
    {
        return MemberwiseClone();
    }
}
class Pies : Zwierzę
{
    public string imie;
    public int rozmiar;
    public int waga;
    public void JakSiePoruszam()
    {
        Console.WriteLine("poruszam się na czterech łapach");
    }
    public void CoJem()
    {
        Console.WriteLine("co słychać");
    }
}
class Wilk : Zwierzę
{
    public string imie;
    public int rozmiar;
    public int waga;
    public void JakSiePoruszam()
    {
        Console.WriteLine("poruszam się na czterech łapach");
    }
    public void CoJem()
    {
        Console.WriteLine("co słychać");
    }
}
class Rekin : Zwierzę
{
    public string imie;
    public int rozmiar;
    public int waga;
    public void JakSiePoruszam()
    {
        Console.WriteLine("poruszam się na czterech łapach");
    }
    public void CoJem()
    {
        Console.WriteLine("co słychać");
    }
}
class Orzeł : Zwierzę
{
    public string imie;
    public int rozmiar;
    public int waga;
    public void JakSiePoruszam()
    {
        Console.WriteLine("poruszam się na czterech łapach");
    }
    public void CoJem()
    {
        Console.WriteLine("co słychać");
    }
}
class Krokodyl : Zwierzę
{
    public string imie;
    public int rozmiar;
    public int waga;
    public void JakSiePoruszam()
    {
        Console.WriteLine("poruszam się na czterech łapach");
    }
    public void CoJem()
    {
        Console.WriteLine("co słychać");
    }
}
class program
{
    static void Main(string[] args)
    {
        Pies p1 = new Pies();
        Pies p2 = new Pies();
        p1.CoJem();
        p1.JakSiePoruszam();
        p1.waga = 20;
        p1.rozmiar = 10;
        p1.imie = "tobi";
        p2=(Pies)p1.Clone();
        Console.WriteLine("{0},{1},{2}",p2.waga, p2.rozmiar, p2.imie);
    }
}
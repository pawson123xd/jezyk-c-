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
        Console.WriteLine("mieso");
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
        Console.WriteLine("mieso");
    }
}
class Rekin : Zwierzę
{
    public string imie;
    public int rozmiar;
    public int waga;
    public void JakSiePoruszam()
    {
        Console.WriteLine("płetwami");
    }
    public void CoJem()
    {
        Console.WriteLine("mieso");
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
        Console.WriteLine("mieso");
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
        Console.WriteLine("mieso");
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
        p2 = (Pies)p1.Clone();
        Console.WriteLine("{0},{1},{2}", p2.waga, p2.rozmiar, p2.imie);
        Wilk p3 = new Wilk();
        Wilk p4 = new Wilk();
        p3.CoJem();
        p3.JakSiePoruszam();
        p3.waga = 20;
        p3.rozmiar = 10;
        p3.imie = "tobi";
        p4 = (Wilk)p3.Clone();
        Console.WriteLine("{0},{1},{2}", p4.waga, p4.rozmiar, p4.imie);
        Rekin rekin = new Rekin();
        Rekin rekin1 = new Rekin();
        rekin.CoJem();
        rekin.JakSiePoruszam();
        rekin.waga = 20;
        rekin.rozmiar = 10;
        rekin.imie = "tobi";
        rekin1 = (Rekin)rekin.Clone();
        Console.WriteLine("{0},{1},{2}", rekin1.waga, rekin1.rozmiar, rekin1.imie);
        Orzeł orzel = new Orzeł();
        Orzeł orzel1 = new Orzeł();
        orzel.CoJem();
        orzel.JakSiePoruszam();
        orzel.waga = 20;
        orzel.rozmiar = 10;
        orzel.imie = "tobi";
        orzel1 = (Orzeł)orzel.Clone();
        Console.WriteLine("{0},{1},{2}", orzel1.waga, orzel1.rozmiar, orzel1.imie);
        Krokodyl krokodyl = new Krokodyl();
        Krokodyl krokodyl1 = new Krokodyl();
        krokodyl.CoJem();
        krokodyl.JakSiePoruszam();
        krokodyl.waga = 20;
        krokodyl.rozmiar = 10;
        krokodyl.imie = "tobi";
        krokodyl1 = (Krokodyl)krokodyl.Clone();
        Console.WriteLine("{0},{1},{2}", krokodyl1.waga, krokodyl1.rozmiar, krokodyl1.imie);

    }
}
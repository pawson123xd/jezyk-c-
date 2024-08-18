interface figura
{
    void PobierzDaneZKlawiatury();
    void wyswietl();
    double LiczObwód();
}
interface IClonable
{

}
class Punkty : figura, IClonable
{
    public double X;
    public double Y;

    public void PobierzDaneZKlawiatury()
    {
        Console.WriteLine("Podaj X");
        X = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Podaj Y");
        Y = Convert.ToDouble(Console.ReadLine());

    }
    public Punkty()
    {
        //PobierzDaneZKlawiatury();
    }
    public Punkty(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void wyswietl()
    {
        Console.WriteLine(X);
        Console.WriteLine(Y);
    }
    public Object Clone()
    {
        return MemberwiseClone();
    }
    public double LiczObwód()
    {
        return 0;
    }
    //Brak Funkcji ToStringg()!
    public override string ToString()
    {
        return String.Format("punkt x={0},y={1} ", X, Y);
    }
}
class koło : figura, IClonable
{
    public int r;
    public Punkty Srodek;
    public koło()
    {
        this.r = 0;
        Srodek = new();
    }
    public koło(Punkty Srodek, int r)
    {
        this.Srodek = Srodek;
        this.r = r;
    }
    public double LiczObwód()
    {
        return 2 * r * Math.PI;
    }
    public void wyswietl()
    {
        Console.WriteLine("wspołrzedne ośrodka jest rowne x={0} y={1} \apromien koła jest rowne {2}\a a obwod koła jest rowne {3} ", Srodek.X, Srodek.Y, r, LiczObwód());
    }
    public void PobierzDaneZKlawiatury()
    {
        Console.WriteLine("Podaj punkt środka");
        Srodek.PobierzDaneZKlawiatury();
        Console.WriteLine("Podaj r: ");
        this.r = Convert.ToInt32(Console.ReadLine());
    }
    //Brak Clone!
    //Brak ToStrinnng()
    public override string ToString()
    {
        return String.Format("wspołrzedne ośrodka jest rowne x={0} y={1} \apromien koła jest rowne {2}\a a obwod koła jest rowne {3} ", Srodek.X, Srodek.Y, r, LiczObwód());
    }
    public Object Clone()
    {
        koło temp = new koło();
        temp.r = this.r;
        temp.Srodek = this.Srodek;
        return temp;
    }
}
class kwadrat : figura, IClonable
{
    public Punkty x1 = new Punkty();
    public Punkty x2 = new Punkty();
    public Punkty x3 = new Punkty();
    public Punkty x4 = new Punkty();

    public double LiczObwód()
    {
        return 4 * Math.Sqrt(Math.Pow(x1.X - x2.X, 2) + Math.Pow(x1.Y - x2.Y, 2));
    }
    public void wyswietl()
    {
        Console.WriteLine("wsporzedne 1 ({1},{2}) wsporzedne 2 ({3},{4}) wsporzedne 3 ({4},{5}) wsporzedne 4  ({6},{7}) obwod kwadrat jest rowne {8}", x1.X, x1.Y, x2.X, x2.Y, x3.X, x3.Y, x4.X, x4.Y, LiczObwód());
    }
    public void PobierzDaneZKlawiatury()
    {
        Console.WriteLine("Podaj punkty dla kwadratu");
        x1.PobierzDaneZKlawiatury();
        x2.PobierzDaneZKlawiatury();
        x3.PobierzDaneZKlawiatury();
        x4.PobierzDaneZKlawiatury();
    }
    //Brak Clone
    //Brak ToStrinng()
    public override string ToString()
    {
        return String.Format("wsporzedne 1 ({1},{2}) wsporzedne 2 ({3},{4}) wsporzedne 3 ({4},{5}) wsporzedne 4  ({6},{7}) obwod kwadrat jest rowne {8}", x1.X, x1.Y, x2.X, x2.Y, x3.X, x3.Y, x4.X, x4.Y, LiczObwód());
    }
    public Object Clone()
    {
        kwadrat copy = new kwadrat();
        copy.x1 = this.x1;
        copy.x2 = this.x2;
        copy.x3 = this.x3;
        copy.x4 = this.x4;
        return copy;
    }
}
class program
{
    static void Main(string[] args)
    {
        //koło p1 = new();
        //p1.PobierzDaneZKlawiatury();
        //Console.WriteLine(p1.ToString());
        //p1.wyswietl();

        //kwadrat w1= new kwadrat();
        //w1.PobierzDaneZKlawiatury();
        //w1.wyswietl();

    }
}
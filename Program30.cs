class osoba
{
    public string imie;
    public string nazwisko;
    public osoba(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;

    }
    public virtual void WypiszInfo()
    {
        Console.WriteLine("{0},{1}",imie, nazwisko);
    }
}
class student : osoba {
    public int rokStududiów;
    public int numerGrupy;
    public int numerAlbumu;

    public student(string imie, string nazwisko, int rokStududiów,int numerGrupy,int numerAlbumu) : base(imie,nazwisko)
    {
        this.rokStududiów = rokStududiów;
        this.numerAlbumu = numerAlbumu;
        this.numerGrupy = numerGrupy;
    }
    public override void WypiszInfo()
    {
        base.WypiszInfo();
        Console.WriteLine("{0},{1},{2}",rokStududiów,numerGrupy,numerAlbumu);
    }
}
class program
{
    static void Main(string[] args)
    {
        osoba student1 = new student("amam","amma",2020,2,17802);
        student1.WypiszInfo();
    }
}
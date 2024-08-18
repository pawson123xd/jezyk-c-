class osoba
{
    private string imie;
    private int wiek;
    public osoba()
    {

    }
    public osoba(int wiek, string imie)
    {
        this.wiek = wiek;
        this.imie = imie;
    }
    public void setwiek(int x)
    {
        wiek = x;
    }
    public void setimie(string x)
    {
        imie = x;

    }
    public int pobierzwiek()
    {
        return wiek;
    }
    public string pobierzimie()
    {
        return imie;
    }


}
class program
{
    static void Main(string[] argu)
    {
        Stack<int> p1 = new();
        Queue<string> p2 = new();
        List<osoba> p3 = new();
        osoba p4 = new osoba();
        p4.setwiek(25);
        p4.setimie("maciek");
        
        //nie mozna bo wywala blad typy np
        //p1.Push("asdas");
        Random rand =new Random();
        string[] tab = { "ewa", "maciej", "piotr", "anderzej", "kasia" };
        for (int i = 0; i < 5; i++)
        {
            p1.Push(rand.Next(1,10));
            p2.Enqueue(tab[i]);
            p3.Add(p4);
        }
        foreach (int x in p1)
        {
            Console.WriteLine(x);
        }
        foreach (string x in p2)
        {
            Console.WriteLine(x);
        }
        foreach (osoba x in p3)
        {
            Console.WriteLine(x.pobierzimie());
            Console.WriteLine(x.pobierzwiek());
        }
        Console.WriteLine(p3[0].pobierzimie());
        Console.WriteLine(p3[2].pobierzwiek());
        //do listy moge sie odwołać do każdej
        //do Queue moge tylko do pierwszej
        //do Stack moge tylko do ostatniego
        var numbersSorted = p1.OrderBy(num => num).ToArray();
        Console.WriteLine(string.Join(", ", numbersSorted));
        var numbersSorte = p2.OrderBy(num => num).ToArray();
        Console.WriteLine(string.Join(", ", numbersSorte));
        p3.Remove(p3[3]);
        //do Stack i Queue nie moge bo musze usunać 1,2,3 element 

    }

}
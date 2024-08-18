
using static graczy;

class graczy {
    Array values = Enum.GetValues(typeof(tatia));
    Random random = new Random();
    public enum tatia
    {
        trzy,
        czetery,
        piać,
        sześć,
        siedem,
        osiem,
        dziewiec,
        dziesiec,
        walet,
        dama,
        krol,
        asy,
        trzy1,
        czetery1,
        piać1,
        sześć1,
        siedem1,
        osiem1,
        dziewiec1,
        dziesiec1,
        walet1,
        dama1,
        krol1,
        asy1,

    }
    private int liczbyk = 0;
    private int punkty = 0;
    public string imie;
    public string[] talias = new string[10];
    public graczy(string imie)
    {
        this.imie = imie;
        for (int i = 0; i < 2; i++) {
            int index = random.Next(values.Length);
            tatia value = (tatia)values.GetValue(index);
            losowanie(value);
            liczynik_pukty(value);
        }

    }
    private void losowanie(tatia value)
    {
        if (value == tatia.trzy || value == tatia.trzy1)
        {
            talias[liczbyk] = "trzy";
            liczbyk += 1;
        }
        else if (value == tatia.czetery || value == tatia.czetery1)
        {
            talias[liczbyk] = "czetery";
            liczbyk += 1;
        }
        else if (value == tatia.piać || value == tatia.piać)
        {
            talias[liczbyk] = "piac";
            liczbyk += 1;
        }
        else if (value == tatia.sześć || value == tatia.sześć1)
        {
            talias[liczbyk] = "sześć";
            liczbyk += 1;
        }
        else if (value == tatia.siedem || value == tatia.siedem)
        {
            talias[liczbyk] = "siedem";
            liczbyk += 1;
        }
        else if (value == tatia.osiem || value == tatia.osiem)
        {
            talias[liczbyk] = "osiem";
            liczbyk += 1;
        }
        else if (value == tatia.dziesiec || value == tatia.dziesiec)
        {
            talias[liczbyk] = "dziesiec";
            liczbyk += 1;
        }
        else if (value == tatia.dziewiec || value == tatia.dziewiec1)
        {
            talias[liczbyk] = "dziewiec";
            liczbyk += 1;
        }
        else if (value == tatia.walet || value == tatia.walet1)
        {
            talias[liczbyk] = "walet";
            liczbyk += 1;
        }
        else if (value == tatia.dama || value == tatia.dama1)
        {
            talias[liczbyk] = "dama";
            liczbyk += 1;
        }
        else if (value == tatia.krol || value == tatia.krol)
        {
            talias[liczbyk] = "krol";
            liczbyk += 1;
        }
        else {
            talias[liczbyk] = "asy";
            liczbyk += 1;
        }
    }
    public void liczynik_pukty(tatia value)
    {
        if (value == tatia.trzy || value == tatia.trzy1)
        {
            punkty += 3;
        }
        else if (value == tatia.czetery || value == tatia.czetery1)
        {
            punkty += 4;
        }
        else if (value == tatia.piać || value == tatia.piać)
        {
            punkty += 5;
        }
        else if (value == tatia.sześć || value == tatia.sześć1)
        {
            punkty += 6;
        }
        else if (value == tatia.siedem || value == tatia.siedem)
        {
            punkty += 7;
        }
        else if (value == tatia.osiem || value == tatia.osiem)
        {
            punkty += 8;
        }
        else if (value == tatia.dziesiec || value == tatia.dziesiec)
        {
            punkty += 9;
        }
        else if (value == tatia.dziewiec || value == tatia.dziewiec1)
        {
            punkty += 10;
        }
        else if (value == tatia.walet || value == tatia.walet1)
        {
            punkty += 2;
        }
        else if (value == tatia.dama || value == tatia.dama1)
        {
            punkty += 3;
        }
        else if (value == tatia.krol || value == tatia.krol)
        {
            punkty += 4;
        }
        else
        {
            punkty += 11;
        }
    }
    public void pokaz()
    {
        Console.WriteLine(imie);
        for (int i = 0; i < liczbyk; i++) {
            Console.Write("{0},",talias[i]);
        }
        Console.WriteLine();
        Console.WriteLine(punkty);
    }
    public void dodaj_karte()
    {
        for (int i = 0; i < 1; i++)
        {
            int index = random.Next(values.Length);
            tatia value = (tatia)values.GetValue(index);
            losowanie(value);
            liczynik_pukty(value);
        }
        pokaz();

    }
    ~graczy(){
        Console.WriteLine("koniec grzy przegrałes");
    }
    public  int wynik()
    {
        return punkty;
    }
}
class program
{
    static void Main(string[] args)
    {
        graczy p1=new graczy("paweł");
        graczy p2 = new graczy("anna");
        p1.pokaz();
        p2.pokaz();
        wynik(p1, p2);
    }
    static void wynik(graczy p1, graczy p2)
    {
        int liczynik = 0;
        int liczynik1 = 0;
        foreach (string p in p1.talias)
        {
            if (p == "asy")
            {
                liczynik++;
            }
        }
        foreach (string p in p2.talias)
        {
            if (p == "asy")
            {
                liczynik1++;
            }
        }
        if (liczynik == 2)
        {
            Console.WriteLine("gracz {0} wygrał", p1.imie);
        }
        else if (liczynik1 == 2)
        {
            Console.WriteLine("gracz {0} wygrał", p2.imie);
        }
        else if (liczynik1 == 2 && liczynik==2)
        {
            Console.WriteLine("remis");
        }

        else if (p1.wynik() > 21 && p2.wynik() > 21)
        {
            Console.WriteLine("gracz {0} przegrał", p1.imie);
            Console.WriteLine("gracz {0} przegrał", p2.imie);
        }
       else if (p1.wynik() > 21)
        {
            Console.WriteLine("gracz {0} przegrał",p1.imie);
            Console.WriteLine("gracz {0} wygrał", p2.imie);
        }
        else if (p2.wynik() > 21)
        {
            Console.WriteLine("gracz {0} przegrał", p2.imie);
            Console.WriteLine("gracz {0} wygrał", p1.imie);
        }
        else if (p2.wynik() > p1.wynik())
        {
            Console.WriteLine("gracz {0} przegrał", p1.imie);
            Console.WriteLine("gracz {0} wygrał", p2.imie);
        }
        else if (p2.wynik() < p1.wynik())
        {
            Console.WriteLine("gracz {0} przegrał", p2.imie);
            Console.WriteLine("gracz {0} wygrał", p1.imie);
        }
        else
        {
            Console.WriteLine("remis");
        }
    }
}

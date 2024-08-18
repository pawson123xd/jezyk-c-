class program
{
    class osoba
    {
        protected string imie, nazwisko;
        protected int rok_urodzenia;
        protected string miejsceZamieszkania;
        public osoba(string imie, string nazwisko, int rok_urodzenia, string miejsceZamieszkania)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rok_urodzenia = rok_urodzenia;
            this.miejsceZamieszkania = miejsceZamieszkania;
        }
        public void WypiszInfo()
        {
            Console.WriteLine("imie {0} nazwisko {1} rok_urodzenia {2}", imie, nazwisko, rok_urodzenia);
        }
        protected int ObliczWiek()
        {
            return DateTime.Now.Year - rok_urodzenia;
        }

    }
    class Student : osoba
    {
        private int rok, Numer_Grupy, numerAlbumu;
        public Student(string imie, string nazwisko, string miejsceZamieszkania, int rok_urodzenia, int rok, int numer_Grupy, int numerAlbumu) : base(imie, nazwisko, rok_urodzenia, miejsceZamieszkania)
        {
            this.rok = rok;
            this.Numer_Grupy = numer_Grupy;
            this.numerAlbumu = numerAlbumu;
        }
        public new void WypiszInfo()
        {
            Console.WriteLine("imie {0} nazwisko {1} rok_urodzenia {3} miejsceZamieszkania {2} rok {4} numer_Grupy {5} numerAlbumup {6}", imie, nazwisko, miejsceZamieszkania, rok_urodzenia, rok, Numer_Grupy, numerAlbumu);
        }
    }

    static void Main()
    {
        Student p1 = new Student("pawel", "woziniski", "olsztyn", 2002, 2020, 2, 1702345);
        Student p2 = new Student("piotr", "woziniski", "olsztyn", 2000, 2019, 2, 1634232);
        osoba osoba1 = new osoba("pawel", "tterw", 2003, "milakowo");
        osoba osoba2 = new osoba("ola", "wujciech", 2000, "milakowo");
        osoba1 = p1;
        // p1 = (Student)osoba2; //nie mozna
        osoba1.WypiszInfo();
        p1.WypiszInfo();


    }
}
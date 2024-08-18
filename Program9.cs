namespace propa
{
    struct KandydatNaStudia
    {
        public string nazwisko;
        int punktyMatematyka;
        int punktyJezykObcy;
        int punktyInformatyka;
        public KandydatNaStudia(string nazwisk,int punktyMatematyk, int punktyJezykObc,int punktyInformatyk)
        {
            nazwisko=nazwisk;
            punktyMatematyka = punktyMatematyk;
            punktyJezykObcy = punktyJezykObc;
            punktyInformatyka = punktyInformatyk;
        }
        public int punkty()
        {
            if (punktyInformatyka > 100 || punktyInformatyka < 0 || punktyJezykObcy > 100 || punktyJezykObcy < 0 || punktyMatematyka > 100 || punktyMatematyka < 0)
            {
                return -1;
            }
            else
            {
                return punktyInformatyka + punktyJezykObcy + punktyMatematyka;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-1 to oznacza ze dany kandydad ma wpisany blad  wyniku w matury");
            KandydatNaStudia[] p1 = { new("Rafał",30,30,30), new("Ala", 40, 100, 40), new("Andrzej", 70, 20, 90), };
            foreach(KandydatNaStudia x in p1)
            {
                Console.WriteLine("{0} {1}",x.nazwisko,x.punkty());
            }

        }
    }
}
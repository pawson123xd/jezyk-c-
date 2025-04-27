using System;
using System.Threading.Tasks.Dataflow;
class Program
{
    class Osoby
    {
        public byte[] chromosomy;
        public double przystosowanie;
        Random rand = new Random();
        public Osoby(int lbnp)
        {
            this.chromosomy = new byte[lbnp * 2];
            for (int i = 0; i < chromosomy.Length; i++)
            {
                this.chromosomy[i] = (byte)rand.Next(0, 2);
            }
        }
        public Osoby Clone()
        {
            Osoby nowy = new Osoby(this.chromosomy.Length / 2);
            this.chromosomy.CopyTo(nowy.chromosomy, 0);
            nowy.przystosowanie = this.przystosowanie;
            return nowy;
        }

        public double dekodowanie(int ZBMIN, int ZBMAX, int lbnp, ref int miejsce)
        {
            int zb = ZBMAX - ZBMIN;
            double ctmp = 0.0;
            for (int i = 0; i < lbnp; i++)
            {
                ctmp += this.chromosomy[miejsce] * Math.Pow(2, i);
                miejsce--;
            }
            double wynik = (Math.Pow(2, lbnp)) - 1;
            wynik = ctmp / wynik;
            double pm = ZBMIN + (wynik * zb);
            return Math.Round(pm, 4);
        }
    }
    public static void Main(string[] args)
    {
        int osobnikow;
        int iteracji;
        int LBnP;
        int TurRozm;
        while (true)
        {
            Console.WriteLine("podaj liczbe chromosonów");
            LBnP = int.Parse(Console.ReadLine());
            if (LBnP < 3)
            {
                Console.WriteLine("minimum 3");
                continue;
            }
            break;
        }
        int miejsce = LBnP * 2 - 1;
        while (true)
        {
            Console.WriteLine("podaj liczbe iteracji");
            iteracji = int.Parse(Console.ReadLine());
            if (iteracji < 20)
            {
                Console.WriteLine("minimum 20");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.WriteLine("podaj liczbe osobników");
            osobnikow = int.Parse(Console.ReadLine());
            if (osobnikow < 9 || osobnikow % 2 == 0)
            {
                Console.WriteLine("liczba osobników nie moze byc mniej niz 9 i jest parzysta");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.WriteLine("podaj liczbe turRozm");
            TurRozm = int.Parse(Console.ReadLine());
            if (TurRozm < 2)
            {
                Console.WriteLine("za mało");
                continue;
            }
            else if (TurRozm > Math.Round(osobnikow * 0.2) && TurRozm != 2)
            {
                Console.WriteLine("za duzo");
                continue;
            }
            break;
        }
        List<Osoby> osoby = new List<Osoby>();
        for (int i = 0; i < osobnikow; i++)
        {
            osoby.Add(new Osoby(LBnP));
        }
        foreach (Osoby osob in osoby)
        {
            int miejsceX1 = LBnP * 2 - 1;
            double x1 = osob.dekodowanie(0, 100, LBnP, ref miejsceX1);
            int miejsceX2 = LBnP - 1;
            double x2 = osob.dekodowanie(0, 100, LBnP, ref miejsceX2);
            osob.przystosowanie = przystosowanie(x1, x2);
            miejsce = LBnP * 2 - 1;
        }
        miejsce = LBnP * 2 - 1;
        for (int i = 0; i < iteracji; i++)
        {
            double suma = 0;
            List<Osoby> pokolenie = turniej(osoby, TurRozm, osobnikow);
            mutacja(pokolenie, LBnP);
            Osoby najlepszy = hot_deck(osoby);
            pokolenie.Add(najlepszy);
            double Nowy_Najlepszy=pokolenie[0].przystosowanie;
            foreach (Osoby osob in pokolenie)
            {
                double x1 = osob.dekodowanie(0, 100, LBnP, ref miejsce);
                double x2 = osob.dekodowanie(0, 100, LBnP, ref miejsce);
                osob.przystosowanie = przystosowanie(x1, x2);
                Console.WriteLine(osob.przystosowanie);
                suma += osob.przystosowanie;
                if (Nowy_Najlepszy < osob.przystosowanie)
                {
                    Nowy_Najlepszy = osob.przystosowanie;
                }
                miejsce = LBnP * 2 - 1;
            }
            suma /= pokolenie.Count;
            Console.WriteLine("najlepszy z nowego pokelenia to {0} srednia przystowania wynoś {1}", Math.Round(Nowy_Najlepszy, 4), Math.Round(suma, 4));
            osoby = pokolenie;
        }
        static double przystosowanie(double x1, double x2)
        {
            return Math.Sin(x1 * 0.05) + Math.Sin(x2 * 0.05) + 0.4 * Math.Sin(x1 * 0.15) * Math.Sin(x2 * 0.15);
        }
        static Osoby hot_deck(List<Osoby> osoby)
        {
            Osoby najlepszy = osoby[0];
            foreach (Osoby osob in osoby)
            {
                if (najlepszy.przystosowanie < osob.przystosowanie)
                {
                    najlepszy = osob;
                }
            }
            return najlepszy;
        }
        static List<Osoby> turniej(List<Osoby> populacja, int TurRozm, int osobnikow)
        {
            Random rand = new Random();
            List<Osoby> osoby = new List<Osoby>();

            for (int i = 0; i < osobnikow - 1; i++)
            {
                Osoby[] rywale = new Osoby[TurRozm];
                for (int j = 0; j < TurRozm; j++)
                {
                    int x1 = rand.Next(0, populacja.Count);
                    rywale[j] = populacja[x1];
                }

                Osoby max = rywale[0];
                for (int k = 1; k < TurRozm; k++)
                {
                    if (max.przystosowanie <= rywale[k].przystosowanie)
                    {
                        max = rywale[k];
                    }
                }
                osoby.Add(max.Clone());

            }
            return osoby;
        }
        static void mutacja(List<Osoby> populacja, int LBnP)
        {
            double prawdopodobienstwoMutacji = 0.2;
            Random rand = new Random();
            foreach (Osoby osoby in populacja)
            {
                for (int i = 0; i < osoby.chromosomy.Length; i++)
                {
                    if (rand.NextDouble() < prawdopodobienstwoMutacji)
                    {
                        osoby.chromosomy[i] = (byte)(1 - osoby.chromosomy[i]);
                    }
                }
            }
        }
    }
}


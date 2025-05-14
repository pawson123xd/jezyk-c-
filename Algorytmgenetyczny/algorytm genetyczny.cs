using System;
using System.Threading.Tasks.Dataflow;
class Program
{
    class Osobnik
    {
        public double[] wag;
        public double przystosowanie = 0;
        public byte[] chromosomy;
        public Osobnik()
        {
            wag = new double[3 * 3];
            chromosomy = new byte[9 * 4];
            Random random = new Random();

            for (int i = 0; i < chromosomy.Length; i++)
            {
                chromosomy[i] = (byte)random.Next(0, 2);
            }
        }
        public void dekodowanie(int ZBMIN, int ZBMAX)
        {
            double zb = ZBMAX - ZBMIN;
            for (int g = 0; g < 9; g++)
            {
                int miejsce = g * 4;
                int intVal = 0;

                for (int b = 0; b < 4; b++)
                {
                    intVal = intVal * 2 + chromosomy[miejsce + b];
                }
                double fraction = (double)intVal / (Math.Pow(2, 4) - 1);
                wag[g] = ZBMIN + fraction * zb;
            }
        }
        public Osobnik Clone()
        {
            Osobnik nowy = new Osobnik();
            this.chromosomy.CopyTo(nowy.chromosomy, 0);
            nowy.przystosowanie = this.przystosowanie;
            return nowy;
        }
        public void Przystowanie()
        {
            dekodowanie(-10, 10);
            byte[,] daneWejsciowe = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
            przystosowanie = 0;
            for (int i = 0; i < 4; i++)
            {
                double wynik = Aktywacja(daneWejsciowe[i, 0], daneWejsciowe[i, 1]);
                double ocz = (byte)(daneWejsciowe[i, 0] ^ daneWejsciowe[i, 1]);
                przystosowanie += Math.Pow(ocz - wynik, 2);
            }
        }
        private double Aktywacja(byte we1, byte we2)
        {
            double suma = 0;
            double[] neuron = new double[2];
            neuron[0] = Sigmoida(wag[0] * we1 + wag[1] * we2 + wag[2]);
            neuron[1] = Sigmoida(wag[3] * we1 + wag[4] * we2 + wag[5]);
            suma += wag[6] * neuron[0];
            suma += wag[7] * neuron[1];
            suma += wag[8];
            return Sigmoida(suma);
        }
        private double Sigmoida(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
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
    class osobnik
    {
        Random random = new Random();
        public byte[] chromosomy;
        public double przystosowanie;
        public osobnik(int LBnP)
        {
            chromosomy = new byte[LBnP * 3];
            for (int i = 0; i < chromosomy.Length; i++)
            {
                chromosomy[i] = (byte)random.Next(0, 2);
            }
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
        public osobnik Clone()
        {
            osobnik nowy = new osobnik(this.chromosomy.Length / 3);
            this.chromosomy.CopyTo(nowy.chromosomy, 0);
            nowy.przystosowanie = this.przystosowanie;
            return nowy;
        }
    }
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("podaj numer zadania");
            int zadanie = int.Parse(Console.ReadLine());
            if (zadanie == 1)
            {
                zadanie_1();
                break;
            }
            if (zadanie == 2)
            {
                zadanie_2();
                break;
            }
            if (zadanie == 3)
            {
                zadanie_3();
                break;
            }
            else
            {
                Console.WriteLine("nie takiego zadanie");
            }
        }
    }
    static void zadanie_3()
    {
        int iteracja;
        int osobnicy = 13;
        List<Osobnik> stare = new List<Osobnik>();
        while (true)
        {
            Console.WriteLine("Podaj liczbe iteracja");
            iteracja = int.Parse(Console.ReadLine());
            if (iteracja < 100)
            {
                Console.WriteLine("za malo");
                continue;
            }
            break;
        }
        for (int i = 0; i < osobnicy; i++)
        {
            Osobnik osoba = new Osobnik();
            osoba.Przystowanie();
            stare.Add(osoba);
        }
        for (int i = 0; i < iteracja; i++)
        {
            List<Osobnik> pokolenie = new List<Osobnik>();
            double srednia = 0;
            pokolenie = Turniej3(stare, osobnicy);
            kryzowanie(pokolenie[0], pokolenie[1]);
            kryzowanie(pokolenie[2], pokolenie[3]);
            kryzowanie(pokolenie[8], pokolenie[9]);
            kryzowanie(pokolenie[pokolenie.Count - 2], pokolenie[pokolenie.Count - 1]);
            pokolenie = mutacja3(pokolenie);
            pokolenie.Add(hot_deck3(stare));
            Osobnik najlepszy = pokolenie[0];
            foreach (Osobnik osoba in pokolenie)
            {
                osoba.Przystowanie();
                if (najlepszy.przystosowanie > osoba.przystosowanie)
                {
                    najlepszy = osoba;
                }
                srednia += osoba.przystosowanie;
            }
            srednia = srednia / pokolenie.Count;
            Console.WriteLine("srednia jest rowna {0} a najmniejszy {1}", srednia, najlepszy.przystosowanie);
            stare = pokolenie;
        }
    }
    static void zadanie_2()
    {
        int osobnikow = 13;
        int iteracji;
        int LBnP;
        int TurRozm = 3;
        int miejsce;
        while (true)
        {
            Console.WriteLine("podaj liczbe chromosonów");
            LBnP = int.Parse(Console.ReadLine());
            if (LBnP < 4)
            {
                Console.WriteLine("minimum 4");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.WriteLine("podaj liczbe iteracji");
            iteracji = int.Parse(Console.ReadLine());
            if (iteracji < 100)
            {
                Console.WriteLine("minimum 100");
                continue;
            }
            break;
        }
        List<osobnik> stare = new List<osobnik>();
        for (int i = 0; i < osobnikow; i++)
        {
            stare.Add(new osobnik(LBnP));
        }
        miejsce = LBnP * 3 - 1;
        foreach (osobnik osoba in stare)
        {
            double pa = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
            double pb = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
            double pc = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
            osoba.przystosowanie = Przystosowanie2(pa, pb, pc);
            miejsce = LBnP * 3 - 1;
        }
        for (int i = 0; i < iteracji; i++)
        {
            double suma = 0;
            List<osobnik> pokolenie = turniej2(stare, TurRozm, osobnikow);
            osobnik najlepszy = hot_deck2(stare);
            kryzowanie(pokolenie[0], pokolenie[1], LBnP);
            kryzowanie(pokolenie[2], pokolenie[3], LBnP);
            kryzowanie(pokolenie[8], pokolenie[9], LBnP);
            kryzowanie(pokolenie[pokolenie.Count - 2], pokolenie[pokolenie.Count - 1], LBnP);
            pokolenie = mutacja2(pokolenie);
            pokolenie.Add(najlepszy);
            najlepszy = pokolenie[0];
            foreach (osobnik osoba in stare)
            {
                double pa = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
                double pb = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
                double pc = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
                osoba.przystosowanie = Przystosowanie2(pa, pb, pc);
                if (najlepszy.przystosowanie < osoba.przystosowanie)
                {
                    najlepszy = osoba;
                }
                miejsce = LBnP * 3 - 1;
                suma += osoba.przystosowanie;
            }
            suma /= pokolenie.Count;
            Console.WriteLine("najlepszy z nowego pokelenia to {0} srednia przystowania wynoś {1}", Math.Round(najlepszy.przystosowanie, 4), Math.Round(suma, 4));
            stare = pokolenie;
        }
    }
    static void zadanie_1()
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
            double Nowy_Najlepszy = pokolenie[0].przystosowanie;
            foreach (Osoby osob in pokolenie)
            {
                double x1 = osob.dekodowanie(0, 100, LBnP, ref miejsce);
                double x2 = osob.dekodowanie(0, 100, LBnP, ref miejsce);
                osob.przystosowanie = przystosowanie(x1, x2);
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
    static void kryzowanie(osobnik x1, osobnik x2, int LBnP)
    {
        Random rand = new Random();
        int cienicie = rand.Next(0, (LBnP * 3) - 2);
        for (int i = cienicie + 1; i < LBnP; i++)
        {
            byte pamieć = x1.chromosomy[i];
            x1.chromosomy[i] = x2.chromosomy[i];
            x2.chromosomy[i] = pamieć;
        }
    }
    static double Przystosowanie2(double pa, double pb, double pc)
    {
        double suma = 0;
        double[] y = { 0.59554, 0.58813, 0.64181, 0.68587, 0.44783, 0.40836, 0.38241, -0.05933, -0.12478, -0.36847, -0.39935, -0.50881, -0.63435, -0.59979, -0.64107, -0.51808, -0.38127, -0.12349, -0.09624, 0.27893, 0.48965, 0.33089, 0.70615, 0.53342, 0.43321, 0.64790, 0.48834, 0.18440, -0.02389, -0.10261, -0.33594, -0.35101, -0.62027, -0.55719, -0.66377, -0.62740 };
        double[] x = { -1.0, -0.8, -0.6, -0.4, -0.2, 0.0, 0.2, 0.4, 0.6, 0.8, 1.0, 1.2, 1.4, 1.6, 1.8, 2.0, 2.2, 2.4, 2.6, 2.8, 3.0, 3.2, 3.4, 3.6, 3.8, 4.0, 4.2, 4.4, 4.6, 4.8, 5.0, 5.2, 5.4, 5.6, 5.8, 6.0 };
        for (int i = 0; i < y.Length; i++)
        {
            double wynik = y[i] - (pa * Math.Sin((pb * x[i]) + pc));
            suma += Math.Round(Math.Pow(wynik, 2), 4);
        }
        return suma;
    }
    static List<osobnik> turniej2(List<osobnik> populacja, int TurRozm, int osobnikow)
    {
        Random rand = new Random();
        List<osobnik> osoby = new List<osobnik>();
        for (int i = 0; i < osobnikow - 1; i++)
        {
            osobnik[] rywale = new osobnik[TurRozm];
            for (int j = 0; j < TurRozm; j++)
            {
                int x1 = rand.Next(osobnikow);
                rywale[j] = populacja[x1];
            }

            osobnik max = rywale[0];
            for (int k = 0; k < TurRozm; k++)
            {
                if (max.przystosowanie < rywale[k].przystosowanie)
                {
                    max = rywale[k];
                }
            }
            osoby.Add(max.Clone());
        }
        return osoby;
    }
    static List<osobnik> mutacja2(List<osobnik> populacja)
    {
        double prawdopodobienstwoMutacji = 0.2;
        Random rand = new Random();
        for (int j = 4; j < populacja.Count; j++)
        {
            for (int i = 0; i < populacja[j].chromosomy.Length; i++)
            {
                if (rand.NextDouble() < prawdopodobienstwoMutacji)
                {
                    if (rand.NextDouble() < prawdopodobienstwoMutacji)
                    {
                        populacja[j].chromosomy[i] = (byte)(1 - populacja[j].chromosomy[i]);
                    }
                }
            }
        }
        return populacja;
    }
    static osobnik hot_deck2(List<osobnik> osoby)
    {
        osobnik najlepszy = osoby[0];
        foreach (osobnik osob in osoby)
        {
            if (najlepszy.przystosowanie < osob.przystosowanie)
            {
                najlepszy = osob;
            }
        }
        return najlepszy;
    }
    static List<Osobnik> Turniej3(List<Osobnik> populacja, int osobnikow)
    {
        Random rand = new Random();
        List<Osobnik> osoby = new List<Osobnik>();
        for (int i = 0; i < osobnikow - 1; i++)
        {
            Osobnik[] rywale = new Osobnik[3];
            int[] pamiec = new int[3];
            for (int j = 0; j < 3; j++)
            {
                int x1 = rand.Next(osobnikow);
                pamiec[j] = x1;
                for (int j2 = 0; j2 < pamiec.Length; j2++)
                {
                    while (pamiec[j2] == x1)
                    {
                        x1 = rand.Next(osobnikow);
                    }
                }
                rywale[j] = populacja[x1];
            }
            Osobnik max = rywale[0];
            for (int j = 0; j < 3; j++)
            {
                if (max.przystosowanie > rywale[j].przystosowanie)
                {
                    max = rywale[j];
                }
            }
            osoby.Add(max.Clone());
        }
        return osoby;
    }
    static void kryzowanie(Osobnik x1, Osobnik x2)
    {
        Random rand = new Random();
        int cienicie = rand.Next(0, 35 - 2);
        for (int i = cienicie + 1; i < x1.chromosomy.Length; i++)
        {
            byte pamieć = x1.chromosomy[i];
            x1.chromosomy[i] = x2.chromosomy[i];
            x2.chromosomy[i] = pamieć;
        }
    }
    static List<Osobnik> mutacja3(List<Osobnik> populacja)
    {
        double prawdopodobienstwoMutacji = 0.2;
        Random rand = new Random();
        for (int j = 4; j < populacja.Count; j++)
        {
            for (int i = 0; i < populacja[j].chromosomy.Length; i++)
            {
                if (rand.NextDouble() < prawdopodobienstwoMutacji)
                {
                    if (populacja[j].chromosomy[i] == 0)
                    {
                        populacja[j].chromosomy[i] = 1;
                    }
                    else
                    {
                        populacja[j].chromosomy[i] = 0;
                    }
                }
            }

        }
        return populacja;
    }
    static Osobnik hot_deck3(List<Osobnik> osoby)
    {
        Osobnik najlepszy = osoby[0];
        foreach (Osobnik osob in osoby)
        {
            if (najlepszy.przystosowanie > osob.przystosowanie)
            {
                najlepszy = osob;
            }
        }
        return najlepszy.Clone();
    }
}

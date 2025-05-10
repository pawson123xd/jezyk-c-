class program
{
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
                chromosomy[i] = (byte)random.Next(0,2);
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
            return Math.Round(pm,4);
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
        int osobnikow=13;
        int iteracji;
        int LBnP;
        int TurRozm=3;
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
        for (int i = 0; i < osobnikow; i++) {
            stare.Add(new osobnik(LBnP));
        }
        miejsce = LBnP * 3 - 1;
        foreach (osobnik osoba in stare)
        {
            double pa = osoba.dekodowanie(0, 3, LBnP,ref miejsce);
            double pb = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
            double pc = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
            osoba.przystosowanie=Przystosowanie(pa,pb,pc);
            miejsce = LBnP * 3 - 1;
        }
        for (int i = 0; i < iteracji; i++)
        {
            double suma = 0;
            List<osobnik> pokolenie = turniej(stare, TurRozm, osobnikow);
            osobnik najlepszy = hot_deck(stare);
            kryzowanie(pokolenie[0], pokolenie[1], LBnP);
            kryzowanie(pokolenie[2], pokolenie[3], LBnP);
            kryzowanie(pokolenie[8], pokolenie[9], LBnP);
            kryzowanie(pokolenie[pokolenie.Count-2], pokolenie[pokolenie.Count-1], LBnP);
            pokolenie=mutacja(pokolenie);
            pokolenie.Add(najlepszy);
            najlepszy = pokolenie[0];
            foreach (osobnik osoba in stare)
            {
                double pa = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
                double pb = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
                double pc = osoba.dekodowanie(0, 3, LBnP, ref miejsce);
                osoba.przystosowanie = Przystosowanie(pa, pb, pc);
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
    static double Przystosowanie(double pa, double pb, double pc)
    {
        double suma = 0;
        double[] y = {0.59554, 0.58813, 0.64181, 0.68587, 0.44783, 0.40836, 0.38241, -0.05933,-0.12478, -0.36847, -0.39935, -0.50881, -0.63435, -0.59979, -0.64107, -0.51808, -0.38127, -0.12349, -0.09624, 0.27893, 0.48965, 0.33089, 0.70615,0.53342, 0.43321, 0.64790, 0.48834, 0.18440, -0.02389, -0.10261, -0.33594,-0.35101, -0.62027, -0.55719, -0.66377, -0.62740 };
        double[] x = {-1.0, -0.8, -0.6, -0.4, -0.2, 0.0, 0.2, 0.4, 0.6, 0.8, 1.0, 1.2, 1.4, 1.6,1.8, 2.0, 2.2, 2.4, 2.6, 2.8, 3.0, 3.2, 3.4, 3.6, 3.8, 4.0, 4.2, 4.4, 4.6,4.8, 5.0, 5.2, 5.4, 5.6, 5.8, 6.0 };
        for (int i = 0; i <y.Length; i++)
        {
            double wynik = y[i] - (pa * Math.Sin((pb * x[i]) + pc));
            suma += Math.Round(Math.Pow(wynik,2),4);
        }
        return suma;
    }
    static List<osobnik> turniej(List<osobnik> populacja, int TurRozm, int osobnikow)
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
    static void kryzowanie(osobnik x1,osobnik x2,int LBnP)
    {
        Random rand = new Random();
        int cienicie=rand.Next(0,(LBnP*3)-2);
        for (int i = cienicie+1;i < LBnP; i++)
        {
            byte pamieć = x1.chromosomy[i];
            x1.chromosomy[i]=x2.chromosomy[i];
            x2.chromosomy[i] = pamieć;
        }
    }
    static List<osobnik> mutacja(List<osobnik> populacja)
    {
        double prawdopodobienstwoMutacji = 0.2;
        Random rand = new Random();
        for(int j = 4; j < populacja.Count; j++)
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
    static osobnik hot_deck(List<osobnik> osoby)
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
}


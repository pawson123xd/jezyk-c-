using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
class dane
{
    public List<double[]> list = new List<double[]>();
    public dane()
    {
        wczytywanie();
        zmomalizować();
    }
    private void wczytywanie()
    {
        /*
        try
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\Pawson\\source\\repos\\knn walidacja\\dane.txt")) // można wczytać z pliku ale trzeba podać scierzke do pliku 
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] str = Regex.Replace(line, @"\s", " ").Replace(".", ",").Split(' ');
                    double[] d = new double[str.Length];
                    for (int i = 0; i < str.Length; i++)
                    {
                        d[i] = double.Parse(str[i]);
                    }
                    list.Add(d);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik nie został znaleziony.");
        }
        finally
        {
            Console.WriteLine("wczytywanie zakończone");
        }
        */
        double[,] dane = { { 6.5, 3, 5.2, 2, 3 }, { 5.1, 2.5, 3, 1.1, 2 }, { 4.9, 3.1, 1.5, 0.1, 1 }, { 4.9, 3.1, 1.5, 0.1, 1 }, { 6.8, 3, 5.5, 2.1, 3 }, { 6.9, 3.1, 4.9, 1.5, 2 }, { 5.1, 3.3, 1.7, 0.5, 1 }, { 6, 2.9, 4.5, 1.5, 2 }, { 6.2, 2.8, 4.8, 1.8, 3 }, { 4.8, 3.1, 1.6, 0.2, 1 }, { 6.1, 2.8, 4, 1.3, 2 }, { 6.8, 3.2, 5.9, 2.3, 3 }, { 5.4, 3.4, 1.7, 0.2, 1 }, { 5, 2.3, 3.3, 1, 2 }, { 6.7, 2.5, 5.8, 1.8, 3 }, { 6.5, 2.8, 4.6, 1.5, 2 }, { 5, 3.4, 1.5, 0.2, 1 }, { 6.4, 2.7, 5.3, 1.9, 3 }, { 5.6, 3, 4.1, 1.3, 2 }, { 5.8, 2.7, 5.1, 1.9, 3 }, { 5.4, 3.9, 1.3, 0.4, 1 }, { 5.5, 2.4, 3.8, 1.1, 2 }, { 4.7, 3.2, 1.3, 0.2, 1 }, { 7.7, 3.8, 6.7, 2.2, 3 }, { 5.6, 2.8, 4.9, 2, 3 }, { 6.7, 3, 5, 1.7, 2 }, { 5.1, 3.5, 1.4, 0.2, 1 }, { 5.9, 3, 4.2, 1.5, 2 }, { 5, 3.2, 1.2, 0.2, 1 }, { 6.5, 3.2, 5.1, 2, 3 }, { 6.1, 2.6, 5.6, 1.4, 3 }, { 5.7, 4.4, 1.5, 0.4, 1 }, { 6, 2.7, 5.1, 1.6, 2 }, { 5.8, 4, 1.2, 0.2, 1 }, { 6.5, 3, 5.5, 1.8, 3 }, { 5.8, 2.7, 3.9, 1.2, 2 }, { 5, 3.5, 1.6, 0.6, 1 }, { 6, 2.2, 4, 1, 2 }, { 7.9, 3.8, 6.4, 2, 3 }, { 4.9, 3, 1.4, 0.2, 1 }, { 6.7, 3.1, 4.7, 1.5, 2 }, { 6.7, 3.3, 5.7, 2.5, 3 }, { 6.1, 2.9, 4.7, 1.4, 2 }, { 5, 3.5, 1.3, 0.3, 1 }, { 5.8, 2.8, 5.1, 2.4, 3 }, { 7.2, 3.6, 6.1, 2.5, 3 }, { 6.7, 3.1, 4.4, 1.4, 2 }, { 5.1, 3.5, 1.4, 0.3, 1 }, { 6.3, 3.3, 4.7, 1.6, 2 }, { 6.3, 3.4, 5.6, 2.4, 3 }, { 4.3, 3, 1.1, 0.1, 1 }, { 4.6, 3.1, 1.5, 0.2, 1 }, { 6.3, 3.3, 6, 2.5, 3 }, { 6.4, 2.9, 4.3, 1.3, 2 }, { 5.1, 3.8, 1.6, 0.2, 1 }, { 6.5, 3, 5.8, 2.2, 3 }, { 5.6, 2.5, 3.9, 1.1, 2 }, { 4.9, 3.1, 1.5, 0.1, 1 }, { 6.7, 3.3, 5.7, 2.1, 3 }, { 5, 2, 3.5, 1, 2 }, { 6.9, 3.1, 5.1, 2.3, 3 }, { 5.9, 3.2, 4.8, 1.8, 2 }, { 4.5, 2.3, 1.3, 0.3, 1 }, { 6.3, 2.5, 5, 1.9, 3 }, { 5.6, 2.7, 4.2, 1.3, 2 }, { 5.4, 3.9, 1.7, 0.4, 1 }, { 6.9, 3.1, 5.4, 2.1, 3 }, { 4.4, 3, 1.3, 0.2, 1 }, { 4.9, 2.4, 3.3, 1, 2 }, { 5, 3, 1.6, 0.2, 1 }, { 6.4, 2.8, 5.6, 2.2, 3 }, { 6.3, 2.3, 4.4, 1.3, 2 }, { 7.3, 2.9, 6.3, 1.8, 3 }, { 4.6, 3.2, 1.4, 0.2, 1 }, { 5.8, 2.7, 4.1, 1, 2 }, { 4.8, 3.4, 1.9, 0.2, 1 }, { 5.6, 2.9, 3.6, 1.3, 2 }, { 6.7, 3.1, 5.6, 2.4, 3 }, { 5.7, 2.5, 5, 2, 3 }, { 5.8, 2.6, 4, 1.2, 2 }, { 4.6, 3.4, 1.4, 0.3, 1 }, { 5.2, 2.7, 3.9, 1.4, 2 }, { 5.8, 2.7, 5.1, 1.9, 3 }, { 5, 3.6, 1.4, 0.2, 1 }, { 5.2, 3.5, 1.5, 0.2, 1 }, { 6.4, 3.2, 4.5, 1.5, 2 }, { 7.2, 3.2, 6, 1.8, 3 }, { 5.6, 3, 4.5, 1.5, 2 }, { 5.9, 3, 5.1, 1.8, 3 }, { 5.1, 3.7, 1.5, 0.4, 1 }, { 6.8, 2.8, 4.8, 1.4, 2 }, { 4.8, 3.4, 1.6, 0.2, 1 }, { 7.7, 3, 6.1, 2.3, 3 }, { 6.6, 3, 4.4, 1.4, 2 }, { 4.4, 2.9, 1.4, 0.2, 1 }, { 7.1, 3, 5.9, 2.1, 3 }, { 6.6, 2.9, 4.6, 1.3, 2 }, { 7.4, 2.8, 6.1, 1.9, 3 }, { 5.4, 3.7, 1.5, 0.2, 1 }, { 6.2, 3.4, 5.4, 2.3, 3 }, { 5.5, 2.3, 4, 1.3, 2 }, { 5.2, 4.1, 1.5, 0.1, 1 }, { 5, 3.4, 1.6, 0.4, 1 }, { 7, 3.2, 4.7, 1.4, 2 }, { 7.7, 2.8, 6.7, 2, 3 }, { 5.7, 3, 4.2, 1.2, 2 }, { 6.1, 3, 4.9, 1.8, 3 }, { 5.7, 3.8, 1.7, 0.3, 1 }, { 6, 3.4, 4.5, 1.6, 2 }, { 7.2, 3, 5.8, 1.6, 3 }, { 5.4, 3.4, 1.5, 0.4, 1 }, { 6.1, 3, 4.6, 1.4, 2 }, { 6.9, 3.2, 5.7, 2.3, 3 }, { 5, 3.3, 1.4, 0.2, 1 }, { 5.2, 3.4, 1.4, 0.2, 1 }, { 6.2, 2.9, 4.3, 1.3, 2 }, { 6.3, 2.9, 5.6, 1.8, 3 }, { 6.4, 3.2, 5.3, 2.3, 3 }, { 5.1, 3.8, 1.5, 0.3, 1 }, { 6.1, 2.8, 4.7, 1.2, 2 }, { 5.7, 2.9, 4.2, 1.3, 2 }, { 6, 2.2, 5, 1.5, 3 }, { 5.1, 3.8, 1.9, 0.4, 1 }, { 5.5, 4.2, 1.4, 0.2, 1 }, { 5.7, 2.8, 4.5, 1.3, 2 }, { 6.4, 2.8, 5.6, 2.1, 3 }, { 6.3, 2.5, 4.9, 1.5, 2 }, { 6, 3, 4.8, 1.8, 3 }, { 5.3, 3.7, 1.5, 0.2, 1 }, { 6.2, 2.2, 4.5, 1.5, 2 }, { 4.8, 3, 1.4, 0.3, 1 }, { 6.3, 2.7, 4.9, 1.8, 3 }, { 4.9, 2.5, 4.5, 1.7, 3 }, { 5.1, 3.4, 1.5, 0.2, 1 }, { 5.5, 2.4, 3.7, 1, 2 }, { 4.4, 3.2, 1.3, 0.2, 1 }, { 5.7, 2.6, 3.5, 1, 2 }, { 7.7, 2.6, 6.9, 2.3, 3 }, { 4.8, 3, 1.4, 0.1, 1 }, { 6.7, 3, 5.2, 2.3, 3 }, { 5.5, 2.5, 4, 1.3, 2 }, { 6.3, 2.8, 5.1, 1.5, 3 }, { 4.7, 3.2, 1.6, 0.2, 1 }, { 5.7, 2.8, 4.1, 1.3, 2 }, { 4.6, 3.6, 1, 0.2, 1 }, { 7.6, 3, 6.6, 2.1, 3 }, { 5.5, 2.6, 4.4, 1.2, 2 }, { 5.5, 3.5, 1.3, 0.2, 1 }, { 6.4, 3.1, 5.5, 1.8, 3 }, { 5.4, 3, 4.5, 1.5, 2 } };
        for (int i = 0; i < dane.GetLength(0); i++)
        {
            double[] dane1 = new double[dane.GetLength(1)];
            for(int j = 0; j < dane.GetLength(1); j++)
            {
                dane1[j]= dane[i, j];
            }
            list.Add(dane1);
        }
    }
    private void zmomalizować()
    {
        for (int i = 0; i < list[0].Length - 1; i++)
        {
            double max = list[i][0];
            double min = list[i][0];
            for (int j = 0; j < list.Count; j++)
            {
                if (min > list[j][i])
                {
                    min = list[j][i];
                }
                if (max < list[j][i])
                {
                    max = list[j][i];
                }
            }
            for (int j = 0; j < list.Count; j++)
            {
                list[j][i] = (list[j][i] - min) / (max - min);
            }
        }
    }
    class klasyfikacja : dane
    {
        public delegate double metyka(double[] a, double[] b);
        public delegate List<double[]> gropowanie(double[,] a);
        public delegate bool duplicate(List<double[]> wynik);
        private List<double[]> wynik = new List<double[]>();
        private int blad = 0;
        private int k = 0;
        public klasyfikacja(int k = 0) : base()
        {
            this.k = k;
            if (k <= 0)
            {
                this.k = 1;
            }
            walidacja();
        }
        private double manhattan(double[] a, double[] b)
        {
            double wynik = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                wynik += Math.Abs(a[i] - b[i]);
            }
            return wynik;
        }
        private double euklidesowa(double[] a, double[] b)
        {
            double wynik = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                wynik += Math.Pow(a[i] - b[i],2);
            }
            return Math.Sqrt(wynik);
        }
        private double Czebyszewe(double[] a, double[] b)
        {
            double max = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (max < Math.Abs(a[i] - b[i]))
                {
                    max = Math.Abs(a[i] - b[i]);
                }
            }
            return max;
        }
        private double logarytmem(double[] a, double[] b)
        {
            double wynik = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                wynik += Math.Abs(Math.Log(a[i]) - Math.Log(b[i]));
            }
            return wynik;
        }
        private double Minkowskiego(double[] a, double[] b)
        {
            double wynik = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                wynik+=Math.Pow(Math.Abs(a[i] - b[i]), 2);
            }
            return Math.Pow(wynik, (double)1 / 2);
        }
        private void walidacja()
        {
            Console.WriteLine("eksperymentów 1 to manhattan");
            Console.WriteLine("eksperymentów 2 to euklidesowa");
            Console.WriteLine("eksperymentów 3 to Czebyszewe");
            Console.WriteLine("eksperymentów 4 to logarytmem");
            Console.WriteLine("eksperymentów 5 to Minkowskiego");
            metyka[] m = {manhattan, euklidesowa, Czebyszewe , logarytmem,Minkowskiego};
            gropowanie g = grupowanie;
            duplicate s = duplicates;
            for (int k = 0; k < m.Length; k++)
            {
                Console.WriteLine("eksperymentów {0}",k+1);
                for (int i = 0; i < list.Count; i++)
                {
                    double[,] pamieć = new double[list.Count, 2];
                    for (int j = 0; j < list.Count; j++)
                    {
                        if(i==j)
                        {
                            continue;
                        }
                        pamieć[j, 0] = m[k](list[i], list[j]);
                        pamieć[j, 1] = list[j][list[j].Length - 1];
                    }
                    bool Duplicates = s(g(pamieć));
                    if (Duplicates)
                    {
                        List<double[]> a = g(pamieć);
                        double min = a.Min(row => row[0]);
                        for (int j = 0; j < a.Count; j++)
                        {
                            if (min == a[j][0])
                            {
                                wynik.Add([min, a[j][1]]);
                            }
                        }

                    }
                    else
                    {
                        blad++;
                    }
                }
                procenty();
            }
        }
        private List<double[]> grupowanie(double[,] a)
        {
            List<double> klasy = new List<double>();
            for (int i = 0; i < list.Count; i++)
            {
                if (klasy.Contains(list[i][list[i].Length - 1]))
                {
                    continue;
                }
                klasy.Add(list[i][list[i].Length - 1]);
            }
            List<double[]> grupowanie = new List<double[]>();
            for (int i = 0; i < klasy.Count; i++)
            {
                List<double> klasa = new List<double>();
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    if (klasy[i] == a[j, 1]&& a[j,1]!=0)
                    {
                        klasa.Add(a[j, 0]);
                    }
                }
                for (int j = 0; j < k; j++)
                {
                    double min = klasa.Min();
                    klasa.Remove(min);
                    grupowanie.Add([min, klasy[i]]);
                }
            }
            List<double[]> wynik = new List<double[]>();
            for(int i = 0; i < klasy.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < grupowanie.Count; j++)
                {
                    if (grupowanie[j][1] == klasy[i])
                    {
                        sum += grupowanie[j][0];
                    }
                }
                wynik.Add([Math.Round(sum), klasy[i]]);
            }
            return wynik;
        }
        private bool duplicates(List<double[]> wynik)
        {
            double min= wynik.Min(row => row[0]);
            double dupicates = 0;
            for (int i = 0; i<wynik.Count; i++) {
                if (dupicates >= 2)
                {
                    return false;
                }
                if (min == wynik[i][0])
                {
                    dupicates++;
                }
            }
            return true;
        }
        private void procenty()
        {

            Console.WriteLine("poprane wynik {0}%",(double)wynik.Count/list.Count*100);
            Console.WriteLine("niepoprane wynik {0}%",(double)blad/list.Count*100);
            wynik.Clear();
            blad = 0;
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            int liczba;
            klasyfikacja dane = new klasyfikacja(48);
            Console.ReadKey();
        }
    }
}

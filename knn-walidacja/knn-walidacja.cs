using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
        try
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\Pawson\\source\\repos\\knn walidacja\\dane.txt"))
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
            procenty();

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
        private void walidacja()
        {
            metyka m = manhattan;
            gropowanie g = grupowanie;
            duplicate s = duplicates;
            for (int i = 0; i < list.Count; i++)
            {
                double[,] pamieć = new double[list.Count, 2];
                for (int j = 0; j < list.Count; j++)
                {
                    if (j == i)
                    {
                        pamieć[j, 0] = 0;
                        pamieć[j, 1] = list[j][list[j].Length - 1];
                        continue;
                    }
                    pamieć[j, 0] = m(list[i], list[j]);
                    pamieć[j, 1] = list[j][list[j].Length - 1];
                }
                bool Duplicates = s(g(pamieć));
                if (Duplicates)
                {
                    List<double[]> a = g(pamieć);
                    double min = a.Min(row => row[0]);
                    for(int j = 0; j < a.Count; j++)
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
                    if (klasy[i] == a[j, 1])
                    {
                        if (a[j, 0] == 0)
                        {
                            continue;
                        }
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
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            klasyfikacja dane = new klasyfikacja(1);
            Console.ReadKey();
        }
    }
}

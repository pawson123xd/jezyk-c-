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

                    string[] str = Regex.Replace(line, @"\s", " ").Replace(".", ",").Split(" ");
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
        for (int i = 0; i < list[0].Length-1; i++)
        {
            double max = list[i][0];
            double min = list[i][0];
            for (int j = 0; j < list.Count; j++)
            {
                if(min > list[j][i])
                {
                    min= list[j][i];
                }
                if (max < list[j][i])
                {
                    max= list[j][i];
                }
            }
            for (int j = 0; j < list.Count; j++) {
                list[j][i] = (list[j][i]-min)/(max-min);
            }
        }
    }
    class klasyfikacja:dane
    {
        public delegate double metyka(double[] a,double[] b);
        public delegate double sprawdze(double[] a, double[] b);
        private List<double[]> test= new List<double[]>(); 
        private int k = 0;
        public klasyfikacja(int k=0):base() { 
            this.k = k;
            if (k <= 0) { 
                k = 2;
            }
            walidacja();
        }
        private double manhattan(double[] a, double[] b)
        {
            double wynik = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                wynik += Math.Round(Math.Abs(a[i] - b[i]),2);
            }
            return wynik;
        }
        private void walidacja()
        {
            metyka m = manhattan;
            for(int i = 0; i < list.Count-k;i++)
            {
                double[,] wynik=new double[k,3];
                int j2 = 0;
                for (int j = i;j < i+k; j++)
                {
                    wynik[j2, 0] = j;
                    wynik[j2, 1] = m(list[i], list[j]);
                    wynik[j2, 2] = list[j][list[j].Length-1];
                    j2++;
                }
                sprawdzenie(wynik, i);
                Console.WriteLine();
            }
        }
        private bool sprawdzenie(double[,] wynik,int w)
        {
            Console.WriteLine("testowa probka {0}", list[w][list[w].Length - 1]);
            Dictionary<double, int> licznik = new Dictionary<double, int>();
            bool test=true;
            double[] pamieć = new double[k];
            for (int i = 0; i < k; i++)
            {
                bool pamiec=false;
                int j2 = 0;
                for (int j = 0; j < k; j++)
                {
                    if (pamieć[j] == wynik[i, 2])
                    {
                        pamiec = true;
                    }
                }
                if (pamiec)
                {
                    continue;
                }
                for (int j = 0; j < k; j++)
                {
                    if (wynik[i, 2] == wynik[j, 2])
                    {
                        j2++;
                    }
                }
                pamieć[i] = wynik[i, 2];
                licznik.Add(wynik[i, 2], j2);
            }
            double[] max = {0, 0};
            foreach (KeyValuePair<double, int> kvp in licznik)
            {
                if (max[1] < kvp.Value)
                {
                    max[0] = kvp.Key;
                    max[1] = kvp.Value;
                }
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            }
            int j3 = 0;
            foreach (KeyValuePair<double, int> kvp in licznik)
            {
                if (max[1]==kvp.Value)
                {
                    j3++;
                }
            }
            Console.WriteLine(j3);
            if(j3 >= 2) {
                Console.WriteLine("bład Klasyfikacja ");
                return false;
            }
            else {
                if (max[0] == list[w][list[w].Length-1])
                {
                    Console.WriteLine("poprana Klasyfikacja");
                    Console.WriteLine("Przewidywana klasa {0}", max[0]);
                    return true;
                }
                Console.WriteLine("bład Klasyfikacja");
                return false;
            }
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            klasyfikacja dane = new klasyfikacja(3);

        }
    }
}

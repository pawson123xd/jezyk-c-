using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Osoba
    {
        public string imie;
        public string nazwisko;
        public int rok_urodzenia;
        public double waga;
        public double wzrost;
        public bool okulary;
        public enum plec { K, M ,blad}
        public Osoba(string imie, string nazwisko, int rok_urodzenia, double waga, double wzrost, bool okulary)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rok_urodzenia = rok_urodzenia;
            this.waga = waga;
            this.wzrost = wzrost;
        }
        public int obliczwiek()
        {
            return DateTime.Now.Year - rok_urodzenia;
        }
        public plec przedrostek(string argument)
        {
            if (argument == "k" || argument == "K" || argument == "kobieta" || argument == "Kobieta")
            {
                return plec.K;
            }
            else if (argument == "m" || argument == "M" || argument == "Mezczyzna" || argument == "mezczyzna")
            {
                return plec.M;
            }
            else
            {
                return plec.blad;
            }
        }
        public double obliczanieBmi()
        {
            double wzros =wzrost*0.01* wzrost * 0.01; ;
            double bmi= waga/wzros;
            if(bmi >= 18.5 && bmi<25 ) {
                Console.WriteLine("pacjet bmi jest prawidlowa");
                return bmi;
            }
           else if (bmi >= 20 && bmi < 30)
            {
                Console.WriteLine("pacjet ma nadwage");
                return bmi;
            }
            else {
                Console.WriteLine("pacjet ma otylosc");
                return bmi; }
        }
    }
}

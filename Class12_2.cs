using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class produkt
    {
        public int cena = 0;
        private string nazwa;
        public string[] koszy = { "" };
        private string[] pamiec = new string[100000];
        private int ilw = 1;

        public produkt(string nazwa, int cen)
        {

            this.nazwa = nazwa;
            pamiec[0] = nazwa;
            cena += cen;

        }

        public void add(string nazwa, int cen)
        {
            pamiec[ilw] = nazwa;
            koszy = new string[koszy.Length + 1];
            for (int j = 0; j < koszy.Length; j++)
            {
                koszy[j] = pamiec[j];
            }
            ilw = ilw + 1;
            cena += cen;
        }
        public void pokazy()
        {
            Console.WriteLine("ilosc produktow jest rowna {0} a suma cen {1}", koszy.Length, cena);
        }
    }
}

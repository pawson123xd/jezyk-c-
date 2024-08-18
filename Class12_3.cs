using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class dzialanie_liczb_zepolonych
    {
        public int liczba_zeczywista;
        public int liczba_zezpolona;
        public dzialanie_liczb_zepolonych(int liczba_zeczywist,int liczba_zezpolon) {
            liczba_zeczywista = liczba_zeczywist;
            liczba_zezpolona=liczba_zezpolon;
        }
        public void dodawanie(int liczba_zeczywist, int liczba_zezpolon)
        {
            liczba_zeczywista += liczba_zeczywist;
            liczba_zezpolona += liczba_zezpolon;
            Console.WriteLine("{0} {1}",liczba_zeczywista, liczba_zezpolona);
        }
        public void odejmowanie(int liczba_zeczywist, int liczba_zezpolon)
        {
            liczba_zeczywista -= liczba_zeczywist;
            liczba_zezpolona -= liczba_zezpolon;
            Console.WriteLine("{0} {1}", liczba_zeczywista, liczba_zezpolona);
        }
    }
}

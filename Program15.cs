﻿namespace program
{
    class program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                Console.WriteLine("podaj n ");
                n = int.Parse(Console.ReadLine());
                if (n > 10)
                {
                    Console.WriteLine("za duzo podqaj jeszcze raz");
                    continue;
                }
                break;
            }
            macierz(n);
        }
        static void macierz(int n)
        {
            int[,] maciez = new int[n, n];
            int element;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("podaj element");
                    element = int.Parse(Console.ReadLine());
                    maciez[i, j] = element;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(maciez[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            suma(maciez, n);
        }
        static void suma(int[,] macierz, int n)
        {
            int[] suma = new int[n];
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                int t = 0;
                for (int j = 0; j < macierz.GetLength(1); j++)
                {
                    t += macierz[j, i];
                }
                suma[i] = t;
            }
            int max = suma[0];
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                if (max < suma[i])
                {
                    max = suma[i];
                }
            }
            Console.WriteLine("najwieksza suma kolumny jest {0}", max);

        }
    }
}
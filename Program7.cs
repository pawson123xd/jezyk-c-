namespace przygotowania_do_kolos
{
    class program
    {
        static void Main(string[] args)
        {
            int[] tab = { 1, 3, 6, 9, 7 };
            for(int i = 0; i < tab.Length; i++)
            {
                for(int j = 0; j < tab.Length; j++)
                {
                    int pow = tab[j];
                    if (tab[i] < tab[j])
                    {
                        tab[i]= tab[j];
                        tab[i-1]= pow;
                    }
                    else
                    {

                    }

                }
            }
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }


        }
        static void zadanie(int x, int n)
        {
            int suma = 0;
            for (int i = 1; i <= n; i++)
            {
                suma += i+x;
            }
            Console.WriteLine(suma);
        }

    }
}
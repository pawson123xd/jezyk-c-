namespace projekt2
{
    class program
    {
        public static void Main(String[] args)
        {
            string text = "ala ala ma ma ma kota";
            string[] lista = { "" };
            lista = text.Split(new char[] { ' ' });
            zadanie2(lista);
            Console.ReadLine();
        }
        static void zadanie1()
        {
            string[] test = { "kong-2005", "kong-2010", "kong-2011", "kn-2040", "kg-2030" };
            string[] lista = { "" };
            string listb = "";
            int pamiec = 0;
            int[] rok1 = { 2, 3, 4, 45, 6 };
            for (int i = 0; i < test.Length; i++)
            {
                listb += test[i] + " ";

            }
            Console.WriteLine(listb);
            lista = listb.Split(new char[] { ' ', '-' });
            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine(lista[i]);
                bool x = int.TryParse(lista[i], out int rok);
                if (x == true)
                {
                    listb = lista[i];

                    rok1[pamiec] = int.Parse(listb);
                    pamiec++;
                }
            }
            int liczba;
            for (int i = 0; i < rok1.Length; i++)
            {
                Console.WriteLine("rok {0}", rok1[i]);
                for (int j = 1; j < rok1.Length; j++)
                {
                    liczba = rok1[j] - rok1[i];
                    if (liczba <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        liczba = rok1[j] - rok1[i];
                        Console.WriteLine("od roku {0} do roku{1} mielo {2} lat", rok1[i], rok1[j], liczba);
                    }

                }

            }
        }
        static void zadanie2(string[] lista)
        {
            string pamiec = "";
            for (int i = 0; i < lista.Length; i++)
            {
                int ile = 0;
                if (lista[i] == pamiec)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < lista.Length; j++)
                    {
                        if (lista[i] == lista[j])
                        {
                            ile++;
                        }
                        if (j == lista.Length - 1)
                        {
                            Console.WriteLine("slowo {0} wystopilo {1}", lista[i], ile);
                        }
                    }
                }
                pamiec = lista[i];
            }
        }
        static void zadanie14()
        {
            string[] test = { "kong-2005", "bh-2010", "whng-2011", "kn-2020", "kg-2021" };
            string[] lista = { };
            string listb = "";
            int pamiec = 0;
            int[] rok1 = new int[5];
            for (int i = 0; i < test.Length; i++)
            {
                listb += test[i] + " ";

            }
            lista = listb.Split(new char[] { ' ', '-' });
            for (int i = 0; i < lista.Length; i++)
            {
                bool x = int.TryParse(lista[i], out int rok);
                if (x == true)
                {

                    rok1[pamiec] = int.Parse(lista[i]);
                    pamiec++;
                }
            }
            int liczba;
            for (int i = 0; i < rok1.Length; i++)
            {
                Console.WriteLine("rok {0}", rok1[i]);
                for (int j = 1; j < rok1.Length; j++)
                {
                    liczba = rok1[j] - rok1[i];
                    if (liczba <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("od roku {0} do roku{1} mielo {2} lat", rok1[i], rok1[j], liczba);
                    }

                }

            }

        }

    }
}

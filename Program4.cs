namespace projekt2 {
    class program
    {
        public static void Main(String[] args)
        {
            zadanie4();
            Console.ReadLine();
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
                liczba = 2023-rok1[i];
                Console.WriteLine("od roku {0} do roku 2023 mielo {1} lat", rok1[i], liczba);

            }

        }
        static void zadanie1()
        {
            Console.WriteLine("podaj ile chcesz elemetow");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] tab = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("podaj liczbe do elementu");
                int w= Convert.ToInt32(Console.ReadLine());
                tab[i] = w;
            } 
            for(int i = 0;i < n; i++)
            {
                Console.WriteLine(tab[i]);
            }
        }
        static void zadanie2() {
            int[] tab1 = new int[10];
            int[] tab2 = new int[10];
            tab1[0] = 12;
            tab1[1] = 13;
            tab1[2] = 14;
            tab1[3] = 14;
            tab1[4] = 4;
            tab1[5] = 5;
            tab1[6] = 14;
            tab1[7] = 14;
            tab1[8] = 14;
            tab1[9] = 14;
            Array.Copy(tab1,0, tab2,0,10);
            for (int i = 0; i < tab2.Length; i++)
            {
                Console.WriteLine(tab2[i]);
            }
        }
        static void zadanie3()
        {
            Console.WriteLine("podaj ile chcesz elemetow");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] tab = new int[n];
            var suma = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("podaj liczbe do elementu");
                int w = Convert.ToInt32(Console.ReadLine());
                tab[i] = w;
            }
            int min_max = tab[0];
            for (int i = 0; i < n; i++)
            {
                if (tab[i] < min_max)
                {
                    min_max= tab[i];
                }
            }
            Console.WriteLine("min {0}",min_max);
            for (int i = 0; i < n; i++)
            {
                if (tab[i] > min_max)
                {
                    min_max = tab[i];
                }
            }
            Console.WriteLine("max {0}",min_max);
            for (int i = 0; i < n; i++)
            {
                suma += tab[i];
            }
            Console.WriteLine("srednia {0}", (double)suma/n);
            Console.WriteLine("dodatnie liczby");
            for (int i = 0; i < n; i++)
            {
                if (tab[i] > 0)
                {
                    Console.WriteLine(tab[i]);
                }
            }
        }
        static void zadanie4()
        {
            short ile = 0;
            int[] tab1 = new int[100];
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                tab1[i] = rand.Next(1, 1000);
            }
            for (int i = 0; i < 100; i++)
            {
                int dzilniki = 0;
                for (int j = 1; j < 1000; j++) {
                    if (tab1[i] % j == 0)
                    {
                        dzilniki++;
                    }
                }
                if (dzilniki == 2) {
                    ile++;
                }
            }
            Console.WriteLine("liczby pierwszych jest {0}",ile);
        }
        static void zadanie5()
        {
            int[] tab1 = { 1, 23, 4, 5, 6, 7, 8 };
            int[] tab2 = new int[tab1.Length];
            tab2[0] = tab1[tab1.Length-1];
            Array.Copy(tab1,0,tab2,1,tab1.Length-1);
            for (int i = 0; i < tab2.Length; i++)
            {
                Console.WriteLine(tab2[i]);
            }
        }
        static void zadanie6()
        {
            int suma = 0;
            int[][] tab1 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4,5},

            };
            for (int i=0; i<tab1.Length; i++) {
                for(int j=0; j < tab1[i].Length; j++) {
                    Console.Write(tab1[i][j]);
                }
                suma += tab1[i][i];
                Console.WriteLine();
            }   
            Console.WriteLine("suma przekattych jest rowne {0}",suma);
        }
        static void zadanie7()
        {
            int[][] tab1 = {
                new int[] {1,2,3},
                new int[] {1,2,0},
            };
            int[][] tab2 = {
                new int[] {3,2,3},
                new int[] {4,2,5},
            };
            int[][] tab3 = new int [][] {
                new int[3],
                new int[3]
            };
            for (int i = 0; i < tab1.Length; i++)
            {
                for (int j = 0; j < tab1[i].Length; j++)
                {
                    tab3[i][j] = tab1[i][j]+tab2[i][j];
                    Console.Write(tab3[i][j]);
                }
                Console.WriteLine();
            }
        }
        static void zadanie8()
        {
            string[,] dniTygodnia;
            dniTygodnia = new string[7, 3]; // pamiętaj o zmianie rozmiaru tablicy
            dniTygodnia[0, 0] = "poniedzialek";
            dniTygodnia[1, 0] = "wtorek";
            dniTygodnia[2, 0] = "sroda";
            dniTygodnia[3, 0] = "czwartek";
            dniTygodnia[4, 0] = "piatek";
            dniTygodnia[5, 0] = "sobota";
            dniTygodnia[6, 0] = "niedziela";
            dniTygodnia[0, 1] = "monday";
            dniTygodnia[1, 1] = "tuesday";
            dniTygodnia[2, 1] = "Wednesday";
            dniTygodnia[3, 1] = "Thursday";
            dniTygodnia[4, 1] = "Friday";
            dniTygodnia[5, 1] = "Saturday";
            dniTygodnia[6, 1] = "Sunday";
            dniTygodnia[0, 2] = "montag";
            dniTygodnia[1, 2] = "dienstag";
            dniTygodnia[2, 2] = "Mittwoch";
            dniTygodnia[3, 2] = "Donnerstag";
            dniTygodnia[4, 2] = "Freitag";
            dniTygodnia[5, 2] = "Samstag";
            dniTygodnia[6, 2] = "Sonntag";

            for (int i = 0; i < dniTygodnia.GetLength(0); i++) {
                for (int j = 0; j < dniTygodnia.GetLength(1); j++)
                {
                    Console.WriteLine(dniTygodnia[i, j].ToString());
                }
                Console.WriteLine();
            }

        }
        static void zadanie9()
        {
            Console.WriteLine("napisz cos");
            string text = Console.ReadLine();
            int ile = 0;
            for(int i = 0;i < text.Length; i++)
            {
              ile++;
            }
            Console.WriteLine("liczba znakow jest rowna {0}",ile);

        }
        static void zadanie10()
        {
            Console.WriteLine("podaj date w formacie dd-mm-rrrr");
            string data = Console.ReadLine();
            string[] lista=data.Split('-');
            int miesioc = int.Parse(lista[lista.Length / 2]);
            string[] miesioce = {"","styczeni","luty","marzec","kwiecien","may","czerwiec","lipiec","sierpien","wrzesien","pazdziernik","listopad","grudzienie"};
            for (int i = 1; i < miesioce.Length; i++) {
                if (miesioc == i) {
                    Console.WriteLine("jest {0}", miesioce[i]);
                    break;
                }
                if(i==miesioce.Length-1||miesioc==0)
                {
                    Console.WriteLine("nie ma tekiego miesiaca");
                    break;
                }
            }

        }
        static void zadanie11()
        {
            string text = Console.ReadLine();
            char[] pamiec=new char[text.Length];
            char znak;
            for (int i = 0;i<text.Length; i++)
            {
                int ile = 0;
                bool conty = false;
                znak = text[i];
                for (int j = 0; j < pamiec.Length; j++)
                {
                    if (znak == pamiec[j])
                    {
                        conty = true;
                    }
                }
                if (conty == true)
                {
                    continue;
                }
                for (int j = 0; j < text.Length; j++) {
                    if (znak == text[j]) {
                        ile++;
                    }
                }
                pamiec[i] = znak;
                Console.WriteLine("znak {0} powtarza sie {1}",znak, ile);
            }

        }
        static void zadanie12()
        {
            string tekst = "W parę godzin później, gdy noc zbierała się do odejścia,\n" +
                             "Puchatek obudził się nagle z uczuciem dziwnego przygnębienia.\n" +
                             "To uczucie dziwnego przygnębienia miewał już nieraz i wiedział,\n" +
                             "co ono oznacza. Był głodny. Więc poszedł do spiżarni,\n" +
                             "wgramolił się na krzesełko, sięgnął na górną półkę, ale nic nie znalazł.";
            string[] lista =tekst.Split(' ');
            int ile = 0;
            Console.WriteLine("liczba wierszy jest rowne {0}", lista.Length);
            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine("wiersz {0} ma znakow {1}",lista[i], lista[i].Length);
            }
        }
        static void zadanie13()
        {
            string tekst = "Kiedy idzie się po miód z balonikiem, to trzeba się starać, żeby pszczoły nie wiedziały, po co się idzie – odpowiedział Puchatek";
            string[] lista=tekst.Split(" ");
            string[] pamiec = new string[lista.Length];
            for(int i = 0;i < lista.Length; i++)
            {
                int ile = 0;
                bool start = false;
                for(int z=0;z<pamiec.Length;z++)
                {
                    if (lista[i] == pamiec[z])
                    {
                        start = true;
                        break;
                    }
                }
                if (start == true)
                {
                    continue;
                }
                for (int j = 0; j < lista.Length; j++) {
                    if (lista[i] == lista[j])
                    {
                        ile++;
                    }
                }
                if (ile >= 2) {
                    Console.WriteLine("{0}={1}",lista[i],ile);
                    pamiec[i] = lista[i];
                }
            }
        }
    }
}
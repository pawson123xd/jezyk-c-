namespace zadanie2
{
    class zadniaa
    {
        static void Main(string[] args)
        {
            //zadanie1();
            //zadanie2();
            //zadanie3();
            //zadanie4();
            //zadanie5();
            //zadanie6();
            //zadanie7();
            //zadanie8();
            //zadanie9();
            //zadanie10();
            //zadanie11();
            zadanie12();
            //zadanie13();
            //zadanie14();
            Console.ReadKey();
        }
        static void zadanie1()
        {
            int rok = int.Parse(Console.ReadLine());
            if (rok == 400)
            {
                Console.WriteLine("rok {0} nie jest rokiem przestepcyn", rok);
            }
            else if (rok % 4 == 0)
            {
                Console.WriteLine("rok {0} jest rokiem przestepcyn", rok);
            }
            else
            {
                Console.WriteLine("rok {0} nie jest rokiem przestepcyn", rok);
            }
        }
        static void zadanie2()
        {
            int pierwsza, druga;
            pierwsza = int.Parse(Console.ReadLine());
            druga = int.Parse(Console.ReadLine());
            if (pierwsza % druga == 0)
            {
                Console.WriteLine("jest dzielnikiem");
            }
            else
            {
                Console.WriteLine("nie jest dzielnikiem");
            }
        }
        static void zadanie3()
        {
            int pierwsza, druga, trzecia;
            Console.WriteLine("podaj liczbe");
            pierwsza = int.Parse(Console.ReadLine());
            Console.WriteLine("podaj liczbe");
            druga = int.Parse(Console.ReadLine());
            Console.WriteLine("podaj liczbe");
            trzecia = int.Parse(Console.ReadLine());
            int[] TAB = { pierwsza, druga, trzecia };
            int max = TAB[0];
            for (int i = 0; i < TAB.Length; i++)
            {
                if (max < TAB[i])
                {
                    max = TAB[i];
                }
            }
            Console.WriteLine("najwieksza liczba to {0}", max);
        }
        static void zadanie4()
        {
            short wybor;
            double piewsza, druga;
            Console.WriteLine("podaj liczbe");
            piewsza = double.Parse(Console.ReadLine());
            Console.WriteLine("podaj liczbe");
            druga = double.Parse(Console.ReadLine());
            Console.WriteLine("1=+,2=-,3=/,4=*");
            wybor = short.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Console.WriteLine((double)(piewsza + druga));
                    break;
                case 2:
                    Console.WriteLine((double)(piewsza - druga));
                    break;
                case 3:
                    Console.WriteLine((double)(piewsza / druga));
                    break;
                case 4:
                    Console.WriteLine((double)piewsza * (double)druga);
                    break;
                default:
                    Console.WriteLine("nie takiego symbolu");
                    break;
            }
        }
        static void zadanie5()
        {
            double a, b, c, delta, x1, x2;
            Console.WriteLine("podaj liczbe");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("podaj liczbe");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("podaj liczbe");
            c = double.Parse(Console.ReadLine());
            delta = b * b - 4 * a * c;
            if (delta < 0)
            {
                Console.WriteLine("delta jest ujemna");
            }
            else
            {
                x1 = (b * -1 - Math.Sqrt(delta)) / (a * 2);
                x2 = (b * -1 + Math.Sqrt(delta)) / (a * 2);
                Console.WriteLine("x1={0},x2={1}", x1, x2);
            }
        }
        static void zadanie6()
        {
            double bmi;
            float wzrost, waga;
            Console.WriteLine("podaj wzrost");
            wzrost = float.Parse(Console.ReadLine());
            Console.WriteLine("podaj wage");
            waga = float.Parse(Console.ReadLine());
            bmi = waga / Math.Pow(wzrost, 2);
            if (bmi < 18.5)
            {
                Console.WriteLine("masz niedowage");
            }
            else if (bmi > 25.0 && bmi < 30.0)
            {
                Console.WriteLine("masz nadwage");
            }
            else if (bmi >= 30.0 && bmi < 35.0)
            {
                Console.WriteLine("masz otylosci stopnia 1");
            }
            else if (bmi >= 35.0)
            {
                Console.WriteLine("masz otylosci stopnia 2");
            }

            else
            {
                Console.WriteLine("twoja waga jest normie");
            }
            Console.WriteLine(bmi);

        }
        static void zadanie7()
        {
            Console.WriteLine("podaj srednia ocen");
            float srednia_ocen = float.Parse(Console.ReadLine());
            if (srednia_ocen >= 2.0 && srednia_ocen <= 3.99)
            {
                Console.WriteLine("towje stypedium wynosi 0");
            }
            else if (srednia_ocen >= 4.0 && srednia_ocen < 4.79)
            {
                Console.WriteLine("towje stypedium wynosi 350.00");
            }
            else
            {
                Console.WriteLine("towje stypedium wynosi 550.00");
            }
        }
        static void zadanie8()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   *");
            Console.WriteLine("  **");
            Console.WriteLine(" ***");
            Console.WriteLine("****");
            Console.WriteLine();
            Console.WriteLine("****");
            Console.WriteLine("*  *");
            Console.WriteLine("*  *");
            Console.WriteLine("*  *");
            Console.WriteLine("****");
        }
        static void zadanie9()
        {
            Console.WriteLine("podaj sinianie");
            int sinianie = int.Parse(Console.ReadLine());
            long x = 1;
            for (int i = 1; i <= sinianie; i++)
            {
                x *= i;
            }
            Console.WriteLine("sinia jest rowani {0}", x);
        }
        static void zadanie10()
        {
            int x = 0;
            for (int i = 1; i <= 100; i++)
            {
                x += i;
                if (x > 100)
                {
                    Console.WriteLine("liczby sumowalo sie {0} raz", i);
                    break;
                }
            }
        }
        static void zadanie11()
        {
            int x;
            int suma = 0;
            bool petla = true;
            while (petla)
            {
                Console.WriteLine("jesli chce zakoniczyc napisz 0");
                x = int.Parse(Console.ReadLine());
                if (x == 0)
                {
                    petla = false;
                }
                else
                {
                    suma += x;
                }
            }
            Console.WriteLine("twoja suma wynos {0}", suma);
        }
        static void zadanie12()
        {
            Console.WriteLine("podaj liczbe n do szeregu w=1-2+3-4....(+-)n");
            int n = int.Parse(Console.ReadLine());
            int suma = 0;
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    suma -= i;
                }
                else
                {
                    suma += i;
                }
            }
            Console.WriteLine("twoj szeregu w=1-2+3-4....(+-)n jest rowny {0}", suma);
        }
        static void zadanie13()
        {
            Console.WriteLine("podaj liczbe");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int suma = 0;
                for (int j = 1; j < i; j++)
                    if (i % j == 0)
                    {
                        suma = suma + j;
                    }
                if (suma == i)
                {
                    Console.WriteLine("Liczba {0} jest liczbą doskonałą", i);
                }
            }
        }
        static void zadanie14()
        {
            for (int i = 0; i <= 10; i++) {
                for (int j = 0; j <= 5; j++) { 
                    for(int z = 0; z <= 2; z++) {
                        if (i * 1 + j * 2 + z * 5 == 10) {
                            Console.WriteLine("jedne zlote={0},dwa zlote={1},piec zlote={2}",i,j,z);
                        }
                    }
                }
            }
        }
    }
    }

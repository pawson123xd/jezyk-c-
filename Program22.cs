namespace zadanie2
{
    class zadniaa
    {
        static void Main(string[] args)
        {
            zadanie1();
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
            //zadanie12();
            //zadanie13();
            //zadanie14();
            Console.ReadKey();
        }
        static void zadanie1()
        {
            int rok = int.Parse(Console.ReadLine());
            if (rok % 100 == 0)
            {
                if (rok % 400 == 0)
                {
                    Console.WriteLine("rok {0} jest rokiem przestepcyn", rok);
                }
                else
                {
                    Console.WriteLine("rok {0} nie  jest rokiem przestepcyn", rok);
                }
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
    }
}
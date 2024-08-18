namespace project
{
    class project {
        static void Main(string[] args)
        {
            //zadanie2_1();
            //zadanie2_2();
            //zadanie2_3();
            //zadanie2_4();
            //zadanie2_5();
            //zadanie2_6();
            //zadanie2_7();
            //zadanie2_8();
            //zadanie2_9a();
            // zadanie2_9b();
            // zadanie2_9c();
            //zadanie2_9d();
            //  zadanie2_9e();
            // zadanie2_9f();
            zadanie2_10();
            Console.ReadKey();



        }
        static void zadanie2_1() {
            int c;
            Console.WriteLine("podaj stopien celnciusza");
            c = int.Parse(Console.ReadLine());
            float f = 32f + 9 / 5f * c;
            Console.WriteLine("zmiania na stopania fahrenheina={0}", f);
        }
        static void zadanie2_2()
        {
            int a, b, c, x1, x2, delta;
            Console.WriteLine("podaj a do rowniania");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("podaj b do rowniania");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("podaj c do rowniania");
            c = int.Parse(Console.ReadLine());
            delta = b * b - 4 * a * c;
            if (delta < 0)
            {
                Console.WriteLine("delta jest ujemna");
            }
            else
            {
                Console.WriteLine("daelta jest rowna {0}", delta);
            }
        }
        static void zadanie2_3()
        {
            int masa, wzrost;
            float bMI;
            Console.WriteLine("podaj masa");
            masa = int.Parse(Console.ReadLine());
            wzrost = int.Parse(Console.ReadLine());
            bMI = (float)masa / (float)wzrost;
            Console.WriteLine("twoja bmi jest {0}", bMI);
        }
        static void zadanie2_4()
        {
            int x = 100;
            Console.WriteLine(++x * 2);
            // to jest odpowiedz a
        }
        static void zadanie2_5() {
            int x = 2, y = 3;
            x *= y * 2;
            // to jest odpowiedz d
        }
        static void zadanie2_6()
        {
            int x, y = 4;
            x = (y -= 2);
            x = y++;
            x = y--;
            //3
        }
        static void zadanie2_7() {
            int x, y = 5;
            x = ++y * 2;
            x = y++;
            x = y--;
            //7
        }
        static void zadanie2_8()
        {
            bool x;
            int y = 1, z = 1;
            x = (y == 1 && z++==1);
            // to bedzie a
        }
        static void zadanie2_9a()
        {
            int x=1, y=4, z=2;
            bool wynik = (x++ > 1 && y++ == 4 && z-- > 0);
            // wynik=false,x=2,y=4,z=2
            Console.WriteLine("wynik={0} x={1} y={2} z={3}", wynik, x, y, z);
        }
        static void zadanie2_9b()
        {
            int x = 1, y = 4, z = 2;
            bool wynik = (x++ > 1 & y++ == 4 && z-- > 0);
            // wynik=false,x=2,y=5,z=2
            Console.WriteLine("wynik={0} x={1} y={2} z={3}", wynik, x, y, z);
        }
        static void zadanie2_9c()
        {
            int x = 1, y = 4, z = 2;
            bool wynik = (x++ > 1 & y++ == 4 && z-- > 0);
            // wynik=false,x=2,y=5,z=1
            Console.WriteLine("wynik={0} x={1} y={2} z={3}", wynik, x, y, z);
        }
        static void zadanie2_9d()
        {
            int x = 1, y = 3, z = 4;
            bool wynik = (x == 1 || y++ > 2 || ++z > 0);
            // wynik=true,x=1,y=3,z=4
            Console.WriteLine("wynik={0} x={1} y={2} z={3}", wynik, x, y, z);
        }
        static void zadanie2_9e()
        {
            int x = 1, y = 3, z = 4;
            bool wynik = (x == 1 | y++ > 2 || ++z > 0);
            // wynik=true,x=1,y=4,z=4
            Console.WriteLine("wynik={0} x={1} y={2} z={3}", wynik, x, y, z);
        }
        static void zadanie2_9f()
        {
            int x = 1, y = 3, z = 4;
            bool wynik = (x == 1 | y++ > 2 | ++z > 0);
            // wynik=true,x=1,y=4,z=5
            Console.WriteLine("wynik={0} x={1} y={2} z={3}", wynik, x, y, z);
        }
        static void zadanie2_10()
        {
            int powierzchnia = 100, osoby = 10;
            double gestosczaludnia = (double)osoby / (double)powierzchnia;
            Console.WriteLine(gestosczaludnia);
        }
    }
}
namespace projemt
{
    class program
    {
        static int oblicz(int n)
        {
            if (n==1)
            {
                return 1;
            }
            else
            {
                return(n+oblicz(n-1));
            }
        }
        static void Main(String[] args)
        {
            for (int i = 1; i < 100; i++) {
                short ile = 0;
                for (int j = 1; j < 100; j++) { 
                    if(i%j==0)
                    {
                        ile++;
                    }
                }
                if (ile>= 3)
                {
                    continue;
                }
                Console.WriteLine(i);
            }

        }
    }
}
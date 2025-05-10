class sieć {
    public double[,] warstwy = new double[1, 2];
    public double[] wagi=new double[6];
    public double[] bias = new double[3];
    public sieć()
    {
        Random rand = new Random();
        for (int i = 0; i < bias.Length; i++)
        {
            bias[i] = rand.NextDouble() * 10 - 5;
        }
        for (int i = 0; i < wagi.Length; i++)
        {
            wagi[i] = rand.NextDouble()*10-5;
        }
    }
    public void tranig(int epok, double u)
    {
        int[,] wejscia = { { 0, 0 }, { 0, 1 },  { 1, 0 }, { 1, 1 } };
        int[] wyjscie = { 0, 1, 1, 0 };
        for (int j = 0; j < epok; j++)
        {
            double error = 0;
            for (int i = 0; i < wejscia.GetLength(0); i++)
            {
                int wagi_miejsce = 0;
                int bias_miejsce = 0;
                for (int k=0; k < warstwy.GetLength(1); k++)
                {
                    warstwy[0,k] =sigmain((wejscia[i, 0] * wagi[wagi_miejsce] + wejscia[i, 1] * wagi[wagi_miejsce + 1]) + bias[bias_miejsce]);
                    bias_miejsce += 1;
                    wagi_miejsce += 2;
                }
                double wynik = sigmain((warstwy[0, 0] * wagi[wagi_miejsce] + warstwy[0, 1] * wagi[wagi_miejsce + 1]) + bias[bias_miejsce]);
                double blad = wyjscie[i]- wynik;
                error += Math.Pow(blad,2);
                blad = blad * u;
                double delta = pochodnasigmain(wynik, blad);
                wagi_miejsce += 1;
                double[] blady = new double[3];
                blady[2] = delta;
                for (int k = blady.Length - 2; k >= 0; k--)
                {
                    double x = delta * wagi[wagi_miejsce];
                    wagi_miejsce -= 1;
                    blady[k] = x * warstwy[0, k] * (1 - warstwy[0,k]);
                }
                wagi_miejsce += 2;
                for (int k = blady.Length - 1; k >= 0; k--)
                {
                    bias[bias_miejsce] += blady[k];
                    bias_miejsce -= 1;
                }
                for (int k = blady.Length - 1; k >= 0; k--)
                {
                    if (k <= warstwy.GetLength(1) - 1)
                    {
                        wagi[wagi_miejsce - 1] += wejscia[i,0]*blady[k];
                        wagi[wagi_miejsce] += wejscia[i, 1] * blady[k];
                        wagi_miejsce -= 2;
                    }
                    else 
                    {
                        wagi[wagi_miejsce - 1] += blady[k] * warstwy[0, 0];
                        wagi[wagi_miejsce] += blady[k] * warstwy[0, 1];
                        wagi_miejsce -= 2;
                    }
                }
                wagi_miejsce = 0;
                bias_miejsce = 0;
                for (int k = 0; k < warstwy.GetLength(1); k++)
                {
                    warstwy[0, k] = sigmain((wejscia[i, 0] * wagi[wagi_miejsce] + wejscia[i, 1] * wagi[wagi_miejsce + 1]) + bias[bias_miejsce]);
                    bias_miejsce += 1;
                    wagi_miejsce += 2;
                }
                wynik = sigmain((warstwy[0, 0] * wagi[wagi_miejsce] + warstwy[0, 1] * wagi[wagi_miejsce + 1]) + bias[bias_miejsce]);
            }
            if(error < 0.3)
            {
                Console.WriteLine(error);
            }
        }
    }
    public double sigmain(double x)
    {
        return (1/(1+Math.Exp(-x)));
    }
    public double pochodnasigmain(double x,double y) { 
        return y * x * (1 - x);
    }
}
class program
{
    static void Main(string[] args)
    {
        sieć Siec=new sieć();
        int epok = 50000;
        double u = 0.3;
        Siec.tranig(epok,u);


    }
}

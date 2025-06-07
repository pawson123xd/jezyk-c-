using static System.Runtime.InteropServices.JavaScript.JSType;

class sieć
{
    public List<double[]> warstwy = new List<double[]>();
    public double[] wagi;
    public double[] bias;
    public sieć(int wagi_miejsce, int bias_miejsce, List<double[]> warstwy)
    {
        Random rand = new Random();
        wagi = new double[wagi_miejsce];
        bias = new double[bias_miejsce];
        for (int i = 0; i < wagi_miejsce; i++)
        {
            wagi[i] = rand.NextDouble() * 10 - 5;
        }
        for (int i = 0; i < bias_miejsce; i++)
        {
            bias[i] = rand.NextDouble() * 10 - 5;
        }
        this.warstwy = warstwy;
        for (int i = 0; i < warstwy.Count; i++)
        {
            for (int j = 0; j < warstwy[i].Length; j++)
            {
                warstwy[i][j] = 0.0;
            }
        }
    }
    private void propagacja(ref int wagi_miejsce, ref int bias_miejsce, int[,] wejscia, int k)
    {
        for (int i = 0; i < warstwy.Count; i++)
        {
            for (int j = 0; j < warstwy[i].Length; j++)
            {
                if (i == 0)
                {
                    for (int l = 0; l < wejscia.GetLength(1); l++)
                    {
                        warstwy[i][j] += wejscia[k, l] * wagi[wagi_miejsce];
                        wagi_miejsce++;
                    }
                }
                else
                {
                    for (int l = 0; l < warstwy[i - 1].Length; l++)
                    {
                        warstwy[i][j] += warstwy[i - 1][l] * wagi[wagi_miejsce];
                        wagi_miejsce++;
                    }
                }
                warstwy[i][j] += bias[bias_miejsce];
                warstwy[i][j] = sigmain(warstwy[i][j]);
                bias_miejsce++;
            }
        }
        bias_miejsce--;
        wagi_miejsce--;

    }
    private void propagacja_wsteczna(ref double[] error, double u, int[,] wejscia, int[,] wyjscie, ref int wagi_miejsce, ref int bias_miejsce, int i)
    {
        List<double> kopia_bias = new List<double>();
        List<double> kopia_wagi = new List<double>();
        for (int j = 0; j < bias.Length; j++)
        {
            kopia_bias.Add(bias[j]);
        }
        for (int j = 0; j < wagi.Length; j++)
        {
            kopia_wagi.Add(wagi[j]);
        }
        for (int j = warstwy[warstwy.Count - 1].Length - 1; j >= 0; j--)
        {
            double blad = wyjscie[i, j] - warstwy[warstwy.Count - 1][j];
            error[j] += Math.Pow(blad, 2);
            blad = blad * u;
            warstwy[warstwy.Count - 1][j] = pochodnasigmain(warstwy[warstwy.Count - 1][j], blad);
            kopia_bias[bias_miejsce] += warstwy[warstwy.Count - 1][j];
            bias_miejsce--;
        }
        for (int j = warstwy.Count - 2; j >= 0; j--)
        {
            int licznik = 0;
            for (int k = warstwy[j].Length - 1; k >= 0; k--)
            {
                double suma = 0;
                int kopia_wagi1 = wagi_miejsce;
                for (int l = warstwy[j + 1].Length - 1; l >= 0; l--)
                {
                    kopia_wagi[kopia_wagi1] += warstwy[j + 1][l] * warstwy[j][k];
                    kopia_wagi1 -= warstwy[j].Length;
                }
                kopia_wagi1 = wagi_miejsce;
                for (int l = warstwy[j + 1].Length - 1; l >= 0; l--)
                {
                    suma += warstwy[j + 1][l] * wagi[kopia_wagi1];
                    kopia_wagi1 -= warstwy[j].Length;

                }
                warstwy[j][k] = pochodnasigmain(warstwy[j][k], suma);
                kopia_bias[bias_miejsce] -= warstwy[j][k];
                bias_miejsce--;
                if (k == 0)
                {
                    wagi_miejsce += licznik;
                    wagi_miejsce -= warstwy[j].Length * warstwy[j + 1].Length;
                }
                else
                {
                    wagi_miejsce--;
                    licznik++;
                }
            }
        }
        for (int j = warstwy[0].Length - 1; j >= 0; j--)
        {
            for (int k1 = wejscia.GetLength(1) - 1; k1 >= 0; k1--)
            {
                kopia_wagi[wagi_miejsce] += wejscia[i, k1] * warstwy[0][j];
                wagi_miejsce--;
            }
        }
        for (int j = 0; j < wagi.Length; j++)
        {
            wagi[j] = kopia_wagi[j];
        }
        for (int j = 0; j < bias.Length; j++)
        {
            bias[j] = kopia_bias[j];
        }
        wagi_miejsce = 0;
        bias_miejsce = 0;
    }
    public void tranig(int epok, double u, int[,] wejscia, int[,] wyjscie)
    {
        for (int j = 0; j < epok; j++)
        {
            double[] error = new double[warstwy[warstwy.Count - 1].Length];
            for (int i = 0; i < error.Length; i++)
            {
                error[i] = 0;
            }
            for (int i = 0; i < wejscia.GetLength(0); i++)
            {
                int wagi_miejsce = 0;
                int bias_miejsce = 0;
                propagacja(ref wagi_miejsce, ref bias_miejsce, wejscia, i);
                propagacja_wsteczna(ref error, u, wejscia, wyjscie, ref wagi_miejsce, ref bias_miejsce, i);
                propagacja(ref wagi_miejsce, ref bias_miejsce, wejscia, i);
            }
            for (int i = 0; i < error.Length; i++)
            {
                Console.WriteLine(error[i]);
            }
        }
    }
    public double sigmain(double x)
    {
        return (1 / (1 + Math.Exp(-x)));
    }
    public double pochodnasigmain(double x, double y)
    {
        return y * x * (1 - x);
    }
}
class program
{
    static void Main(string[] args)
    {
        int[,] wejscia=null;
        int[,] wyjscie = null;
        Console.WriteLine("numer 1 wejscia: { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } } i wejscie: { { 0 }, { 1 }, { 1 }, { 0 } }");
        Console.WriteLine("numer 2 wejscia: { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } } i wejscie: { 0, 1 }, { 1, 0 }, { 1, 0 }, { 0, 0 }");
        Console.WriteLine("numer 3 wejscia: { { 0, 0,0 },  { 0, 1,0 }, { 1, 0 ,0}, { 1, 1 ,0}, { 0,0,1 }, { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 }}\ni wejscie: { {0 ,0}, { 1,0 }, { 1,0 }, { 0, 1 }, { 1, 0 }, { 0, 1 }, { 0, 1 }, { 1, 1 } }");
        while (true) {
            Console.WriteLine("podaj numer");
            int numer = int.Parse(Console.ReadLine());
            if (numer == 1) {
                wejscia = new int[,]{ { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
                wyjscie = new int[,]{ { 0 }, { 1 }, { 1 }, { 0 } };
                break;
            }
            else if (numer == 2)
            {
                wejscia = new int[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
                wyjscie = new int[,] { { 0, 1 }, { 1, 0 }, { 1, 0 }, { 0, 0 } };
                break;
            }
            else if (numer == 3)
            {
                wejscia = new [,]{ { 0, 0,0 },  { 0, 1,0 }, { 1, 0 ,0}, { 1, 1 ,0}, { 0,0,1 }, { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 }};
                wyjscie = new [,]{ {0 ,0}, { 1,0 }, { 1,0 }, { 0, 1 }, { 1, 0 }, { 0, 1 }, { 0, 1 }, { 1, 1 } };
                break;
            }
            else
            {
                Console.WriteLine("blad");
            }
        }
        List<double[]> warstwy = new List<double[]>();
        int wagi_miejsce = 0;
        int bias_miejsce = 0;
        Console.WriteLine("Podaj ile warstw");
        int ile_warst = int.Parse(Console.ReadLine());
        for (int i = 0; i < ile_warst; i++)
        {
            int ile_neuronuw=0;
            if (i == ile_warst - 1)
            {
                Console.WriteLine("Podaj ile neuronuw w warstwie wyjsciowy");
                ile_neuronuw = wyjscie.GetLength(1);
            }
            else
            {
                Console.WriteLine("Podaj ile neuronuw w warstwie " + (i + 1));
                ile_neuronuw = int.Parse(Console.ReadLine());
            }
            double[] neuronuw = new double[ile_neuronuw];
            warstwy.Add(neuronuw);
            if (i == 0)
            {
                wagi_miejsce += wejscia.GetLength(1) * ile_neuronuw;
            }
            else
            {
                wagi_miejsce += warstwy[i - 1].Length * ile_neuronuw;
            }
            bias_miejsce += ile_neuronuw;
        }
        sieć Siec = new sieć(wagi_miejsce, bias_miejsce, warstwy);
        int epok = 50000;
        double u = 0.3;
        Siec.tranig(epok, u, wejscia, wyjscie);
    }
}

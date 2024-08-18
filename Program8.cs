namespace program { 
class Program
    {
        static void Main(string[] args) {
            int[] tab = { 1, 0, 8,2 };//{1,0,8,2}{8,0,1,2}{8,2,0,1}{8,2,1,0}
            for (int i=0;i<tab.Length;i++) {
                for (int j=i+1;j<tab.Length;j++) {
                    int pow = tab[j];
                    if (tab[i] < tab[j])
                    {

                        tab[j] = tab[i];
                        tab[i] = pow;
                    }
                }
            }
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }
        }
    }
}
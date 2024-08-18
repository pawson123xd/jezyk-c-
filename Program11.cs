namespace program
{
    class produkt
    {
        public int cena = 20;
        private string nazwa;
        public string[] koszy = { "" };
        private string[] pamiec = new string[100000];
        private int ilw = 1;

        public produkt(string nazwa)
        {

            this.nazwa = nazwa;
            pamiec[0] = nazwa;

        }

        public void add(string nazwa, int cen)
        {
            pamiec[ilw] = nazwa;
            koszy = new string[koszy.Length + 1];
            for(int j = 0; j < koszy.Length; j++) {
                koszy[j] = pamiec[j];
             }
            ilw = ilw + 1;
            cena += cen;
        }
        public void pokazy()
        {
            Console.WriteLine("ilosc prowawow jest rowna {0} a suma cen {1}", koszy.Length, cena);
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            produkt p1 = new produkt("chleb");
            p1.add("maka", 18);
            p1.add("maka", 18);
            p1.pokazy();
        }
    }
}
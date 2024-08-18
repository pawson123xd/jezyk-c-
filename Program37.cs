class program
{
    static void Main(string[] args)
    {
        //try
        //{
        //    int liczba1;
        //    int liczba2=30;
        //    int liczba3=0;
        //    liczba1= liczba2/liczba3;
        //    Console.WriteLine(liczba1);

        //}
        //catch(Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}
        //finally {
        //    Console.WriteLine("finally");

        //        }
        try
        {
            int[] tab = new int[2];
            tab[25] = 2;
            throw new IndexOutOfRangeException();
        }
        catch
        {
            Console.WriteLine("nie takiej tablicy");
        }
        //catch (IndexOutOfRangeException e) {
        //    Console.WriteLine(e.Message);

        //}
    }
}
interface IGitarzysta
{
    void Graj();
}
interface ISkrzypek
{
    void Graj();
}
class osoba: IGitarzysta , ISkrzypek
{
    public void Graj()
    {
        Console.WriteLine("Gram ale nie wiem na czym");
    }
    void IGitarzysta.Graj()
    {
        Console.WriteLine("Gram na gitarze");
    }
    void ISkrzypek.Graj() {
        Console.WriteLine("Gram na skrzypcach");


            }
}
class program
{
    static void Main(string[] args)
    {
        osoba p1=new osoba();
        p1.Graj();
        IGitarzysta p=(IGitarzysta)p1;
        ISkrzypek q=(ISkrzypek)p1;
        p.Graj();
        q.Graj();

    }
}
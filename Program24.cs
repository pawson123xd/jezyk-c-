class RachunekBankowy
{
    private double rocznastopaprocentowa;
    private double saldo;
    public RachunekBankowy(int saldo) {
        this.saldo = saldo;
        rocznastopaprocentowa = 1;
    }
    public void obliczMiesieczneOdsetki()
    {
        saldo = (saldo * rocznastopaprocentowa) / 12;
        Console.WriteLine(saldo);
    }
    public void setrocznastopaprocentowa(double x)
    {
        rocznastopaprocentowa = x;
    }
}
class Program
{
    static void Main(string[] args)
    {
        RachunekBankowy sever1 = new RachunekBankowy(2000);
        RachunekBankowy sever2 = new RachunekBankowy(3000);
        sever1.setrocznastopaprocentowa(0.04);
        sever2.setrocznastopaprocentowa(0.04);
        sever1.obliczMiesieczneOdsetki();
        sever2.obliczMiesieczneOdsetki();
        sever1.setrocznastopaprocentowa(0.05);
        sever2.setrocznastopaprocentowa(0.05);
        sever1.obliczMiesieczneOdsetki();
        sever2.obliczMiesieczneOdsetki();
    }
    
}
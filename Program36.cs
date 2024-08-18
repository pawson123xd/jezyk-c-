class BaseClass
{
    public void zadanie()
    {
        Console.WriteLine("dfh");
    }
}
class DerrivedClass : BaseClass
{

}
class NextDerrivedClass : DerrivedClass
{

}
class rzutowanie
{
    static void Main(string[] args)
    {
        BaseClass myObj = new BaseClass();
        DerrivedClass derObj1 = (DerrivedClass)myObj;
        NextDerrivedClass NxtObj1 = (NextDerrivedClass)myObj;

    }
}
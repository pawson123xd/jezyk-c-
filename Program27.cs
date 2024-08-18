class pracownik
{
    public virtual void Pracuj()
    {
        Console.WriteLine("logowanie");
    }

}
class programista : pracownik
{
    public override void Pracuj()
    {
        base.Pracuj();
        Console.WriteLine("Obowiazki programisty");
    }
}
class program { 
    static void Main(string[] args) {
        pracownik p1 = new programista();
        p1.Pracuj();
    }
    
}

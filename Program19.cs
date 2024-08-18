interface IClonable
{
}
class Test2
{
    public string slowo;
}
class Test : IClonable
{
    public int liczba;
    public Test2 poleTestowe = new Test2();
    public Test(string zadanie="puste")
    {
        poleTestowe.slowo = zadanie;
    }
    public Object Clone()
    {
        return MemberwiseClone();
    }
    public Test GlebokaKopia()
    {
        Test tempTest = new Test();
        tempTest.liczba = this.liczba;
        tempTest.poleTestowe.slowo = this.poleTestowe.slowo;
        return tempTest;
    }

}
class program
{
    static void Main(string[] args)
    {
        Test object1 = new Test();
        Test object2 = new Test();
        Test object3 = new Test();
        object1.liczba = 255;
        object2 = object1;
        object3 = (Test)object1.Clone();
        object1.liczba = 347;
        Console.WriteLine(object1.liczba);
        Console.WriteLine(object2.liczba);
        Console.WriteLine(object3.liczba);
        Console.WriteLine(object1.poleTestowe.slowo);
        object1.poleTestowe.slowo = "słowo";
        Console.WriteLine(object1.poleTestowe.slowo);
        object1.poleTestowe.slowo = "kaczka";
        Console.WriteLine(object1.poleTestowe.slowo);
        object3 = object1.GlebokaKopia();

    }
}
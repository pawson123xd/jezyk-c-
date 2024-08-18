using ConsoleApp12;

class pogram
{
    static void Main(string[] args)
    {
        Osoba dyrektor = new Osoba("Alina", "Kowalska", 2002,86,174,false);
        Console.WriteLine("{0} {1} {2} {3}",dyrektor.imie, dyrektor.nazwisko, dyrektor.obliczwiek(),dyrektor.przedrostek("k"));
        Osoba Pacjet= new Osoba("aleksander", "Kowalska", 1999, 60, 180, false);
        Console.WriteLine("{0} {1} {2}", Pacjet.imie, Pacjet.nazwisko,Pacjet.obliczanieBmi());
        produkt p1 = new produkt("jajka",8);
        p1.add("mleko",10);
        p1.pokazy();
        dzialanie_liczb_zepolonych p2=new dzialanie_liczb_zepolonych(2,3);
        p2.dodawanie(2, 4);
        p2.odejmowanie(2, 4);
    }
}
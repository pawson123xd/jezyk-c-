using System.Runtime.CompilerServices;
using System.Windows;
public class Car
{
    private double pojemonoscSilnika;
    private string marka; // nie mam dostepu do polu z powodu private
    static int iloscKol = 4;
    public Car()
    {
        this.pojemonoscSilnika = 0;
        this.marka = " ";
    }
    public Car(double pojemonoscSilnik, string mark)
    {
        this.pojemonoscSilnika = pojemonoscSilnik;
        this.marka = mark;
    }
    public void Car_create()
    {
        Console.WriteLine("{0}  {1}  kon {2}", pojemonoscSilnika, marka, iloscKol);
    }
    ~Car()
    {
        MessageBox.Show("Zwalniam pamiec");
    }
}
class program
{
    public static void Main(String[] args)
    {
        Car p1 = create(1.43, "audi");
        p1.Car_create();
        p1 = null;
    }
    public static Car create(double pojemonoscSilnik, string mark)
    {
        return new Car(pojemonoscSilnik, mark);
    }
}
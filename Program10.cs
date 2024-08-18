class program
{
    static void Main()
    {
        //Car car1 = new Car(1999, "marka");
        //car1.za();
        //Car car2 = new Car(2017, "audi");
        //car2.za();
        //car1 = car2;
        //car1.za();
        Car car2 = new Car(2016, "'audi'", "'a23'", 6, 23, 1.6767);
        car2.pokaz();
        Console.WriteLine(car2.ObliczKosztPrzejazdu(50, 3));

    }
}

interface IRideable
{
     void ride();
}

class Vehicle
{

}
class Car : Vehicle, IRideable
{
    void IRideable.ride()
    {
        Console.WriteLine("jedzie samochud");
    }
}
class Bicycle : Vehicle,IRideable
{
    void IRideable.ride()
    {
        Console.WriteLine("jedzie rower");
    }
}
class program
{
    static void Main(string[] args)
    {
        Car car1 = new Car();
        Bicycle bicycle1 = new Bicycle();
        IRideable ride = (IRideable)car1;
        IRideable rid = (IRideable)bicycle1;
        rid.ride();
        ride.ride();


    } 
}
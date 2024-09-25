using System;

public class Car : IEquatable<Car>
{
    public string name { get; set; }
    public string engine { get; set; }
    public int max_spd { get; set; }

    public override string ToString()
    {
        return name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return name == other.name && engine == other.engine && max_spd == other.max_spd;
    }
}

public class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
                return $"{cars[index].name} - {cars[index].engine}";
            else
                throw new IndexOutOfRangeException();
        }
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CarsCatalog catalog = new CarsCatalog();

        Car car1 = new Car { name = "Car A", engine = "Petrol", max_spd = 200 };
        Car car2 = new Car { name = "Car B", engine = "Diesel", max_spd = 180 };
        Car car3 = new Car { name = "Car C", engine = "Electric", max_spd = 220 };

        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        Console.WriteLine(catalog[0]);
        Console.WriteLine(catalog[1]);
        Console.WriteLine(catalog[2]);
    }
}

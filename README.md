# Лабораторная работа 1
# Цели работы
1. Научиться синтаксису и принципам перегрузки операторов языка C#.

# Задание 1
Создайте структуру Vector с тремя полями x, y и z.
Для созданной структуры переопределите операторы сложения векторов, умножения векторов, умножения вектора на число, а также логические операторы. Для логических операторов используйте сравнение по длине от начала координат.

Код задания 1:
```
using System;

public struct Vector
{
    public int x, y, z;
    public Vector(int x, int y, int z) 
    { 
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    public static Vector operator *(Vector a, int b) => new Vector(a.x * b, a.y * b, a.z * b);
    public static int operator *(Vector a, Vector b) => a.x * b.x + a.y + b.y + a.z * b.z;
    public static bool operator >=(Vector a, Vector b) => ((a.x * a.x + a.y * a.y + a.z * a.z) >= (b.x * b.x + b.y * b.y + b.z * b.z));
    public static bool operator <=(Vector a, Vector b)
    {
        int lenght_A = (a.x * a.x + a.y * a.y + a.z * a.z);
        int length_B = (b.x * b.x + b.y * b.y + b.z * b.z);
        return lenght_A <= length_B;
    }
    public static bool operator >(Vector a, Vector b) => !(a <= b);
    public static bool operator <(Vector a, Vector b) => !(a >= b);
    public static bool operator ==(Vector a, Vector b)
    {
        int lenght_A = (a.x * a.x + a.y * a.y + a.z * a.z);
        int length_B = (b.x * b.x + b.y * b.y + b.z * b.z);
        return (lenght_A == length_B);
    }
    public static bool operator !=(Vector a, Vector b) => !(a == b);
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Vector vec1 = new Vector(1, 2, 3);
        Vector vec2 = new Vector(4, 5, 6);

        var sum = vec1 + vec2;
        var scaled = vec1 * 2;
        var mult = vec1 * vec2;

        Console.WriteLine($"Vector 1: ({vec1.x}, {vec1.y}, {vec1.z})");
        Console.WriteLine($"Vector 2: ({vec2.x}, {vec2.y}, {vec2.z})");
        Console.WriteLine($"vec1 + vec2 = ({sum.x}, {sum.y}, {sum.z})");
        Console.WriteLine($"vec1 * 2 = ({scaled.x}, {scaled.y}, {scaled.z})");
        Console.WriteLine($"vec1 * vec2 = {mult}");
        Console.WriteLine($"vec1 >= vec2? {vec1 >= vec2}");
        Console.WriteLine($"vec1 <= vec2? {vec1 <= vec2}");
    }
}
```

Вывод консоли:
![image](https://github.com/user-attachments/assets/37c219db-271c-4d3b-9bac-7df9ef138c8d)


# Задание 2
Создайте класс Car со свойствами Name, Engine, MaxSpeed. Переопределите оператор ToString() таким образом, чтобы он возвращал название машины(Name). Реализуйте возможность сравнения объектов Car, реализовав интерфейс IEquatable&lt;Car&gt;.
Создайте класс CarsCatalog, содержащий коллекцию машин – элементов типа Car и переопределите для него индексатор таким образом, чтобы он возвращал строку с названием машины и типом двигателя.

Код задания 2:
```
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
```

Вывод консоли:
![image](https://github.com/user-attachments/assets/daff322d-eddd-4e14-aee0-d38f7fce5e90)


# Задание 3
Создайте базовый класс Currency со свойством Value. Создайте 3 производных от Currency класса – CurrencyUSD, CurrencyEUR и CurrencyRUB со свойствами, соответствующими обменному курсу. В каждом из производных классов переопределите операторы преобразования типов таким образом, чтобы можно было явно или неявно преобразовать одну валюту в другую по курсу, заданному пользователем при запуске программы.

Код задания 3:
```
using System;

public abstract class Currency
{
    protected double value;
}
class CurrencyUSD : Currency
{
    public CurrencyUSD(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyEUR(CurrencyUSD val)
    {
        return new CurrencyEUR(val.value / CurrencyEUR.ExChange);
    }
    public static implicit operator CurrencyRUB(CurrencyUSD val)
    {
        return new CurrencyRUB(val.value / CurrencyRUB.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyEUR : Currency
{
    public static double ExChange { get; set; }

    public CurrencyEUR(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyRUB(CurrencyEUR val)
    {
        return new CurrencyRUB(val.value * CurrencyEUR.ExChange / CurrencyRUB.ExChange);
    }
    public static implicit operator CurrencyUSD(CurrencyEUR val)
    {
        return new CurrencyUSD(val.value * CurrencyEUR.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyRUB : Currency
{
    public static double ExChange { get; set; }
    public CurrencyRUB(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyUSD(CurrencyRUB val)
    {
        return new CurrencyUSD(val.value * CurrencyRUB.ExChange);
    }
    public static implicit operator CurrencyEUR(CurrencyRUB val)
    {
        return new CurrencyEUR(val.value * CurrencyRUB.ExChange / CurrencyEUR.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CurrencyEUR.ExChange = 1.06; // обменный курс USD и EUR
        CurrencyRUB.ExChange = 0.0102; // обменный курс RUB и USD

        CurrencyUSD cur = new CurrencyUSD(100);
        CurrencyEUR eur = cur;
        Console.WriteLine($"It's {eur.Value} EUR");
        CurrencyRUB rub = eur;
        Console.WriteLine($"It's {rub.Value} RUB");
    }
}
```

Вывод консоли:
![image](https://github.com/user-attachments/assets/49958112-95b6-4682-b7db-17312d1bf50f)


# Вывод
В ходе выполнения лабораторной работы получилось научиться синтаксису и принципам перегрузки операторов языка C#.

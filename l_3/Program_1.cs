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

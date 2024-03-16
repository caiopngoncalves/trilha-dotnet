public struct Ponto<T>
{
    public T X { get; set; }
    public T Y { get; set; }
    public T Z { get; set; }

    public Ponto(T x, T y, T z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

public struct Triangulo<T>
{
    public Ponto<T> P1 { get; set; }
    public Ponto<T> P2 { get; set; }
    public Ponto<T> P3 { get; set; }

    public Triangulo(Ponto<T> p1, Ponto<T> p2, Ponto<T> p3)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Triangulo<double> triangulo1 = new Triangulo<double>(
            new Ponto<double>(0.0, 0.0, 0.0),
            new Ponto<double>(1.0, 0.0, 0.0),
            new Ponto<double>(0.0, 1.0, 0.0)
        );

        Triangulo<int> triangulo2 = new Triangulo<int>(
            new Ponto<int>(0, 0, 0),
            new Ponto<int>(1, 0, 0),
            new Ponto<int>(0, 1, 0)
        );

        Triangulo<float> triangulo3 = new Triangulo<float>(
            new Ponto<float>(0.0f, 0.0f, 0.0f),
            new Ponto<float>(1.0f, 0.0f, 0.0f),
            new Ponto<float>(0.0f, 1.0f, 0.0f)
        );

        Console.WriteLine("Triângulo 1:");
        ExibirPontos(triangulo1);
        Console.WriteLine();

        Console.WriteLine("Triângulo 2:");
        ExibirPontos(triangulo2);
        Console.WriteLine();

        Console.WriteLine("Triângulo 3:");
        ExibirPontos(triangulo3);
    }

    static void ExibirPontos<T>(Triangulo<T> triangulo)
    {
        Console.WriteLine($"Ponto 1: ({triangulo.P1.X}, {triangulo.P1.Y}, {triangulo.P1.Z})");
        Console.WriteLine($"Ponto 2: ({triangulo.P2.X}, {triangulo.P2.Y}, {triangulo.P2.Z})");
        Console.WriteLine($"Ponto 3: ({triangulo.P3.X}, {triangulo.P3.Y}, {triangulo.P3.Z})");
    }
}

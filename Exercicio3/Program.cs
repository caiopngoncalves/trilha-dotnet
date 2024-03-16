enum Exercicio
{
    Academia = 1,
    Luta = 2,
    Corrida = 3
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Opções de exercícios:");

        foreach (Exercicio exercicio in Enum.GetValues(typeof(Exercicio)))
        {
            Console.WriteLine($"{(int)exercicio} - {exercicio}");
        }

        Console.Write("Digite o número correspondente ao exercício desejado: ");

        try
        {
            int opcao = int.Parse(Console.ReadLine());

            if (Enum.IsDefined(typeof(Exercicio), opcao))
            {
                Exercicio exercicioSelecionado = (Exercicio)opcao;
                Console.WriteLine($"Você selecionou o exercício: {exercicioSelecionado}");
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, digite um número válido (1, 2 ou 3).");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato inválido. Por favor, digite um número válido (1, 2 ou 3).");
        }
    }
}
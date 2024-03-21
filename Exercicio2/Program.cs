public enum Tipo
{
    Comida,
    Bebida,
    Higiene,
    Limpeza
}
public class ItemMercado
{
    public required string Nome { get; set; }
    public Tipo Tipo { get; set; }
    public double Preco { get; set; }
}

class Program
{
    static void Main()
    {
        List<ItemMercado> listaItens = new List<ItemMercado>
        {
            new ItemMercado { Nome = "Arroz", Tipo = Tipo.Comida, Preco = 3.90 },
            new ItemMercado { Nome = "Azeite", Tipo = Tipo.Comida, Preco = 2.50 },
            new ItemMercado { Nome = "Macarrão", Tipo = Tipo.Comida, Preco = 3.90 },
            new ItemMercado { Nome = "Cerveja", Tipo = Tipo.Bebida, Preco = 22.90 },
            new ItemMercado { Nome = "Refrigerante", Tipo = Tipo.Bebida, Preco = 5.50 },
            new ItemMercado { Nome = "Shampoo", Tipo = Tipo.Higiene, Preco = 7.00 },
            new ItemMercado { Nome = "Sabonete", Tipo = Tipo.Higiene, Preco = 2.40 },
            new ItemMercado { Nome = "Cotonete", Tipo = Tipo.Higiene, Preco = 5.70 },
            new ItemMercado { Nome = "Sabão em pó", Tipo = Tipo.Limpeza, Preco = 8.20 },
            new ItemMercado { Nome = "Detergente", Tipo = Tipo.Limpeza, Preco = 2.60 },
            new ItemMercado { Nome = "Amaciante", Tipo = Tipo.Limpeza, Preco = 6.40 }
        };

        var itensHigiene = listaItens.Where(item => item.Tipo == Tipo.Higiene).OrderByDescending(item => item.Preco).ToList();
        Console.WriteLine("Itens de Higiene ordenados por preço decrescente:");
        foreach (var item in itensHigiene)
        {
            Console.WriteLine($"{item.Nome} - {item.Preco:C}");
        }
        Console.WriteLine();

        var itensPrecoMaiorOuIgualA5 = listaItens.Where(item => item.Preco >= 5.00).OrderBy(item => item.Preco).ToList();
        Console.WriteLine("Itens com preço maior ou igual a R$ 5,00 ordenados por preço crescente:");
        foreach (var item in itensPrecoMaiorOuIgualA5)
        {
            Console.WriteLine($"{item.Nome} - {item.Preco:C}");
        }
        Console.WriteLine();

        var itensComidaOuBebida = listaItens.Where(item => item.Tipo == Tipo.Comida || item.Tipo == Tipo.Bebida).OrderBy(item => item.Nome).ToList();
        Console.WriteLine("Itens do tipo Comida ou Bebida ordenados por nome:");
        foreach (var item in itensComidaOuBebida)
        {
            Console.WriteLine($"{item.Nome} - {item.Tipo}");
        }
        Console.WriteLine();

        var tiposComQuantidade = listaItens.GroupBy(item => item.Tipo).Select(group => new { Tipo = group.Key, Quantidade = group.Count() }).ToList();
        Console.WriteLine("Quantidade de itens por tipo:");
        foreach (var tipoQuantidade in tiposComQuantidade)
        {
            Console.WriteLine($"{tipoQuantidade.Tipo}: {tipoQuantidade.Quantidade}");
        }
        Console.WriteLine();

        var tiposComPreco = listaItens.GroupBy(item => item.Tipo).Select(group => new {
            Tipo = group.Key,
            PrecoMaximo = group.Max(item => item.Preco),
            PrecoMinimo = group.Min(item => item.Preco),
            MediaPreco = group.Average(item => item.Preco)
        }).ToList();
        Console.WriteLine("Preço máximo, mínimo e média de preço por tipo:");
        foreach (var tipoPreco in tiposComPreco)
        {
            Console.WriteLine($"{tipoPreco.Tipo}:");
            Console.WriteLine($"- Preço Máximo: {tipoPreco.PrecoMaximo:C}");
            Console.WriteLine($"- Preço Mínimo: {tipoPreco.PrecoMinimo:C}");
            Console.WriteLine($"- Média de Preço: {tipoPreco.MediaPreco:C}");
            Console.WriteLine();
        }
    }
}

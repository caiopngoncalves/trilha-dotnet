class Program
{
    static void Main(string[] args)
    {
        try
        {
            object o = null;
            o.ToString();
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Erro: Tentativa de chamar o método ToString() em uma referência nula.");
        }
    }
}
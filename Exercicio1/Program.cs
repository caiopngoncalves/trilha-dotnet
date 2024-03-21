class Program
{
    static void Main()
    {
        List<double> listaOriginal = new List<double> { 3, 7, 2, 4, 6 };
        List<double> novaLista = listaOriginal.ConvertAll(x => x / 2);
        novaLista.ForEach(x => Console.WriteLine(x));
    }
}
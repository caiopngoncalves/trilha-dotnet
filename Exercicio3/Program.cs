class Worker
{
    public void Work()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Trabalhador está realizando o trabalho {i}/10");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Trabalhador concluiu o trabalho.");
    }
}

class Program
{
    static void Main()
    {
        Worker worker1 = new Worker();
        Worker worker2 = new Worker();
        Thread thread1 = new Thread(worker1.Work);
        Thread thread2 = new Thread(worker2.Work);
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        Console.WriteLine("Ambas as threads concluíram o trabalho. O programa principal está encerrando.");
    }
}

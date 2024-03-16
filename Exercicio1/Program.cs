public class ValorInvalidoException : Exception
{
    public double Valor { get; }

    public ValorInvalidoException(string message, double valor) : base(message)
    {
        Valor = valor;
    }
}

public class SaldoInsuficienteException : Exception
{
    public double SaldoDisponivel { get; }

    public SaldoInsuficienteException(string message, double saldoDisponivel) : base(message)
    {
        SaldoDisponivel = saldoDisponivel;
    }
}

public class ContaBancaria
{
    private double saldo;

    public ContaBancaria(double saldoInicial)
    {
        if (saldoInicial < 0)
            throw new ValorInvalidoException("O saldo inicial não pode ser negativo.", saldoInicial);

        saldo = saldoInicial;
    }

    public double Saldo => saldo;

    public void Sacar(double valor)
    {
        if (valor <= 0)
            throw new ValorInvalidoException("O valor de saque deve ser maior que zero.", valor);

        if (valor > saldo)
            throw new SaldoInsuficienteException("Saldo insuficiente para realizar o saque.", saldo);

        saldo -= valor;
        Console.WriteLine($"Saque de {valor} realizado com sucesso. Novo saldo: {saldo}");
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
            throw new ValorInvalidoException("O valor de depósito deve ser maior que zero.", valor);

        saldo += valor;
        Console.WriteLine($"Depósito de {valor} realizado com sucesso. Novo saldo: {saldo}");
    }

    public void Transferir(double valor, ContaBancaria destino)
    {
        if (valor <= 0)
            throw new ValorInvalidoException("O valor de transferência deve ser maior que zero.", valor);

        if (valor > saldo)
            throw new SaldoInsuficienteException("Saldo insuficiente para realizar a transferência.", saldo);

        saldo -= valor;
        destino.Depositar(valor);
        Console.WriteLine($"Transferência de {valor} para a conta destino realizada com sucesso. Novo saldo: {saldo}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ContaBancaria conta1 = new ContaBancaria(1000);
            ContaBancaria conta2 = new ContaBancaria(500);

            conta1.Depositar(200);
            conta1.Sacar(150);
            conta1.Transferir(300, conta2);

            conta1.Sacar(1200);
            conta2.Depositar(-100);
        }
        catch (ValorInvalidoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}. Valor inválido: {ex.Valor}");
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}. Saldo disponível: {ex.SaldoDisponivel}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}

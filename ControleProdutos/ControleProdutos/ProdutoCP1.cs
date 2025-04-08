using System;
using System.Globalization;

class Produto
{
    // Atributos privados
    private string nome;
    private double precoUnitario;
    private int quantidade;
    private double desconto;

    // Construtor
    public Produto(string nome, double precoUnitario, int quantidade, double desconto)
    {
        this.nome = nome;
        this.precoUnitario = precoUnitario;
        this.quantidade = quantidade;
        this.desconto = desconto;
    }

    // Método para calcular o custo total
    public double CalcularCustoTotal()
    {
        return precoUnitario * quantidade;
    }

    // Método para calcular o custo final com desconto (se aplicável)
    public double CalcularCustoFinal()
    {
        double custoTotal = CalcularCustoTotal();
        if (custoTotal > 5000)
        {
            return custoTotal - (custoTotal * (desconto / 100));
        }
        else
        {
            return custoTotal;
        }
    }

    // Método para exibir os detalhes do produto
    public void ExibirDetalhes()
    {
        double custoTotal = CalcularCustoTotal();
        double custoFinal = CalcularCustoFinal();

        Console.WriteLine($"\nProduto: {nome}");
        Console.WriteLine($"Preço Unitário: {precoUnitario.ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Quantidade: {quantidade}");
        Console.WriteLine($"Custo Total: {custoTotal.ToString("F2", CultureInfo.InvariantCulture)}");

        if (custoTotal > 5000)
        {
            Console.WriteLine($"Desconto Aplicado: {desconto}%");
        }
        else
        {
            Console.WriteLine("Sem desconto aplicado.");
        }

        Console.WriteLine($"Custo Final: {custoFinal.ToString("F2", CultureInfo.InvariantCulture)}\n");
    }

    public string GetNome()
    {
        return nome;
    }

    public double GetCustoFinal()
    {
        return CalcularCustoFinal();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Cadastro do Produto 1:");
        Produto produto1 = CriarProduto();

        Console.WriteLine("\nCadastro do Produto 2:");
        Produto produto2 = CriarProduto();

        // Exibir detalhes
        produto1.ExibirDetalhes();
        produto2.ExibirDetalhes();

        // Comparação
        if (produto1.GetCustoFinal() > produto2.GetCustoFinal())
        {
            Console.WriteLine($"O produto com maior custo final é: {produto1.GetNome()}");
        }
        else if (produto2.GetCustoFinal() > produto1.GetCustoFinal())
        {
            Console.WriteLine($"O produto com maior custo final é: {produto2.GetNome()}");
        }
        else
        {
            Console.WriteLine("Os dois produtos têm o mesmo custo final.");
        }
    }

    static Produto CriarProduto()
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço unitário: ");
        double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Desconto (%): ");
        double desconto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        return new Produto(nome, preco, quantidade, desconto);
    }
}

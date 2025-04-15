using System;

public class Produto
{
    // Propriedades com encapsulamento
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { private get; set; }  // Quantidade de entrada (somente escrita)
    public int QuantidadeTotal { get; private set; }  // Quantidade total de estoque (somente leitura)

    // Construtor da classe Produto
    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
        QuantidadeTotal = 0;  // Inicializa o estoque com 0
    }

    // Método para adicionar estoque
    public void AdicionarEstoque()
    {
        QuantidadeTotal += Quantidade;
    }

    // Método para remover estoque
    public void RemoverEstoque(int qtde)
    {
        if (qtde <= QuantidadeTotal)
        {
            QuantidadeTotal -= qtde;
        }
        else
        {
            Console.WriteLine("Estoque insuficiente!");
        }
    }

    // Método para calcular o valor total em estoque
    public double ValorTotalEmEstoque()
    {
        return Preco * QuantidadeTotal;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Produto produto = new Produto("Camiseta", 29.99);
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Menu de Controle de Estoque");
            Console.WriteLine("1 - Adicionar Estoque");
            Console.WriteLine("2 - Remover Estoque");
            Console.WriteLine("3 - Consultar Estoque");
            Console.WriteLine("4 - Calcular Valor Total em Estoque");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Informe a quantidade a ser adicionada ao estoque: ");
                    int qtdAdicionar = int.Parse(Console.ReadLine());
                    produto.Quantidade = qtdAdicionar; // Atribui a quantidade a ser adicionada
                    produto.AdicionarEstoque();
                    Console.WriteLine($"Estoque de {produto.Nome} atualizado. Quantidade total: {produto.QuantidadeTotal}");
                    break;

                case "2":
                    Console.Write("Informe a quantidade a ser removida do estoque: ");
                    int qtdRemover = int.Parse(Console.ReadLine());
                    produto.RemoverEstoque(qtdRemover);
                    Console.WriteLine($"Estoque de {produto.Nome} atualizado. Quantidade total: {produto.QuantidadeTotal}");
                    break;

                case "3":
                    Console.WriteLine($"Estoque de {produto.Nome}: {produto.QuantidadeTotal} unidades");
                    break;

                case "4":
                    Console.WriteLine($"Valor total em estoque de {produto.Nome}: R${produto.ValorTotalEmEstoque():F2}");
                    break;

                case "5":
                    continuar = false;
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}

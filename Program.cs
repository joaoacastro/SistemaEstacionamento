using System;
using SistemaParaEstacionamento.Models;

class Program
{
    static void Main()
    {
        Console.WriteLine("Seja bem-vindx ao sistema de estacionamento JAC PARK");

        Console.WriteLine("Digite o preço inicial R$:");
        decimal valorInicial = Convert.ToDecimal(Console.ReadLine()?.Replace('.', ',') ?? "0");

        Console.WriteLine("Agora digite o valor por hora R$:");
        decimal valorHora = Convert.ToDecimal(Console.ReadLine()?.Replace('.', ',') ?? "0");

        var estacionamento = new Estacionamento(valorInicial, valorHora);

        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            string? opcao = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(opcao))
            {
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine(">> 1 - CADASTRO <<");
                        
                        Console.Write("Digite a placa do veículo (ABC-1234): ");
                        string? placaCadastro = Console.ReadLine()?.ToUpper();
                        
                        Console.Write("Marca do veículo: ");
                        string? marca = Console.ReadLine()?.ToUpper();
                        
                        Console.Write("Modelo do veículo: ");
                        string? modelo = Console.ReadLine()?.ToUpper();
                        
                        Console.Write("Cor do veículo: ");
                        string? cor = Console.ReadLine()?.ToUpper();

                        // Validação para garantir que nenhum dos campos seja nulo ou vazio
                        if (!string.IsNullOrWhiteSpace(placaCadastro) && 
                            !string.IsNullOrWhiteSpace(marca) && 
                            !string.IsNullOrWhiteSpace(modelo) && 
                            !string.IsNullOrWhiteSpace(cor))
                        {
                            estacionamento.CadastrarVeiculo(placaCadastro, marca, modelo, cor);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Cadastro não efetuado! Por favor, revise as informações e tente novamente.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine(">> 2 - REMOVER <<");
                        Console.Write("Digite a placa do veículo que deseja remover (ABC-1234): ");
                        string? placaRemocao = Console.ReadLine()?.ToUpper();
                        if (!string.IsNullOrWhiteSpace(placaRemocao))
                        {
                            estacionamento.RemoverVeiculo(placaRemocao);
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira uma placa válida.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("");
                        Console.WriteLine(">> 3 - LISTA <<");
                        estacionamento.ListarVeiculos();
                        break;

                    case "4":
                        Console.WriteLine("Encerrando programa");
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção não reconhecida. Por favor, escolha uma das opções do menu.");
            }
        }
    }
}
using System;
using SistemaParaEstacionamento.Models;

class Program
{
    static void Main()
    {
        Console.WriteLine("Seja bem-vindx ao sistema de estacionamento JAC PARK");

        Console.WriteLine("Digite o preço inicial:");
        decimal valorInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite o valor por hora:");
        decimal valorHora = Convert.ToDecimal(Console.ReadLine());

        var estacionamento = new Estacionamento(valorInicial, valorHora);

        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a placa do veículo: ");
                    string placaCadastro = Console.ReadLine();
                    estacionamento.CadastrarVeiculo(placaCadastro);
                    break;

                case "2":
                    Console.Write("Digite a placa do veículo que deseja remover: ");
                    string placaRemocao = Console.ReadLine();
                    estacionamento.RemoverVeiculo(placaRemocao);
                    break;

                case "3":
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

    }
}
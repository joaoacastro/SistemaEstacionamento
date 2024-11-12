﻿using System;
using SistemaParaEstacionamento.Models;

class Program
{
    static void Main()
    {
        Console.WriteLine("Seja bem-vindx ao sistema de estacionamento JAC PARK");

        decimal valorInicial = Estacionamento.LerDecimal("Digite o preço inicial (R$): ");
        decimal valorHora = Estacionamento.LerDecimal("Digite o valor por hora (R$): ");

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
                        Console.Clear();
                        Console.WriteLine("\n>> 1 - CADASTRO <<");

                        Console.Write("Digite a placa do veículo (abc1234): ");
                        string? placa = Console.ReadLine()?.ToUpper();

                        // Verifique se a placa é nula ou vazia antes de chamar o método VerificarPlaca
                        if (string.IsNullOrWhiteSpace(placa))
                        {
                            Console.WriteLine("\nERRO! \n Placa não pode ser nula ou vazia. Tente novamente.");
                        }
                        else
                        {
                            bool verificar = estacionamento.VerificarPlaca(placa);

                            if (verificar)
                            {
                                Console.Write("Marca do veículo: ");
                                string? marca = Console.ReadLine()?.ToUpper();

                                Console.Write("Modelo do veículo: ");
                                string? modelo = Console.ReadLine()?.ToUpper();

                                Console.Write("Cor do veículo: ");
                                string? cor = Console.ReadLine()?.ToUpper();

                                // Validação para garantir que nenhum dos campos seja nulo ou vazio
                                if (!string.IsNullOrWhiteSpace(placa) &&
                                    !string.IsNullOrWhiteSpace(marca) &&
                                    !string.IsNullOrWhiteSpace(modelo) &&
                                    !string.IsNullOrWhiteSpace(cor))
                                {
                                    estacionamento.CadastrarVeiculo(placa, marca, modelo, cor);
                                }
                                else
                                {
                                    Console.WriteLine("\nCadastro não efetuado! Por favor, revise as informações e tente novamente.");
                                }
                            }
                        }
                        break;


                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n>> 2 - REMOVER <<");
                        Console.Write("Digite a placa do veículo que deseja remover (abc1234): ");
                        string? placaRemocao = Console.ReadLine()?.ToUpper();
                        if (!string.IsNullOrWhiteSpace(placaRemocao))
                        {
                            estacionamento.RemoverVeiculo(placaRemocao);
                        }
                        else
                        {
                            Console.WriteLine("\nPor favor, insira uma placa válida.");
                            Console.WriteLine(" ");
                        }

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();

                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("\n>> 3 - LISTA <<");
                        estacionamento.ListarVeiculos();

                        break;

                    case "4":
                        Console.WriteLine("\nEncerrando programa");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();

                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
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
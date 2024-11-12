using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace SistemaParaEstacionamento.Models
{
    public class Estacionamento
    {
        decimal vlrInicial;
        decimal vlrHora;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal valorInicial, decimal valorHora)
        {
            vlrInicial = valorInicial;
            vlrHora = valorHora;
        }

        public static decimal LerDecimal(string mensagem)
        {
            decimal valor;
            while (true)
            {
                Console.Write(mensagem);
                if (decimal.TryParse(Console.ReadLine()?.Replace('.',','), out valor))
                {
                    if(valor >0)
                    {
                        return valor;
                    }
                    else
                    {
                        Console.WriteLine("\nERRO! \n Por favor, insira um valor decimal positivo.");
                    }
                }
                else
                {
                    Console.WriteLine("\nERRO! \n Por favor, insira um valor decimal válido.");
                }
            }
        }

        private class Veiculo
        {
            public string Placa { get; set; } = "###-####";
            public string Marca { get; set; } = "MARCA";
            public string Modelo { get; set; } = "MODELO";
            public string Cor { get; set; } = "BRANCO";
            public DateTime HoraEntrada { get; set; }
            public DateTime? HoraSaida { get; set; } = null;
        }

        public bool VerificarPlaca(string placa)
        {
            if (veiculos.Any(v => v.Placa == placa))
            {
                Console.WriteLine("\nERRO! \n Essa placa já foi cadastrada no Sistema. \n Verifique a placa e tente novamente.");
                return false;
            }
            if (FormatarPlaca(placa).Length > 8)
            {
                Console.WriteLine("\nERRO! \n O número de caracteres excede o limite permitido. \n Verifique a placa e tente novamente.");
                return false;
            }
            if (FormatarPlaca(placa).Length < 8)
            {
                Console.WriteLine("\nERRO! \n O número de caracteres é inferior ao limite permitido. \n Verifique a placa e tente novamente.");
                return false;
            }
            return true;
        }

        private string FormatarPlaca(string placa)
        {
            if (placa.Length == 8 && placa[3] == '-')
            {
                return placa;
            }

            return $"{placa.Substring(0, 3)}-{placa.Substring(3)}";
        }

        public void CadastrarVeiculo(string placa, string marca, string modelo, string cor)
        {
            var veiculo = new Veiculo
            {
                Placa = placa,
                Marca = marca,
                Modelo = modelo,
                Cor = cor,
                HoraEntrada = DateTime.Now
            };
            veiculos.Add(veiculo);

            Console.WriteLine($"\nVeículo cadastrado às {veiculo.HoraEntrada}: \n Marca: {marca} \n Modelo: {modelo} \n Cor: {cor} \n Placa: {FormatarPlaca(placa)}");
        }

        public void RemoverVeiculo(string placa)
        {
            var veiculo = veiculos.Find(v => v.Placa == placa);
            if (veiculo != null)
            {
                veiculo.HoraSaida = DateTime.Now;
                TimeSpan duracao = veiculo.HoraSaida.Value - veiculo.HoraEntrada;
                decimal total = vlrInicial + (decimal)duracao.TotalHours * vlrHora;
                veiculos.Remove(veiculo);

                Console.WriteLine($"\n{veiculo.Marca} {veiculo.Modelo} {veiculo.Cor} | placa: {FormatarPlaca(placa)} removido.");

                if (duracao.TotalHours < 1)
                {
                    string minutosAjustado = $"{(int)duracao.TotalMinutes}m{duracao.Seconds:D2}";
                    Console.WriteLine($"\nTempo de permanência: {minutosAjustado} seg");
                }
                else
                {
                    string horasMinutos = $"{(int)duracao.TotalHours}h{duracao.Minutes:D2}";
                    Console.WriteLine($"\nTempo de permanência: {horasMinutos} min");
                }

                Console.WriteLine($"\nValor Inicial: R$ {vlrInicial:F2}");
                Console.WriteLine($"Valor Por Hora: R$ {vlrHora:F2}");
                Console.WriteLine("--------------------");
                Console.WriteLine($"Total a pagar: R$ {total:F2}.");
            }
            else
            {
                Console.WriteLine("\nVeículo Não Encontrado.");
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine($"\nVeículos Cadastrados ({veiculos.Count}):");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"Marca: {veiculo.Marca} Modelo: {veiculo.Modelo} Cor: {veiculo.Cor} Placa: {FormatarPlaca(veiculo.Placa)} - Entrada: {veiculo.HoraEntrada}");
            }
        }

        internal void CadastrarVeiculo(string? placaCadastro, string? cor)
        {
            throw new NotImplementedException();
        }
    }
}
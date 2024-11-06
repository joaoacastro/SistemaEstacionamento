using System;
using System.Collections.Generic;
using System.Linq;
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

        private class Veiculo
        {
            public string Placa { get; set;}
            public DateTime HoraEntrada { get; set;}
            public DateTime? HoraSaida {get; set;} = null;
        }
        public void CadastrarVeiculo(string placa)
        {
            var veiculo = new Veiculo
            {
                Placa = placa,
                HoraEntrada = DateTime.Now
            };
            veiculos.Add(veiculo);
            Console.WriteLine($"Veículo {placa} cadastrado às {veiculo.HoraEntrada}.");
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

                Console.WriteLine($"Veículo {placa} removido.");
                Console.WriteLine($"Tempo de permanência {duracao.TotalHours:F2} horas.");
                Console.WriteLine("--------------------");
                Console.WriteLine($"Total a pagar: R${total:F2}.");
            }
            else
            {
                Console.WriteLine("Veículo Não Encontrado.");
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("Veículos Cadastrados:");
            foreach(var veiculo in veiculos)
            {
                Console.WriteLine($"Placa: {veiculo.Placa} - Entrada: {veiculo.HoraEntrada}");
            }
        }
    }
}
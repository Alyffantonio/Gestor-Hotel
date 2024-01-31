using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotel.Models
{
    public class Suite
    {

        public string NomeSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public List<Hospedes> Hospede {get; set;} = new List<Hospedes>();
        public Suite(string nomeSuite, int capacidade, decimal valordiaria )
        {
            NomeSuite = nomeSuite;
            Capacidade = capacidade;
            ValorDiaria = valordiaria;
        }
        public void ExibiInfoSuite()
        {
            Console.WriteLine($"Nome da Suíte: {NomeSuite}");
            Console.WriteLine($"Valor da Diária: {ValorDiaria:C}$");
            Console.WriteLine($"Capacidade de Hóspedes:{Capacidade}");
        }
        public decimal CalcularCustoTotal()
        {
            decimal custoTotal = 0;
            foreach (Hospedes hospede in Hospede)
            {
                custoTotal += ValorDiaria * hospede.QuantidadeDias;
            }
            return custoTotal;
        }
    }    
}
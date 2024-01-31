using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotel.Models
{
    public class Hospedes
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int QuantidadeDias { get; set; }

        public Hospedes(string nome, string sobrenome, string cpf, DateTime datanascimento,int quantidadeDias)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cpf;
            DataNascimento = datanascimento;
            QuantidadeDias = quantidadeDias;
        }
        public void ExibiInfoHospedes()
        {
            Console.WriteLine($"Nome completo: {Nome} {Sobrenome}");
            Console.WriteLine($"CPF:{CPF}");
            Console.WriteLine($"Data de Nascimento: {DataNascimento.ToShortDateString()}");
            Console.WriteLine($"Quantidade de Dias de hospedagem: {QuantidadeDias}");
        }
    }
}
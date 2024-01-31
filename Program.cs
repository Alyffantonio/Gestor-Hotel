using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorHotel.Models;

GerenciadorSuites gerenciadorSuites = new GerenciadorSuites();

bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine(" 1 - Gerenciamento de Suítes:");
    Console.WriteLine(" 2 - Gerenciamento de Hóspedes:");
    Console.WriteLine(" 3 - Sair");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Gerenciamento de Suítes:");
            Console.WriteLine("1 - Cadastrar Suites:");
            Console.WriteLine("2 - Listas de Suítes:");
            Console.WriteLine("3 - Excluir Suíte");
            Console.WriteLine("4 - Voltar ao menu principal");

            string opcaoSuite = Console.ReadLine();
            switch (opcaoSuite)
            {
                case "1":
                    gerenciadorSuites.AdicionarSuite();
                    break;

                case "2":
                    gerenciadorSuites.ExibiInfoSuite();
                    break;
                
                case "3":
                    gerenciadorSuites.RemoverSuite();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;    
            }
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("1 - Adicionar Hóspede: ");
            Console.WriteLine("2 - Lista de hóspedes: ");
            Console.WriteLine("3 - Finalizar Estadia:");
            Console.WriteLine("4 - Voltar ao menu principal");

            string opcaoHospedes = Console.ReadLine();
            switch (opcaoHospedes)
            {
                case "1":
                    gerenciadorSuites.AdicionarHospedes();
                    break;
                case "2":
                    gerenciadorSuites.ExibirHospedesPorSuite();
                    break;
                case "3":
                    gerenciadorSuites.FinalizarEstadia();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            break;

        case "3":
            Console.WriteLine("Finalizando programa!");
            exibirMenu = false;
            break;
        default:
        Console.WriteLine("Opção inválida!");
        break;
    }
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();   
}

Console.WriteLine("O programa foi finalizado!");











/*
gerenciadorSuites.AdicionarSuite();
gerenciadorSuites.ExibiInfoSuite();
gerenciadorSuites.AdicionarHospedes();
gerenciadorSuites.FinalizarEstadia();*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace GestorHotel.Models
{
    public class GerenciadorSuites
    {
        private List<Suite> listaDeSuites;
        public GerenciadorSuites() => listaDeSuites = new List<Suite>();
        public void AdicionarSuite()
        {
            Console.WriteLine("Adicionar Nova Suíte:");

            Console.WriteLine("Nome da suíte:");
            string nomeSuite = Console.ReadLine();

            Console.WriteLine("Valor da Diária:");
            if(decimal.TryParse(Console.ReadLine(),out decimal valorDiaria))
            {
                Console.WriteLine("Capacidade de hóspedes:");
                if(int.TryParse(Console.ReadLine(),out int capacidade ))
                {
                    Suite novaSuite = new Suite(nomeSuite, capacidade,valorDiaria);
                    listaDeSuites.Add(novaSuite);
                    Console.WriteLine($"Suíte {nomeSuite} Cadastrada com sucesso");
                }
                else
                {
                    Console.WriteLine("Formato inválido para a capacidade de hóspedes.");
                }
            }
            else
            {
                Console.WriteLine("Formato inválido para o valor da Diária");
            }

        }

        public void ExibiInfoSuite()
        {
            if(listaDeSuites.Count == 0)
            {
                Console.WriteLine("A lista de suítes está vazia, Adicione suítes para exibir informações");
            }
            else
            {
                foreach (Suite suite in listaDeSuites)
                {
                    suite.ExibiInfoSuite();
                    Console.WriteLine();
                }
            }
        }

        public void RemoverSuite()
        {
            Console.WriteLine("Remover Suíte:");

            Console.WriteLine("Nome da suíte a ser removida:");
            string nomeSuitePararemover = Console.ReadLine();

            Suite suiteParaRemover = listaDeSuites.Find(s => s.NomeSuite == nomeSuitePararemover);

            if(suiteParaRemover != null)
            {
                listaDeSuites.Remove(suiteParaRemover);
                Console.WriteLine($"A suíte {nomeSuitePararemover} foi Removida com sucesso");
            }
            else
            {
                Console.WriteLine($"A suíte {nomeSuitePararemover} não foi encontrada");
            }
        }
        public void AdicionarHospedes()
        {
            Console.WriteLine("Adicionar Hóspedes a uma Suíte:");

            ExibiInfoSuite();

            Console.WriteLine("Escolha a  Suíte: ");
            
            string nomeSuite = Console.ReadLine();

            Suite suiteSelecionada = listaDeSuites.FirstOrDefault(s=>s.NomeSuite == nomeSuite);

            if(suiteSelecionada != null)
            {
                Console.WriteLine("Quantidade de Hóspedes:");
                if(int.TryParse(Console.ReadLine(),out int quatidadeHospedes)&& quatidadeHospedes >0)
                {
                    if(quatidadeHospedes <=suiteSelecionada.Capacidade)
                    {
                        for(int i = 0;i < quatidadeHospedes; i++ )
                        {
                            Console.WriteLine($"--- Cadastro do Hóspede #{i+1} ---");
                            Console.WriteLine("Nome: "); string nomeHospede=Console.ReadLine();
                            Console.WriteLine("Sobrenome: "); string sobrenomeHospede = Console.ReadLine();
                            Console.WriteLine("CPF: "); string cpfHospede = Console.ReadLine();
                            Console.WriteLine("Data de Nascimento (dd/mm/yyyy): ");
                            if (DateTime.TryParse(Console.ReadLine(),out DateTime datanascimento))
                            {
                                Console.WriteLine("Quantidade de dias de Estadia: ");
                                if(int.TryParse(Console.ReadLine(), out int quantidadeDias)&& quantidadeDias > 0)
                                {
                                Hospedes novoHospede = new Hospedes(nomeHospede, sobrenomeHospede, cpfHospede, datanascimento, quantidadeDias);
                                suiteSelecionada.Hospede.Add(novoHospede);
                                Console.WriteLine($"Hóspede cadastrado com sucesso na Suíte {suiteSelecionada.NomeSuite}.\n");
                                }
                                else
                                {
                                     Console.WriteLine("Quantidade de dias inválida. O hóspede não foi cadastrado.\n");
                                    i--; // Volta para o cadastro do mesmo hóspede novamente
                                }

                            }
                            else
                            {
                                Console.WriteLine("Formato de data inválido. O hóspede não foi cadastrado.\n");
                                i--;
                            }
                        }
                    }
                    else
                    {
                         Console.WriteLine($"A quantidade de hóspedes excede a capacidade da suíte '{suiteSelecionada.NomeSuite}'.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Quantidade de hóspedes inválida.\n");
                }
            }
            else
            {
                Console.WriteLine($"A suíte '{nomeSuite}' não foi encontrada.\n");
            }
        }
        public void ExibirHospedesPorSuite()
        {
            Console.WriteLine("Lista de Hóspedes por Suíte:");

            foreach (Suite suite in listaDeSuites)
            {
                Console.WriteLine($"Suíte: {suite.NomeSuite}");

                if(suite.Hospede.Count >0 )
                {
                    foreach (Hospedes hospede in suite.Hospede)
                    {
                        Console.WriteLine($"- Hóspede: {hospede.Nome} {hospede.Sobrenome} ");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum Hóspede nesta Suíte.");
                } 
                Console.WriteLine();  
            }
        }
        public void FinalizarEstadia()
        {
            Console.WriteLine("Finalizar estadia em uma Suíte existente:");

            ExibirHospedesPorSuite();

            Console.WriteLine("Nome da Suíte: "); string nomeSuite = Console.ReadLine();

            Suite suiteSelecionada = listaDeSuites.FirstOrDefault(s=>s.NomeSuite == nomeSuite);

            if(suiteSelecionada != null)
            {
                if(suiteSelecionada.Hospede.Count>0)
                {
                    
                    for (int i = 0; i>suiteSelecionada.Hospede.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {suiteSelecionada.Hospede[i].Nome}");
                    }

                    Console.WriteLine("Escolha o nome do Hóspede para finalizar a estadia:");
                    string nomeHospedeEscolhido = Console.ReadLine();

                    Hospedes hospedeSelecionado = suiteSelecionada.Hospede.FirstOrDefault(h => h.Nome == nomeHospedeEscolhido);
                    
                    if(hospedeSelecionado !=null)
                    {
                        suiteSelecionada.Hospede.Remove(hospedeSelecionado);
                        
                        decimal custoEstadia = suiteSelecionada.ValorDiaria * hospedeSelecionado.QuantidadeDias;

                        Console.WriteLine($"Estadia do Hóspede {hospedeSelecionado.Nome} {hospedeSelecionado.Sobrenome}");
                        Console.WriteLine($"Valor total da estadia: {custoEstadia}$");

                        suiteSelecionada.Hospede.Remove(hospedeSelecionado);
                        
                        if(suiteSelecionada.Hospede.Count==0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Todos os hóspede foram removidos da Suíte {suiteSelecionada.NomeSuite}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Hóspede com o nome '{nomeHospedeEscolhido}' não encontrado na Suíte {suiteSelecionada.NomeSuite}.");
                    }

                }
                else
                {
                    Console.WriteLine($"Não há hóspedes na Suíte {suiteSelecionada.NomeSuite} para finalizar a estadia.");
                }
            }
            else
            {
                 Console.WriteLine($"A suíte '{nomeSuite}' não foi encontrada.\n");
            }

        }
    }
}
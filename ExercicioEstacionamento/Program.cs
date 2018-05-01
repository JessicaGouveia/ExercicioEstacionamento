using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioEstacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroVaga;
            Guid idTipoVaga;
            int valorRecebido;
            String opt, placa;
            var estacionamento = new Estacionamento();

            estacionamento.TipoVagas.Add(new TipoVaga(Guid.NewGuid(), "Moto", 2.50));
            estacionamento.TipoVagas.Add(new TipoVaga(Guid.NewGuid(), "Carro", 5.50));
            estacionamento.TipoVagas.Add(new TipoVaga(Guid.NewGuid(), "Utilitários", 8.00));

            for(numeroVaga = 1; numeroVaga <= 20; numeroVaga++)
            {
                var tvaga = estacionamento.TipoVagas.Where(t => t.Descricao == "Moto");
                estacionamento.Vagas.Add(new Vaga(tvaga.FirstOrDefault().Id, numeroVaga));

            }

            for (numeroVaga = 21; numeroVaga <= 70; numeroVaga++)
            {
                var tvaga = estacionamento.TipoVagas.Where(t => t.Descricao == "Carro");
                estacionamento.Vagas.Add(new Vaga(tvaga.FirstOrDefault().Id, numeroVaga));

            }

            for (numeroVaga = 71; numeroVaga <= 99; numeroVaga++)
            {
                var tvaga = estacionamento.TipoVagas.Where(t => t.Descricao == "Utilitários");
                estacionamento.Vagas.Add(new Vaga(tvaga.FirstOrDefault().Id, numeroVaga));

            }
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Escolha uma das opções abaixo");
                    Console.WriteLine("1 - Entrada");
                    Console.WriteLine("2 - Saída");
                    Console.WriteLine("3 - Verificar se a Vagas disponivél");
                    Console.WriteLine("4 - Exibir todas as vaga disponiveis");
                    Console.WriteLine("0 - Sair");
                    opt = Console.ReadLine();
                    if (!int.TryParse(opt, out valorRecebido))
                    {
                        Console.WriteLine("Erro opção invalida, informe um inteiro de 1 a 4");
                    }


                } while (!int.TryParse(opt, out valorRecebido));
                Console.Clear();
                switch (valorRecebido)
                {
                    case 1:

                        idTipoVaga = estacionamento.RetornaIdTipoVaga();

                        Console.WriteLine("Digite o número da placa");
                        placa = Console.ReadLine();

                        numeroVaga = estacionamento.Entrada(idTipoVaga, placa);

                        Console.WriteLine("Estacione na vaga {0}", numeroVaga);

                    break;
                    case 2:
                        Console.WriteLine("Digite o número da placa");
                        placa = Console.ReadLine();
                        if (estacionamento.Vagas.Any(e => e.Placa == placa )) {
                            
                            var valorPagar = estacionamento.Saida(placa);

                            Console.WriteLine("Valor a ser pago R$ {0}", valorPagar);
                        }
                        else
                        {
                            Console.WriteLine("Esse veiculo não esta estacionado aqui");
                        }

                    break;
                    case 3:
                        idTipoVaga = estacionamento.RetornaIdTipoVaga();

                        var vagaDisponivel = estacionamento.VerificaVagaDisponivel(idTipoVaga);

                        Console.WriteLine("Vagas disponiveis {0}", ((vagaDisponivel) ? "Sim" : "Não"));

                    break;
                    case 4:
                        foreach (var vaga in estacionamento.Vagas)
                        {
                            if (vaga.Placa == null)
                            {
                                Console.WriteLine("Vaga: {0} disponível", vaga.NumeroVaga);
                            }
                            else
                            {
                                Console.WriteLine("Vaga: {0} não disponível", vaga.NumeroVaga);
                            }
                        }
                        Console.ReadLine();

                     break;

                }

                Console.ReadLine();

            } while (valorRecebido != 0);
        }

      
    }
}

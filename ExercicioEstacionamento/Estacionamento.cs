using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioEstacionamento
{
    class Estacionamento
    {
        public List<TipoVaga> TipoVagas { get; set; }
        public List<Vaga> Vagas { get; set; }

        public Estacionamento()
        {
            TipoVagas = new List<TipoVaga>();
            Vagas = new List<Vaga>();
        }

        public bool VerificaVagaDisponivel(Guid idTipoVaga)
        {
            if (TipoVagas.Any(t => t.Id == idTipoVaga && t.Descricao != "Carro"))
            {
                return Vagas.Any(v => v.IdTipoVaga == idTipoVaga && v.Placa == null);
            }
            else
            {
                var IdTvUtilitario = TipoVagas.Where(t => t.Descricao == "Utilitários").FirstOrDefault().Id;
                if (Vagas.Any(v => (v.IdTipoVaga == idTipoVaga || v.IdTipoVaga == IdTvUtilitario) && v.Placa == null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int NumeroVagaDisponivel(Guid idTipoVaga)
        {


            if (VerificaVagaDisponivel(idTipoVaga))
            {
                var vagas = Vagas.Where(v => v.IdTipoVaga == idTipoVaga && v.Placa == null);
                if (TipoVagas.Any(t => t.Id == idTipoVaga && t.Descricao != "Carro"))
                {
                    return vagas.FirstOrDefault().NumeroVaga;
                }
                else
                {
                    if (Vagas.Any(v => v.IdTipoVaga == idTipoVaga && v.Placa == null))
                    {
                        return vagas.FirstOrDefault().NumeroVaga;
                    }
                    else
                    {
                        var IdTvUtilitario = TipoVagas.Where(t => t.Descricao == "Utilitários").FirstOrDefault().Id;
                        vagas = Vagas.Where(v => v.IdTipoVaga == IdTvUtilitario && v.Placa == null);
                        return vagas.FirstOrDefault().NumeroVaga;
                    }
                }
            }
            else
            {
                return 0;
            }
        }


        public int Entrada(Guid idTipoVaga, String placa)
        {
            var numeroVaga = NumeroVagaDisponivel(idTipoVaga);
            if (VerificaVagaDisponivel(idTipoVaga))
            {
                var i = Vagas.FindIndex(v => v.IdTipoVaga == idTipoVaga && v.NumeroVaga == numeroVaga);
                Vagas[i].Placa = placa;
                Vagas[i].Entrada = DateTime.Now;
            }
            return numeroVaga;
        }

        public double Saida(String placa)
        {
            double valor = 0;

            var indiceVaga = Vagas.FindIndex(v => v.Placa == placa);
            var idTipoVaga = Vagas[indiceVaga].IdTipoVaga;
            valor = TipoVagas.Where(t => t.Id == idTipoVaga).FirstOrDefault().Valor;

            var entrada = Vagas[indiceVaga].Entrada;
            TimeSpan diferenca = DateTime.Now - entrada;
            double horas = diferenca.TotalMinutes / 60;
            int multiplicador = (int)Math.Ceiling(horas);

            Vagas[indiceVaga].Placa = null;

            return valor * multiplicador;
        }

        public Guid RetornaIdTipoVaga()
        {
            int opt;
            String valorRcebido;
            do
            {

                Console.WriteLine("Escolha uma tipo de veículo");
                Console.WriteLine("1 - Moto");
                Console.WriteLine("2 - Carro");
                Console.WriteLine("3 - Utilitários");
                valorRcebido = Console.ReadLine();
                if (!int.TryParse(valorRcebido, out opt))
                {
                    Console.WriteLine("Erro opção invalida, informe um inteiro de 1 a 3");
                }
            } while (!int.TryParse(valorRcebido, out opt));

            var idTipoVaga = TipoVagas.Where(e => e.Descricao == ((opt == 1) ? "Moto" : ((opt == 2) ? "Carro" : "Utilitários"))).FirstOrDefault().Id;

            return idTipoVaga;
        }
    }
}

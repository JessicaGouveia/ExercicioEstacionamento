using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioEstacionamento
{
    class Vaga
    {
        public Guid IdTipoVaga { get; private set; }
        public int NumeroVaga { get; private set; }
        public String Placa { get; set; }
        public DateTime Entrada { get; set; }

        public Vaga(Guid idTipoVaga, int numeroVaga)
        {
            IdTipoVaga = idTipoVaga;
            NumeroVaga = numeroVaga;
            Placa = null;
        }
    }
}
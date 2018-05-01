using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioEstacionamento
{
    class TipoVaga
    {
        public Guid Id { get; private set; }
        public String Descricao { get; set; }
        public double Valor { get; set; }

        public TipoVaga(Guid id, string descricao, double valor)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
        }
    }





}

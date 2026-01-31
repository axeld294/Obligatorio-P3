using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Puntaje
    {
        public Atleta Atleta { get; set; }
        public int AtletaId { get; set; }
        public int EventoId { get; set; }
        public decimal Valor { get; set; }
        public Puntaje() { }
        public Puntaje(Atleta atleta, decimal valor)
        {
            Atleta = atleta;
            Valor = valor;
        }
    }
}

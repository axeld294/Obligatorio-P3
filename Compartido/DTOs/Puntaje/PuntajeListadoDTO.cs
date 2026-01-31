using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Puntaje
{
    public class PuntajeListadoDTO
    {
        public int AtletaId { get; set; }
        public int EventoId { get; set; }
        public decimal Valor { get; set; }
    }
}

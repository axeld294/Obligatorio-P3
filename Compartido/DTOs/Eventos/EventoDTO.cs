using Compartido.DTOs.Atletas;
using Compartido.DTOs.Disciplina;
using Compartido.DTOs.Puntaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public int Disciplina { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public List<AtletaListadoDTO> Atletas { get; set; }
        public List<PuntajeListadoDTO> Puntajes { get; set; }
    }
}

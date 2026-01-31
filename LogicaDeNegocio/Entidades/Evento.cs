using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        public Disciplina Disciplina { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public List<Atleta> Atletas { get; set; }
        public List<Puntaje> Puntajes { get; set; }
        public Evento() { }
        public Evento(Disciplina disciplina, string nombreprueba, DateTime fechainicio, DateTime fechafin)
        {
            Disciplina = disciplina;
            NombrePrueba = nombreprueba;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            Atletas = new List<Atleta>();
            Puntajes = new List<Puntaje>();
        }
    }
}

using LogicaDeNegocio.ExcepcionesEntidades.Atleta;
using LogicaDeNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Disciplina
    {
        public Nombre Nombre { get; set; }
        public int Id { get; set; }
        public DateTime AñoIngreso { get; set; }
        public List<Atleta> Atletas { get; set; }
        public Disciplina() { }
        public Disciplina(string nombre)
        {
            Nombre = new Nombre(nombre);
            AñoIngreso = DateTime.Now;
        }
        public bool Equals(Disciplina? other)
        {
            return other.Nombre.Equals(Nombre);
        }
    }
}

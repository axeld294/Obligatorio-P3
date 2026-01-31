using LogicaDeNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Atleta: IEntity, IComparable<Atleta>
    {
        public string NombreCompleto { get; set; }
        public Sexo Sexo { get; set; }
        public int Id { get; set; }  
        public Pais Pais { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public Atleta() { }
        public Atleta(string nombreCompleto, Sexo sexo, int id, Pais pais)
        {
            NombreCompleto = nombreCompleto;
            Sexo = sexo;
            Id = id;
            Pais = pais;
            Disciplinas = new List<Disciplina>();
        }

        public int CompareTo(Atleta? other)
        {
            if (other == null) return 1;
            return Pais.NombrePais.Trim().ToUpper().CompareTo(other.Pais.NombrePais.Trim().ToUpper());
        }
    }
}

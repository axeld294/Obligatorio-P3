using Compartido.DTOs.Disciplina;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Disciplinas;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Disciplinas
{
    public class BuscarDisciplinaNombre : IBuscarDisciplinaNombre
    {
        public IRepositorioDisciplina RepoDisciplinas { get; set; }
        public BuscarDisciplinaNombre(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplinas = repoDisciplina;
        }
        public DisciplinaListadoDTO Ejecutar(string name)
        {
            Disciplina disciplina = RepoDisciplinas.FindByName(name);
            if (disciplina == null)
            {
                throw new DisciplinaException("No se encontro la disciplina");
            }
            return MapperDisciplina.DisciplinaToDisciplinaListadoDTO(disciplina);
        }
    }
}

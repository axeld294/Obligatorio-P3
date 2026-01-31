using Compartido.DTOs.Disciplina;
using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Disciplinas;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Disciplinas
{
    public class BuscarDisciplinaID : IBuscarDisciplinaID
    {
        public IRepositorioDisciplina RepoDisciplinas { get; set; }
        public BuscarDisciplinaID(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplinas = repoDisciplina;
        }
        public DisciplinaListadoDTO Ejecutar(int id)
        {
            Disciplina disciplina = RepoDisciplinas.FindbyId(id);
            if (disciplina == null)
            {
                throw new DisciplinaException("No se encontro la disciplina");
            }
            return MapperDisciplina.DisciplinaToDisciplinaListadoDTO(disciplina);
        }
    }
}

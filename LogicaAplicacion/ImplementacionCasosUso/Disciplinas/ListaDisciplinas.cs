using Compartido.DTOs.Disciplina;
using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Disciplinas;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Disciplinas
{
    public class ListaDisciplinas : IListaDisciplinas
    {
        public IRepositorioDisciplina RepoDisciplinas { get; set; }
        public ListaDisciplinas(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplinas = repoDisciplina;
        }
        public IEnumerable<DisciplinaListadoDTO> Ejecutar()
        {
            IEnumerable<Disciplina> disciplinas = RepoDisciplinas.FindAll();
            return MapperDisciplina.ListDisciplinaToListDisciplinaDTO(disciplinas.ToList());
        }
    }
}

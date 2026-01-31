using Compartido.DTOs.Disciplina;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Disciplinas;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Disciplinas
{
    public class EditarDisciplina : IEditarDisciplina
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }
        public EditarDisciplina(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplina = repoDisciplina;
        }
        public void Ejecutar(NewDisciplinaDTO disciplinaEditado, int id)
        {
            RepoDisciplina.Update(MapperDisciplina.DTODisciplinaToDisciplina(disciplinaEditado),id);
        }
    }
}

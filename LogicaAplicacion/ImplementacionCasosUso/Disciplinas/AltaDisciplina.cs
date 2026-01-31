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
    public class AltaDisciplina : IAltaDisciplina
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }
        public AltaDisciplina(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplina = repoDisciplina;
        }
        public void Ejecutar(NewDisciplinaDTO disciplinaDTO)
        {
            Disciplina disciplina = MapperDisciplina.DTODisciplinaToDisciplina(disciplinaDTO);
            RepoDisciplina.Add(disciplina);
            disciplinaDTO.Id = disciplina.Id;
        }
    }
}

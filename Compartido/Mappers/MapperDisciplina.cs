using Compartido.DTOs.Disciplina;
using Compartido.DTOs.Usuarios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class MapperDisciplina
    {
        public static IEnumerable<ListaDisciplinaFiltradaDTO> ListaDisciplinaFilteredToDisciplinaFilteredDTO(List<Disciplina> disciplinas)
        {
            IEnumerable<ListaDisciplinaFiltradaDTO> discFiltradaDTO = disciplinas.Select(u =>
            new ListaDisciplinaFiltradaDTO()
            {
                Nombre = u.Nombre.Valor,
                Id = u.Id,
            }).ToList();
            return discFiltradaDTO;
        }
        public static IEnumerable<DisciplinaListadoDTO> ListDisciplinaToListDisciplinaDTO(List<Disciplina> disciplinas)
        {
            IEnumerable<DisciplinaListadoDTO> disciplinasListado = disciplinas.Select(u => 
            new DisciplinaListadoDTO()
            {
                Nombre = u.Nombre.Valor,
                Id = u.Id,  
                AñoIngreso = u.AñoIngreso
            }).ToList();
            return disciplinasListado;
        }
        public static Disciplina DTODisciplinaToDisciplina(NewDisciplinaDTO disciplinaDTO)
        {
            if (disciplinaDTO == null)
            {
                throw new DisciplinaException("Los datos no son correctos");
            }
            return new Disciplina(disciplinaDTO.Nombre);
        }
        public static DisciplinaListadoDTO DisciplinaToDisciplinaListadoDTO(Disciplina disciplina)
        {
            if (disciplina == null)
            {
                throw new DisciplinaException("Los datos no son correctos");
            }
            return new DisciplinaListadoDTO()
            {
                Id = disciplina.Id,
                AñoIngreso = disciplina.AñoIngreso,
                Nombre = disciplina.Nombre.Valor
            };
        }
    }
}

using Compartido.DTOs.Disciplina;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Atletas;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Atletas
{
    public class ListaDisciplinasFiltradas : IListaDisciplinasFiltradas
    {
        public IRepositorioAtleta RepoAtleta { get; set; }
        public ListaDisciplinasFiltradas(IRepositorioAtleta repoAtleta)
        {
            RepoAtleta = repoAtleta;
        }
        public IEnumerable<ListaDisciplinaFiltradaDTO> Ejecutar(int id)
        {
            IEnumerable<Disciplina> disciplinasFiltradas = RepoAtleta.FindAllFiltered(id);
            return MapperDisciplina.ListaDisciplinaFilteredToDisciplinaFilteredDTO(disciplinasFiltradas.ToList());
        }
    }
}

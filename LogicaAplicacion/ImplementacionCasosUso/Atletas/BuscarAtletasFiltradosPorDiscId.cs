using Compartido.DTOs.Atletas;
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
    public class BuscarAtletasFiltradosPorDiscId : IBuscarAtletasFiltradosPorDiscId
    {
        public IRepositorioAtleta RepoAtletas { get; set; }
        public BuscarAtletasFiltradosPorDiscId(IRepositorioAtleta repoAtletas)
        {
            RepoAtletas = repoAtletas;
        }
        public IEnumerable<AtletaListadoDTO> Ejecutar(int id)
        {
            IEnumerable<Atleta> atletas = RepoAtletas.FindAllFilteredByDiscId(id);
            return MapperAtleta.ListAtletaToListAtletaDTO(atletas.ToList());
        }
    }
}

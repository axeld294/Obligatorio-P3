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
    public class ListaAtletas : IListaAtletas
    {
        public IRepositorioAtleta RepoAtletas { get; set; }
        public ListaAtletas(IRepositorioAtleta repoAtletas)
        {
            RepoAtletas = repoAtletas;
        }

        public IEnumerable<AtletaListadoDTO> Ejecutar()
        {
            IEnumerable<Atleta> atletas = RepoAtletas.FindAll();
            return MapperAtleta.ListAtletaToListAtletaDTO(atletas.ToList());
        }
    }
}

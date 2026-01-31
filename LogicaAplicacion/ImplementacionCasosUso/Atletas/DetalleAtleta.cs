using Compartido.DTOs.Atletas;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfaceCasosUso.Atletas;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.Atleta;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Atletas
{
    public class DetalleAtleta : IDetalleAtleta
    {
        public IRepositorioAtleta RepoAtletas { get; set; }
        public DetalleAtleta(IRepositorioAtleta repoAtletas)
        {
            RepoAtletas = repoAtletas;
        }
        public AtletaDetalleDTO Ejecutar(int id)
        {
            Atleta atleta = RepoAtletas.FindbyId(id);
            if (atleta == null)
            {
                throw new AtletaException("No se encontro el atleta");
            }
            return MapperAtleta.AtletaToAtletaDetalleDTO(atleta);
        }
    }
}

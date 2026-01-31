using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Usuarios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class DetalleUsuario : IDetalleUsuario
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }
        public DetalleUsuario(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }
        public UsuarioDetalleDTO Ejecutar(int id)
        {
            Usuario usuario = RepoUsuarios.FindbyId(id);
            if (usuario == null)
            {
                throw new UsuarioException("No se encontro el usuario");
            }
            return MapperUsuario.UsuarioToUsuarioDetalleDTO(usuario);
        }
    }
}

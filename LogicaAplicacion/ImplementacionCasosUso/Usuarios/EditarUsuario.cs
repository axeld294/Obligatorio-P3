using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Usuarios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class EditarUsuario : IEditarUsuario
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }
        public EditarUsuario(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }
        public void Ejecutar(UsuarioDetalleDTO usuarioDetalleDTO, int id)
        {
            Usuario usuario = MapperUsuario.UsuarioDetalleAUsuario(usuarioDetalleDTO);
            RepoUsuarios.Update(usuario, id);
        }
    }
}

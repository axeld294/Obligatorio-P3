using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
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
    public class AltaUsuario: IAltaUsuario
    {
        public IRepositorioUsuario RepoUsuarios { get; set; } 
        public AltaUsuario(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }
        public void Ejecutar(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = MapperUsuario.DTOUsuarioToUsuario(usuarioDTO);
            RepoUsuarios.Add(usuario);
        }
    }
}

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
    public class LoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }

        public LoginUsuario(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }

        public UsuarioListadoDTO Ejecutar(string name, string password)
        {
            Usuario usuario = RepoUsuarios.FindByEmailAndPassword(name, password);
            return MapperUsuario.UsuarioToUsuarioListadoDTO(usuario);
        }
    }
}
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
    public class ListaUsuarios: IListaUsuarios
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }
        public ListaUsuarios(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }
        public IEnumerable<UsuarioListadoDTO> Ejecutar()
        {
            IEnumerable<Usuario> usuarios = RepoUsuarios.FindAll();
            return MapperUsuario.ListUsuarioToListUsuarioDTO(usuarios.ToList());
        }
    }
}

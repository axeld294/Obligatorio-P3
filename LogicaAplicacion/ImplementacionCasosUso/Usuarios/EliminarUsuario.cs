using LogicaAplicacion.InterfaceCasosUso.Usuarios;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class EliminarUsuario : IEliminarUsuario
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }
        public EliminarUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuarios = repoUsuario;
        }
        public void Ejecutar(int id)
        {
            RepoUsuarios.Delete(id);
        }
    }
}

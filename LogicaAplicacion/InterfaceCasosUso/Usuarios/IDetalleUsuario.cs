using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.Usuarios
{
    public interface IDetalleUsuario
    {
        UsuarioDetalleDTO Ejecutar(int id);
    }
}

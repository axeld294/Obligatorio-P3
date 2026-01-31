using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
    public class UsuarioListadoDTO
    {
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Contraseña { get; set; }
        public int Id { get; set; }
        public string Token { get; set; }
    }
}

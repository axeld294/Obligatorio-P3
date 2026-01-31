using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
    public class UsuarioDTO
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public int AdminId { get; set; }
    }
}

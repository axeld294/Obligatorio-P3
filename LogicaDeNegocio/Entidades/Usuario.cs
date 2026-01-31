using LogicaDeNegocio.InterfacesEntidades;
using LogicaDeNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Usuario: IEntity
    {
        public int Id { get; set; }
        public Email Email { get; set; }
        public Contraseña Contraseña { get; set; }
        public string Rol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int AdminID { get; set; }

        private Usuario() { }
        public Usuario(string email, string contraseña, string rol, int adminId)
        {
            Email = new Email(email);
            Contraseña = new Contraseña(contraseña);
            Rol = rol;
            FechaRegistro = DateTime.Now;
            AdminID = adminId;
        }
    }
}

using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.ValueObjects
{
    [ComplexType]
    public record Email
    {
        public string Valor {  get; init; }

        public Email(string valor)
        {
            Valor = valor;
            Validar();
        }
        public void Validar()
        {
            if (Valor.IndexOf("@")== -1)
            {
                throw new UsuarioException("El email no es correcto");
            }
        }
    }
}

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
    public record Contraseña
    {
        public string Valor { get; init; }

        //public Contraseña() { }

        public Contraseña(string valor)
        {
            Valor = valor;
            Validar();
        }
        public void Validar()
        {
            if (Valor.Trim().Length < 6)
            {
                throw new UsuarioException("La contraseña debe tener 6 caracteres como minimo");
            }
            if (!PasswordValida())
            {
                throw new UsuarioException("La contraseña no cumple con las restricciones indicadas, " +
                    "debe tener por lo menos un número, una letra minúscula y una letra mayúscula");
            }
        }
        private bool PasswordValida()
        {
            int i = 0;
            bool esMinuscula = false;
            bool esMayuscula = false;
            bool tieneDigito = false;
            bool tieneSimbolo = false;
            bool esValido = false;
            while (i < Valor.Length && !esValido)
            {
                if (char.IsLetter(Valor[i]))
                {
                    if (char.IsLower(Valor[i]))
                    {
                        esMinuscula = true;
                    }
                    else
                    {
                        esMayuscula = true;
                    }
                }
                else if (char.IsDigit(Valor[i]))
                {
                    tieneDigito = true;
                } else if (Valor.IndexOf(".") != -1 || Valor.IndexOf(",") != -1 || Valor.IndexOf(";") != -1 || Valor.IndexOf("!") != -1)
                {
                    tieneSimbolo = true;
                }
                if (esMinuscula && esMayuscula && tieneDigito && tieneSimbolo)
                {
                    esValido = true;
                }
                i++;
            }
            return esValido;
        }
    }
}

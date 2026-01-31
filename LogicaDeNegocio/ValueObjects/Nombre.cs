using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
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
    public record Nombre
    {
        public string Valor { get; init; }

        public Nombre(string valor)
        {
            Valor = valor;
            Validar();
        }
        public void Validar()
        {
            if (Valor.Trim().Length < 10 || Valor.Trim().Length > 50)
            {
                throw new DisciplinaException("El nombre de la disciplina debe tener entre 10 y 50 caracteres");
            }
        }
    }
}

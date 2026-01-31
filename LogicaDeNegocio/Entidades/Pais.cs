using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Pais
    {
        [Key]
        public string NombrePais { get; set; }
        public int CantHabitantes { get; set; }
        public string NombreDelegado { get; set; }
        public string TelefonoDelegado { get; set; }
        public Pais() { }
        public Pais(int cantHabitantes, string nombrePais, string nombreDelegado, string telefonoDelegado)
        {
            CantHabitantes = cantHabitantes;
            NombrePais = nombrePais;
            NombreDelegado = nombreDelegado;
            TelefonoDelegado = telefonoDelegado;
        }
    }
}

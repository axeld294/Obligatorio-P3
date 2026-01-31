using Compartido.DTOs.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Atletas
{
    public class AtletaListadoDTO
    {
        public string NombreCompleto { get; set; }
        public int Sexo { get; set; }
        public string Pais { get; set; }
        public int Id { get; set; }
        public List<DisciplinaListadoDTO> Disciplinas { get; set; }
    }
}

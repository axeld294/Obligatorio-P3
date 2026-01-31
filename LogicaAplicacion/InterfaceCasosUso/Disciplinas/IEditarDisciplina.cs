using Compartido.DTOs.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.Disciplinas
{
    public interface IEditarDisciplina
    {
        void Ejecutar(NewDisciplinaDTO disciplinaEditado, int id);
    }
}

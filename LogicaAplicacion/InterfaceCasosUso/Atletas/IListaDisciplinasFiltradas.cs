using Compartido.DTOs.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.Atletas
{
    public interface IListaDisciplinasFiltradas
    {
        IEnumerable<ListaDisciplinaFiltradaDTO> Ejecutar(int id);
    }
}

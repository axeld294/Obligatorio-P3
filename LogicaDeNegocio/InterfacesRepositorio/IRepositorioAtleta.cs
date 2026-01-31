using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorioAtleta : IRepositorio<Atleta>
    {
        IEnumerable<Disciplina> FindAllFiltered(int id);
        void AddDisciplina(int atletaId, int disciplinaId);
        IEnumerable<Atleta> FindAllFilteredByDiscId(int id);
    }
}

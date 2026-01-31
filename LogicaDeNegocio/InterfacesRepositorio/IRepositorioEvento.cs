using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        IEnumerable<Evento> FindByDiscId(int id);
        IEnumerable<Evento> FindByDateRange(DateTime fechaInicio, DateTime fechafin);
        IEnumerable<Evento> FindByPartialName(string name);
        IEnumerable<Evento> FindByPointsRange(decimal pmin, decimal pmax);
    }
}

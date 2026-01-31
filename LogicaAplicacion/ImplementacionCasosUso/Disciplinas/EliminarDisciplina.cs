using LogicaAplicacion.InterfaceCasosUso.Disciplinas;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Disciplinas
{
    public class EliminarDisciplina : IEliminarDisciplina
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }
        public EliminarDisciplina(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplina = repoDisciplina;
        }
        public void Ejecutar(int id)
        {
            RepoDisciplina.Delete(id);
        }
    }
}

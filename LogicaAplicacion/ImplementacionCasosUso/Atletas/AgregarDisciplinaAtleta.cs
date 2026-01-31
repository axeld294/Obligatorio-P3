using LogicaAplicacion.InterfaceCasosUso.Atletas;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Atletas
{
    public class AgregarDisciplinaAtleta: IAgregarDisciplinaAtleta
    {
        public IRepositorioAtleta RepoAtletas { get; set; }
        public AgregarDisciplinaAtleta(IRepositorioAtleta repoAtletas)
        {
            RepoAtletas = repoAtletas;
        }
        public void Ejecutar(int atletaId, int disciplinaId)
        {
            RepoAtletas.AddDisciplina(atletaId, disciplinaId);
        }
    }
}

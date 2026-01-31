using Compartido.DTOs.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.Atletas
{
    public interface IDetalleAtleta
    {
        AtletaDetalleDTO Ejecutar(int id);
    }
}

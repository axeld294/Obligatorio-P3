using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Eventos;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.Evento;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Eventos
{
    public class EventoPorRangoPuntajes : IEventoPorRangoPuntajes
    {
        public IRepositorioEvento RepoEventos { get; set; }
        public EventoPorRangoPuntajes(IRepositorioEvento repoEventos)
        {
            RepoEventos = repoEventos;
        }
        public IEnumerable<EventoDTO> Ejecutar(decimal pmin, decimal pmax)
        {
            IEnumerable<Evento> eventos = RepoEventos.FindByPointsRange(pmin, pmax);
            if (eventos == null)
            {
                throw new EventoException("No se encontro la disciplina");
            }
            return MapperEvento.ListEventoToEventoDTO(eventos.ToList());
        }
    }
}

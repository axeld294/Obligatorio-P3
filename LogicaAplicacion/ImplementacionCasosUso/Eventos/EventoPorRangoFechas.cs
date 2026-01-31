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
    public class EventoPorRangoFechas : IEventoPorRangoFechas
    {
        public IRepositorioEvento RepoEventos { get; set; }
        public EventoPorRangoFechas(IRepositorioEvento repoEventos)
        {
            RepoEventos = repoEventos;
        }
        public IEnumerable<EventoDTO> Ejecutar(DateTime fechaInicio, DateTime fechafin)
        {
            IEnumerable<Evento> eventos = RepoEventos.FindByDateRange(fechaInicio, fechafin);
            if (eventos == null)
            {
                throw new EventoException("No se encontro la disciplina");
            }
            return MapperEvento.ListEventoToEventoDTO(eventos.ToList());
        }
    }
}

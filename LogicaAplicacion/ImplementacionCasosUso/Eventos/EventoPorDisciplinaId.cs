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
    public class EventoPorDisciplinaId : IEventoPorDisciplinaId
    {
        public IRepositorioEvento RepoEventos { get; set; }
        public EventoPorDisciplinaId(IRepositorioEvento repoEventos)
        {
            RepoEventos = repoEventos;
        }
        public IEnumerable<EventoDTO> Ejecutar(int id)
        {
            IEnumerable<Evento> eventos = RepoEventos.FindByDiscId(id);
            if (eventos == null)
            {
                throw new EventoException("No se encontro la disciplina");
            }
            return MapperEvento.ListEventoToEventoDTO(eventos.ToList());
        }
    }
}

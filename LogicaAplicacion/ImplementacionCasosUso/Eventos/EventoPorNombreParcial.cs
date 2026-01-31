using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.Eventos;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
using LogicaDeNegocio.ExcepcionesEntidades.Evento;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Eventos
{
    public class EventoPorNombreParcial : IEventoPorNombreParcial
    {
        public IRepositorioEvento RepoEventos { get; set; }
        public EventoPorNombreParcial(IRepositorioEvento repoEventos)
        {
            RepoEventos = repoEventos;
        }
        public IEnumerable<EventoDTO> Ejecutar(string nombre)
        {
            IEnumerable<Evento> eventos = RepoEventos.FindByPartialName(nombre);
            if (eventos == null)
            {
                throw new EventoException("No se encontro la disciplina");
            }
            return MapperEvento.ListEventoToEventoDTO(eventos.ToList());
        }
    }
}

using Compartido.DTOs.Atletas;
using Compartido.DTOs.Disciplina;
using Compartido.DTOs.Eventos;
using Compartido.DTOs.Puntaje;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class MapperEvento
    {
        public static IEnumerable<EventoDTO> ListEventoToEventoDTO(List<Evento> eventos)
        {
            IEnumerable<EventoDTO> eventosDTO = eventos.Select(u =>
            new EventoDTO()
            {
                Id = u.Id,
                Disciplina = u.Disciplina.Id,
                NombrePrueba = u.NombrePrueba,
                FechaInicio = u.FechaInicio,
                FechaFin = u.FechaFin,
                Atletas = u.Atletas.Select(d => new AtletaListadoDTO
                {
                    NombreCompleto = d.NombreCompleto,
                    Sexo = (int)d.Sexo,
                    Pais = d.Pais.NombrePais,
                    Id = d.Id,
                    Disciplinas = d.Disciplinas.Select(a => new DisciplinaListadoDTO
                    {
                        Nombre = a.Nombre.Valor,
                        AñoIngreso = a.AñoIngreso
                    }).ToList()
                }).ToList(),
                Puntajes = u.Puntajes.Select(a => new PuntajeListadoDTO
                {
                    AtletaId = a.AtletaId,
                    EventoId = a.EventoId,
                    Valor = a.Valor
                }).ToList()
            });
            return eventosDTO;
        }
    }
}

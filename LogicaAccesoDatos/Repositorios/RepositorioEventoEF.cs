using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEventoEF : IRepositorioEvento
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioEventoEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Evento item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Evento item, int id)
        {
            throw new NotImplementedException();
        }

        public Evento FindbyId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> FindAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Evento> FindByDiscId(int id)
        {
            return Contexto.Eventos
                .Include(e => e.Disciplina)               
                .Include(e => e.Atletas)                 
                .ThenInclude(a => a.Pais)                
                .Include(e => e.Puntajes)                
                .Where(e => e.Disciplina.Id == id)      
                .ToList();
        }
        public IEnumerable<Evento> FindByDateRange(DateTime fechaInicio, DateTime fechafin)
        {
            return Contexto.Eventos
                .Include(e => e.Disciplina)
                .Include(e => e.Atletas)
                .ThenInclude(a => a.Pais)
                .Include(e => e.Puntajes)
                .Where(e => e.FechaInicio >= fechaInicio && e.FechaInicio <= fechafin)
                .ToList();
        }
        public IEnumerable<Evento> FindByPartialName(string name)
        {
            return Contexto.Eventos
                .Include(e => e.Disciplina)
                .Include(e => e.Atletas)
                .ThenInclude(a => a.Pais)
                .Include(e => e.Puntajes)
                .Where(e => e.NombrePrueba.Trim().ToLower().Contains(name.Trim().ToLower()))
                .ToList();
        }
        public IEnumerable<Evento> FindByPointsRange(decimal pmin, decimal pmax)
        {
            return Contexto.Eventos
                .Include(e => e.Disciplina)           
                .Include(e => e.Atletas)            
                .ThenInclude(a => a.Pais)            
                .Include(e => e.Puntajes)            
                .Where(e => e.Puntajes.Any(p => p.Valor >= pmin && p.Valor <= pmax)) 
                .ToList();
        }
    }
}

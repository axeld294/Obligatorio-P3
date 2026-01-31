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
    public class RepositorioAtletaEF : IRepositorioAtleta
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioAtletaEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Atleta item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Atleta item, int id)
        {
            throw new NotImplementedException();
        }

        public Atleta FindbyId(int id)
        {
            return Contexto.Atletas.Include(a => a.Pais).Include(a => a.Disciplinas).ToList().FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Atleta> FindAll()
        {
            return Contexto.Atletas.Include(a => a.Pais)
                .Include(a => a.Disciplinas).ToList()
                .OrderBy(a => a.Pais.NombrePais.Trim().ToUpper())
                .ThenBy(a => ObtenerApellido(a.NombreCompleto).ToUpper()) 
                .ThenBy(a => ObtenerNombre(a.NombreCompleto).ToUpper()); ;
        }
        private string ObtenerApellido(string nombreCompleto)
        {
            var partes = nombreCompleto.Split(' ');
            return partes.Length > 1 ? partes.Last() : nombreCompleto; 
        }

        private string ObtenerNombre(string nombreCompleto)
        {
            var partes = nombreCompleto.Split(' ');
            return partes.Length > 1 ? string.Join(" ", partes.Take(partes.Length - 1)) : nombreCompleto; // Resto como nombre
        }
        public IEnumerable<Disciplina> FindAllFiltered(int id)
        {
            IEnumerable<int> disciplinasAtletaIds = Contexto.Atletas.Where(a => a.Id == id).SelectMany(a => a.Disciplinas.Select(d => d.Id)).ToList();
            IEnumerable<Disciplina> disciplinasFiltradas = Contexto.Disciplinas.Where(d => !disciplinasAtletaIds.Contains(d.Id)).ToList();
            return disciplinasFiltradas;
        }
        public void AddDisciplina(int atletaId, int disciplinaId)
        {
            Atleta atleta = FindbyId(atletaId);
            Disciplina disciplinaNueva = Contexto.Disciplinas.Where(u => u.Id == disciplinaId).SingleOrDefault();
            if (atleta != null)
            {
                atleta.Disciplinas.Add(disciplinaNueva);
                Contexto.SaveChanges();
            }
        }
        public IEnumerable<Atleta> FindAllFilteredByDiscId(int id)
        {
            return Contexto.Atletas
                .Include(a => a.Pais)
                .Include(a => a.Disciplinas)
                .Where(atleta => atleta.Disciplinas.Any(disciplina => disciplina.Id == id))
                .OrderBy(atleta => atleta.NombreCompleto.Trim().ToUpper())
                .ToList();
        }
    }
}

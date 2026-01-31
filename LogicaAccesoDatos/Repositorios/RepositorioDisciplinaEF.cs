using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades;
using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioDisciplinaEF : IRepositorioDisciplina
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioDisciplinaEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Disciplina item)
        {
            Disciplina disciplinaEcontrada = FindByName(item.Nombre.Valor);
            if (disciplinaEcontrada == null)
            {
                Contexto.Disciplinas.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ConflictException("Ya existe una disciplina con ese nombre");
            }
        }

        public void Delete(int id)
        {
            Disciplina disciplina = FindbyId(id);
            if (disciplina != null)
            {
                Contexto.Disciplinas.Remove(disciplina);
                Contexto.SaveChanges();
            }
            else
            {
                throw new DisciplinaException("No se encontro disciplina con ese id");
            }
        }

        public IEnumerable<Disciplina> FindAll()
        {
            return Contexto.Disciplinas.OrderBy(d => d.Nombre.Valor).ToList();
        }

        public Disciplina FindbyId(int id)
        {
            return Contexto.Disciplinas.Find(id);
        }
        public Disciplina FindByName(string name)
        {
            return Contexto.Disciplinas.Where(a => a.Nombre.Valor == name).SingleOrDefault();
        }
        public void Update(Disciplina item, int id)
        {
            Disciplina disciplina = FindbyId(id);
            if (disciplina == null)
            {
                throw new DisciplinaException("Disciplina no encontrada");
            }
            if (disciplina.Nombre.Valor != item.Nombre.Valor)
            {
                Disciplina disciplinaEncontrada = FindByName(item.Nombre.Valor);
                if (disciplinaEncontrada != null)
                {
                    throw new ConflictException("El nombre ya está en uso por otra disciplina");
                }
                disciplina.Nombre = item.Nombre;
            }
            Contexto.Disciplinas.Update(disciplina);
            Contexto.SaveChanges();
        }
    }
}

using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioUsuarioEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Usuario item)
        {
            Usuario usuarioEcontrado = FindByEmail(item.Email.Valor);
            if (usuarioEcontrado == null)
            {
                Contexto.Usuarios.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Ya existe un usuario con ese email");
            }
        }
        public void Delete(int id)
        {
            Usuario usuario = FindbyId(id);
            if (usuario != null)
            {
                Contexto.Usuarios.Remove(usuario);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("No se encontro usuario con ese id");
            }
        }
        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios;
        }
        public Usuario FindbyId(int id)
        {
            return Contexto.Usuarios.Find(id);
        }
        public void Update(Usuario item, int id)
        {
            Usuario usuario = FindbyId(id);
            if (usuario == null)
            {
                throw new UsuarioException("Usuario no encontrado");
            }
            if (usuario.Email.Valor != item.Email.Valor)
            {
                Usuario usuarioEncontrado = FindByEmail(item.Email.Valor);
                if (usuarioEncontrado != null)
                {
                    throw new UsuarioException("El email ya está en uso por otro usuario");
                }
                usuario.Email = item.Email;
            }
            usuario.Contraseña = item.Contraseña;
            usuario.Rol = item.Rol;
            Contexto.Usuarios.Update(usuario);
            Contexto.SaveChanges();
        }
        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios.Where(Usuario => Usuario.Email.Valor == email).SingleOrDefault();
        }
        public Usuario FindByEmailAndPassword(string email, string password)
        {
            return Contexto.Usuarios.Where(u => u.Email.Valor == email && u.Contraseña.Valor == password).SingleOrDefault();
        }
    }
}

using Compartido.DTOs.Usuarios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using LogicaDeNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class MapperUsuario
    {
        public static Usuario DTOUsuarioToUsuario(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new UsuarioException("Los datos no son correctos");
            }
            return new Usuario(usuarioDTO.Email, usuarioDTO.Contraseña, usuarioDTO.Rol, usuarioDTO.AdminId);
        }
        public static IEnumerable<UsuarioListadoDTO> ListUsuarioToListUsuarioDTO(List<Usuario> usuarios)
        {
            IEnumerable<UsuarioListadoDTO> usuariosDtos = usuarios.Select(u =>
            new UsuarioListadoDTO()
            {
                Email = u.Email.Valor,
                Contraseña = u.Contraseña.Valor,
                Rol = u.Rol,
                Id = u.Id
            });
            return usuariosDtos;
        }
        public static UsuarioDetalleDTO UsuarioToUsuarioDetalleDTO(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new UsuarioException("Los datos no son correctos");
            }
            return new UsuarioDetalleDTO()
            {
                Id = usuario.Id,
                Email = usuario.Email.Valor,
                Contraseña = usuario.Contraseña.Valor,
                Rol = usuario.Rol
            };
        }
        public static Usuario UsuarioDetalleAUsuario(UsuarioDetalleDTO usuarioDetalleDTO)
        {
            if (usuarioDetalleDTO == null)
            {
                throw new UsuarioException("Los datos no son correctos");
            }
            return new Usuario(usuarioDetalleDTO.Email, usuarioDetalleDTO.Contraseña, usuarioDetalleDTO.Rol, usuarioDetalleDTO.AdminId);
        }

        public static UsuarioListadoDTO UsuarioToUsuarioListadoDTO(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new UsuarioException("El usuario y/o la contraseña, es incorrecta");
            }
            return new UsuarioListadoDTO()
            {
                Id = usuario.Id,
                Rol = usuario.Rol,
                Email = usuario.Email.Valor,
            };
        }
    }
}

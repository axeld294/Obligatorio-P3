using Compartido.DTOs.Usuarios;
using LogicaAplicacion.InterfaceCasosUso.Usuarios;
using LogicaDeNegocio.ExcepcionesEntidades.Usuario;
using Microsoft.AspNetCore.Mvc;
using WebAPILibreria.Token;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public ILoginUsuario LoginUsuario { get; set; }
        public UsuarioController(ILoginUsuario loginUsuario)
        {
            LoginUsuario = loginUsuario;
        }

        [HttpPost("login/{email}/{contraseña}")]
        public IActionResult Login(string email, string contraseña)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
                {
                    return BadRequest("Los datos no son correctos");
                }
                UsuarioListadoDTO usuario = LoginUsuario.Ejecutar(email, contraseña);
                if (usuario != null)
                {
                    usuario.Token = ManejadorToken.CrearToken(usuario);
                    return Ok(usuario);
                }
                return NotFound("No se encontro el usuario");
            }
            catch (UsuarioException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            catch (UsuarioException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}

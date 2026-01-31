using LogicaAplicacion.ImplementacionCasosUso.Disciplinas;
using LogicaAplicacion.InterfaceCasosUso.Eventos;
using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
using LogicaDeNegocio.ExcepcionesEntidades.Evento;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IEventoPorDisciplinaId EventoPorDisciplinaId { get; set; }
        public IEventoPorRangoFechas EventoPorRangoFechas { get; set; }
        public IEventoPorNombreParcial EventoPorNombreParcial { get; set; }
        public IEventoPorRangoPuntajes EventoPorRangoPuntajes { get; set; }
        public EventoController(IEventoPorDisciplinaId eventoPorDisciplinaId, IEventoPorRangoFechas eventoPorRangoFechas, IEventoPorNombreParcial eventoPorNombreParcial, IEventoPorRangoPuntajes eventoPorRangoPuntajes)
        {
            EventoPorDisciplinaId = eventoPorDisciplinaId;
            EventoPorRangoFechas = eventoPorRangoFechas;
            EventoPorNombreParcial = eventoPorNombreParcial;
            EventoPorRangoPuntajes = eventoPorRangoPuntajes;
        }
        /*// GET: api/<EventoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        /// <summary>
        /// Permite traer todos los eventos que tengan por disciplinaId al ID pasado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<EventoController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("disciplina/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El id no es correcto");
                }
                return Ok(EventoPorDisciplinaId.Ejecutar(id));
            }
            catch (EventoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /// <summary>
        /// Permite traer todos los eventos que se encuentren entre las 2 fechas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<EventoController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("fechas/{fechaInicio}/{fechaFin}")]
        public IActionResult Get(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio == default || fechaFin == default)
                {
                    return BadRequest("Las fechas no son válidas");
                }
                if (fechaInicio > fechaFin)
                {
                    return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin");
                }
                return Ok(EventoPorRangoFechas.Ejecutar(fechaInicio, fechaFin));
            }
            catch (EventoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en los datos: {ex.Message}");
            }
        }

        /// <summary>
        /// Permite traer todos los eventos cuyo nombre incluya el parametro NOMBRE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<EventoController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("nombre/{nombre}")]
        public IActionResult Get(string nombre)
        {
            try
            {
                if (nombre == "" || nombre == null)
                {
                    return BadRequest("El nombre no puede ser vacio");
                }
                return Ok(EventoPorNombreParcial.Ejecutar(nombre));
            }
            catch (EventoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en los datos: {ex.Message}");
            }
        }

        /// <summary>
        /// Permite traer todos los eventos donde al menos 1 atleta recibio un puntaje entre el rango dado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<EventoController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("puntaje/{puntajeMin}/{puntajeMax}")]
        public IActionResult Get(decimal puntajeMin, decimal puntajeMax)
        {
            try
            {
                if (puntajeMin == null || puntajeMax == null)
                {
                    return BadRequest("Los puntajes no pueden ser vacios");
                }
                if (puntajeMin > puntajeMax)
                {
                    return BadRequest("El puntaje minimo no puede ser mas grande que el puntaje maximo");
                }
                if (puntajeMin > 10 || puntajeMax > 10)
                {
                    return BadRequest("El puntaje no puede ser mayor a 10");
                }
                return Ok(EventoPorRangoPuntajes.Ejecutar(puntajeMin, puntajeMax));
            }
            catch (EventoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en los datos: {ex.Message}");
            }
        }

        /*// POST api/<EventoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}

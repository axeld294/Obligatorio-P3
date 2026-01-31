using Compartido.DTOs.Disciplina;
using LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using LogicaAplicacion.InterfaceCasosUso.Disciplinas;
using LogicaDeNegocio.ExcepcionesEntidades;
using LogicaDeNegocio.ExcepcionesEntidades.DisciplinaException;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        public IListaDisciplinas ListaDisciplinas { get; set; }
        public IBuscarDisciplinaID BuscarDisciplinaID { get; set; }
        public IAltaDisciplina AltaDisciplina { get; set; }
        public IEditarDisciplina EditarDisciplina { get; set; }
        public IEliminarDisciplina EliminarDisciplina { get; set; }
        public IBuscarDisciplinaNombre BuscarDisciplinaNombre { get; set; }
        public DisciplinaController(IListaDisciplinas listaDisciplinas, IBuscarDisciplinaID buscarDisciplinaID, IAltaDisciplina altaDisciplina, IEditarDisciplina editarDisciplina, IEliminarDisciplina eliminarDisciplina, IBuscarDisciplinaNombre buscarDisciplinaNombre)
        {
            ListaDisciplinas = listaDisciplinas;
            BuscarDisciplinaID = buscarDisciplinaID;
            AltaDisciplina = altaDisciplina;
            EditarDisciplina = editarDisciplina;
            EliminarDisciplina = eliminarDisciplina;
            BuscarDisciplinaNombre = buscarDisciplinaNombre;
        }
        /// <summary>
        /// Permite obtener todas las disciplinas
        /// </summary>
        /// <returns></returns>
        // GET: api/<DisciplinaController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ListaDisciplinas.Ejecutar());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /// <summary>
        /// Obtiene una sola disciplina segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        // GET api/<DisciplinaController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        [HttpGet("{id}", Name = "FindbyId")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El id no es correcto");
                }
                return Ok(BuscarDisciplinaID.Ejecutar(id));
            }
            catch (DisciplinaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /// <summary>
        /// Permite buscar una disciplina segun su Nombre
        /// </summary>
        /// <param name="nombreDisc"></param>
        /// <returns></returns>
        // GET api/<DisciplinaController>/Baloncesto
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        [HttpGet("porNombre/{nombreDisc}")]
        public IActionResult Get(string nombreDisc)
        {
            try
            {
                if (nombreDisc == "")
                {
                    return BadRequest("El nombre no puede ser vacio");
                }
                return Ok(BuscarDisciplinaNombre.Ejecutar(nombreDisc));
            }
            catch (DisciplinaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /// <summary>
        ///¨Permite hacer Post de una nueva disciplina
        /// </summary>
        /// <param name="newDisciplinaDTO"></param>
        /// <returns></returns>
        // POST api/<DisciplinaController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] NewDisciplinaDTO newDisciplinaDTO)
        {
            try
            {
                if (newDisciplinaDTO == null)
                {
                    return BadRequest("Datos incorrectos");
                }
                if (newDisciplinaDTO.Id > 0 )
                {
                    return BadRequest("El Id debe ser 0");
                }
                AltaDisciplina.Ejecutar(newDisciplinaDTO);
                return CreatedAtRoute("FindbyId", new { Id = newDisciplinaDTO.Id }, newDisciplinaDTO);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /// <summary>
        /// Permite hacer PUT de una disciplina existente buscada por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newDisciplinaDTO"></param>
        /// <returns></returns>
        // PUT api/<DisciplinaController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NewDisciplinaDTO newDisciplinaDTO)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El Id debe ser distinto a 0");
                }
                if (id != newDisciplinaDTO.Id)
                {
                    return BadRequest("Los Id recibidos no son correctos");
                }
                EditarDisciplina.Ejecutar(newDisciplinaDTO, id);
                return Ok(newDisciplinaDTO);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /// <summary>
        /// Permite hacer DELETE de una disciplina existente por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<DisciplinaController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El Id debe ser distinto a 0");
                }
                EliminarDisciplina.Ejecutar(id);
                return NoContent();
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }
    }
}

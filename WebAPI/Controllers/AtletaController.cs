using LogicaAplicacion.ImplementacionCasosUso.Atletas;
using LogicaAplicacion.InterfaceCasosUso.Atletas;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        public IBuscarAtletasFiltradosPorDiscId BuscarAtletasFiltradosPorDiscId { get; set; }
        public IListaAtletas ListaAtletas {  get; set; }
        public AtletaController(IBuscarAtletasFiltradosPorDiscId buscarAtletasFiltradosPorDiscId, IListaAtletas listaAtletas)
        {
            BuscarAtletasFiltradosPorDiscId = buscarAtletasFiltradosPorDiscId;
            ListaAtletas = listaAtletas;
        }
        // GET: api/<AtletaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ListaAtletas.Ejecutar());
        }

        /// <summary>
        /// Devolvera la lista de atletas que esten registrados en la disciplina con id ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<AtletaController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("filtradosDisciplina/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El id no es correcto");
                }
                return Ok(BuscarAtletasFiltradosPorDiscId.Ejecutar(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /*// POST api/<AtletaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AtletaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AtletaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}

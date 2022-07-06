using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using DataAccess.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private IRepositorioCompra repoCompra;

        public ComprasController(IRepositorioCompra repoCompras)
        {
            repoCompra = repoCompras;
        }




        // GET: api/<ComprasController>
        [HttpGet]
        public ActionResult<Compra> Get()
        {
            try
            {
                List<Compra> compras = (List<Compra>)repoCompra.Get();

                if (compras == null || compras.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(compras);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // GET api/<ComprasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComprasController>
        [HttpPost]
        public ActionResult<Compra> Post([FromBody] Compra compra)
        {
            try
            {
                if(compra == null)
                {
                    return BadRequest("No se puede dar de alta una compra vacía");
                }
                if (repoCompra.Insert2(compra))
                {
                    //return CreatedAtRoute("Get", new { Id = compra.Id }, compra);
                    return Ok(compra.Id);
                }

                return Conflict(compra);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }



        }

        // PUT api/<ComprasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComprasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

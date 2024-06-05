using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace waMusicPro.Controllers.data
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Models.Producto> Get()
        {
            return Data.Productos.Listar();
        }

        // POST: api/Producto
        [HttpPost]
        public IHttpActionResult Post([FromBody] Models.Producto p)
        {
            Data.Productos.Insertar(p);
            return Ok();
        }



        // PUT: api/Producto
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Models.Producto p)
        {
            bool v = Data.Productos.Actualizar(p);
            return Ok();
        }

        // DELETE: api/Producto/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id, [FromBody] Models.Producto p)
        {
            bool resultado = Data.Productos.Eliminar(p);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
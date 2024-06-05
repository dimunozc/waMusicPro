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
    public class CarritoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Models.Carrito> Get()
        {
            return Data.Carrito.Obtener();
        }


        // POST: api/Carrito
        [HttpPost]
        public HttpResponseMessage Post(Models.Carrito carrito)
        {
            Console.WriteLine("LLEGAMOS A LA API");
            var httpRequest = HttpContext.Current.Request;

            // Obtener los datos del formulario

            if (ModelState.IsValid)
            {
                // Guardar el Carrito en la base de datos
                Data.Carrito.Insertar(carrito);
                return Request.CreateResponse(HttpStatusCode.OK, "Carrito creado exitosamente");
            }

            Console.WriteLine("Estado Invalido");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }


        // PUT: api/Carrito
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Models.Carrito p)
        {
            bool v = Data.Carrito.Actualizar(p);
            return Ok();
        }
    }
}
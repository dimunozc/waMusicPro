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
    public class UsuarioController : ApiController
    { 
    [HttpGet]
        public IEnumerable<Models.Usuario> Get()
    {
        return Data.Usuarios.Listar();
    }

    // POST: api/Usuario
    [HttpPost]
    public IHttpActionResult Post([FromBody] Models.Usuario u)
    {
        Data.Usuarios.Insertar(u);
        return Ok();
    }



    // PUT: api/Usuario
    [HttpPut]
    public IHttpActionResult Put(string username, [FromBody] Models.Usuario u)
    {
        bool v = Data.Usuarios.ActualizarClave(u);
        return Ok();
    }

    // DELETE: api/Usuario/{username}
    [HttpDelete]
    public IHttpActionResult Delete(string username, [FromBody] Models.Usuario u)
    {
        bool resultado = Data.Usuarios.Eliminar(u);

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
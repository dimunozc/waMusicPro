using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waMusicPro.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public bool Vigente { get; set; }
    }
}
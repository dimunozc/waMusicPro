using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waMusicPro.Models
{
    public class DetalleCarrito
    {
        public int DetalleId { get; set; }
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Valor { get; set; }
        public int Cantidad { get; set; }
    }
}
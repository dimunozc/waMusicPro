using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waMusicPro.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int ClienteId { get; set; }
        public int ValorTotal { get; set; } 
        public bool Estado { get; set; }
        public string FechaCreacion { get; set; }
    }
}
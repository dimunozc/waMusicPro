using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waMusicPro.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string User { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string CorreoElectronico { get; set; }

        public string TipoUsuario { get; set; } = "cliente";
    }

}

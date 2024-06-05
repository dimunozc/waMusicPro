using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using waMusicPro.Models;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace waMusicPro.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET Account
        [HttpGet]
        public ActionResult LoginIndex()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "server=DIEGO\\SQLEXPRESS;database=WaMusicPro;integrated security = true;";
        }

        [HttpPost]
        public ActionResult Verify(UserModel acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Usuario where username='" + acc.User + "' and password='" + acc.Pass + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                Session["Usuario"] = new Models.UserModel() { User = acc.User, Pass = acc.Pass };
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                con.Close();
                return RedirectToAction("Inicio", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("LoginIndex", "Login");
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(UserModel Usuario)
        {
            if (ModelState.IsValid)
            {
                // Cadena de conexión a la base de datos
                string connectionString = "Server=DIEGO\\SQLEXPRESS;Database=waMusicPro;Trusted_Connection=True;";

                // Sentencia SQL para insertar los datos en la tabla Usuarios
                string insertQuery = "INSERT INTO Usuario (username, correoElectronico, password, tipoUsuario) VALUES (@NombreUsuario, @CorreoElectronico, @Pass, @TipoUsuario)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", Usuario.User);
                        command.Parameters.AddWithValue("@CorreoElectronico", Usuario.CorreoElectronico);
                        command.Parameters.AddWithValue("@Pass", Usuario.Pass);
                        command.Parameters.AddWithValue("@TipoUsuario", Usuario.TipoUsuario);

                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("RegistroExitoso");
            }
            else
            {
                return View();
            }
        }
    }
}
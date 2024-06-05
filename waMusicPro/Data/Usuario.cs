using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace waMusicPro.Data
{
    public static class Usuarios
    {
        public static bool Insertar(Models.Usuario obj)
        {
            int iResultado = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Usuario (username, password) VALUES (@username, @password)";
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@username", obj.Username);
                    cmd.Parameters.AddWithValue("@password", obj.Password);

                    conn.Open();
                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }


        public static bool ActualizarClave(Models.Usuario obj)
        {
            int iResultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("UPDATE Usuario SET password = '{0}' WHERE username = '{1}'", obj.Password, obj.Username);
                    cmd.Connection = conn;
                    conn.Open();

                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }

        public static bool Eliminar(Models.Usuario obj)
        {
            int iResultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("DELETE from Usuario where username = {0}", obj.Username);
                    cmd.Connection = conn;
                    conn.Open();

                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }

        public static List<Models.Usuario> Listar()
        {

            List<Models.Usuario> listado = new List<Models.Usuario>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Usuario";
                    //cmd.Parameters.Add("@personaId", SqlDbType.Int).Value = obj.personaId;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            listado.Add(new Models.Usuario()
                            {
                                Username = sdr["username"].ToString(),
                                Password = sdr["Password"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return listado;
        }

    }
}
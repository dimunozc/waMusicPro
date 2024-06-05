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
    public static class Productos
    {
        public static bool Insertar(Models.Producto obj)
        {
            int iResultado = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Productos (Nombre, Descripcion, Precio, Cantidad, Vigente) VALUES (@Nombre, @Descripcion, @Precio, @Cantidad, @Vigente)";
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@Vigente", obj.Vigente ? 1 : 0);

                    conn.Open();
                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }


        public static bool Actualizar(Models.Producto obj)
        {
            int iResultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("UPDATE Productos SET Nombre = '{0}', Descripcion = '{1}', Precio = {2}, Cantidad = {3}, Vigente = {4}   WHERE ProductoId = {5}", obj.Nombre, obj.Descripcion, obj.Precio, obj.Cantidad, obj.Vigente ? 1 : 0, obj.ProductoId);
                    cmd.Connection = conn;
                    conn.Open();

                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }

        public static bool Eliminar(Models.Producto obj)
        {
            int iResultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("DELETE from Productos where ProductoId = {0}", obj.ProductoId);
                    cmd.Connection = conn;
                    conn.Open();

                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }

        public static List<Models.Producto> Listar()
        {

            List<Models.Producto> listado = new List<Models.Producto>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Productos";
                    //cmd.Parameters.Add("@personaId", SqlDbType.Int).Value = obj.personaId;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            listado.Add(new Models.Producto()
                            {
                                ProductoId = int.Parse(sdr["ProductoId"].ToString()),
                                Nombre = sdr["Nombre"].ToString(),
                                Descripcion = sdr["Descripcion"].ToString(),
                                Precio = int.Parse(sdr["Precio"].ToString()),
                                Cantidad = int.Parse(sdr["Cantidad"].ToString()),
                                Vigente = bool.Parse(sdr["Vigente"].ToString())
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
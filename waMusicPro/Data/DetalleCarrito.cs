using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace waMusicPro.Data
{
    public class DetalleCarrito
    {
        public static bool Insertar(Models.DetalleCarrito obj)
        {
            int iResultado = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO DetalleCarrito (carritoId, productoId, valor, cantidad) VALUES (@CarritoId, @ProductoId, @Valor, @Cantidad)";
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@CarritoId", obj.CarritoId);
                    cmd.Parameters.AddWithValue("@ProductoId", obj.ProductoId);
                    cmd.Parameters.AddWithValue("@Valor", obj.Valor);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);

                    conn.Open();
                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }


        public static bool Actualizar(Models.DetalleCarrito obj)
        {
            int iResultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("UPDATE CarritoCompras SET cantidad = '{0}' WHERE detalleId = {1}", obj.Cantidad, obj.DetalleId);
                    cmd.Connection = conn;
                    conn.Open();

                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }

        public static bool Eliminar(Models.DetalleCarrito obj)
        {
            int iResultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("DELETE from DetalleCarrito where carritoId = {0} and productoId = {1}", obj.CarritoId, obj.ProductoId);
                    cmd.Connection = conn;
                    conn.Open();

                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }
    }


}
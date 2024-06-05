using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace waMusicPro.Data
{
    public class Carrito
    {
        public static Models.Carrito Obtener(int Clienteid) {
            int Cliente = Clienteid;
            Models.Carrito obj = null;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("select * from CarritoCompras where clienteId = {0} and estado = 1", Cliente);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            obj.CarritoId = int.Parse(sdr["CarritoId"].ToString());
                            obj.ClienteId = int.Parse(sdr["Nombre"].ToString());
                            obj.ValorTotal = int.Parse(sdr["Descripcion"].ToString());
                        }
                    }
                    conn.Close();
                }
                return obj;
            }
        }
        public static bool Insertar(Models.Carrito obj)
        {
            int iResultado = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO CarritoCompras (clienteId, valorTotal, estado) VALUES (@ClienteId, @ValorTotal, @Estado)";
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@Nombre", obj.ClienteId);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.ValorTotal);
                    cmd.Parameters.AddWithValue("@Precio", obj.Estado ? 1 : 0);

                    conn.Open();
                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }


        public static bool Actualizar(Models.Carrito obj)
        {
            int iResultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("UPDATE CarritoCompras SET Estado = '{0}' WHERE carritoId = {2}", obj.Estado ? 1 : 0, obj.CarritoId);
                    cmd.Connection = conn;
                    conn.Open();

                    iResultado = cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (iResultado > 0);
        }


        internal static IEnumerable<Models.Carrito> Obtener()
        {
            throw new NotImplementedException();
        }
    }

}
using AutomotrizApp.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.datos
{
    internal class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection conexion;

        public HelperDao()
        {
            conexion = new SqlConnection(Properties.Resources.CadenaConexion);

        }

        public static HelperDao ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        public DataTable Consultar(string nombreSP)
        {
            DataTable tabla = new DataTable();

            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            tabla.Load(comando.ExecuteReader());

            conexion.Close();
            return tabla;
        }

        public bool CrearDetallePedido(string maestroSP, string detalleSP, Pedido oPedido)
        {
            bool respuesta = false;
            SqlTransaction transaccion = null;

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand(maestroSP, conexion, transaccion);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@id_factura", null);
                //agregar params


                SqlParameter parametro = new SqlParameter("@id_pedido", SqlDbType.Int);
                parametro.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(parametro);
                cmdMaestro.ExecuteNonQuery();

                int idPedido = Convert.ToInt32(parametro.Value);

                foreach (Detalle item in oPedido.lstDetalle)
                {
                    SqlCommand cmdDetalle = new SqlCommand(detalleSP, conexion, transaccion);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_pedido", idPedido);
                    cmdDetalle.Parameters.AddWithValue("@id_factura", null);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.Id_Producto);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }

                transaccion.Commit();
                respuesta = true;
            }
            catch (SqlException)
            {
                if (transaccion != null)
                    transaccion.Rollback();
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return respuesta;

        }
    }
}

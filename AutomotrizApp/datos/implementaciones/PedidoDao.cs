using AutomotrizApp.datos.interfaces;
using AutomotrizApp.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.datos.implementaciones
{
    internal class PedidoDao : IPedidoDao
    {
        public List<Producto> GetProductos()
        {
            List<Producto> lista = new List<Producto>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_PRODUCTOS");

            foreach (DataRow fila in tabla.Rows)
            {
                Producto prod = new Producto();
                prod.Id_Producto = (int)fila["id_producto"];
                prod.Descripcion = fila["descripcion"].ToString();
                prod.Anio = (int)fila["anio"];
                prod.Precio_Vta = (double)fila["precio_vta"];
                lista.Add(prod);
            }
            return lista;
        }

        public bool Create(Pedido oPedido)
        {
            return HelperDao.ObtenerInstancia().CrearDetallePedido("SP_INSERTAR_PEDIDO", "SP_INSERTAR_DETALLE", oPedido);
        }
    }
}

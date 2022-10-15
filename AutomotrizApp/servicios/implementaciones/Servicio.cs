using AutomotrizApp.datos.implementaciones;
using AutomotrizApp.datos.interfaces;
using AutomotrizApp.dominio;
using AutomotrizApp.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.servicios.implementaciones
{
    internal class Servicio : IServicio
    {
        private IPedidoDao oDao;

        public Servicio()
        {
            oDao = new PedidoDao();
        }

        public List<Producto> ObtenerProductos()
        {
            return oDao.GetProductos();
        }

        public bool CrearPedido(Pedido oPedido)
        {
            return oDao.Create(oPedido);
        }


    }
}

using AutomotrizApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.datos.interfaces
{
    interface IPedidoDao
    {
        List<Producto> GetProductos();

        bool Create(Pedido oPedido);
    }
}

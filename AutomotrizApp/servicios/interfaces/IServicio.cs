using AutomotrizApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.servicios.interfaces
{
    interface IServicio
    {
        List<Producto> ObtenerProductos();

        bool CrearPedido(Pedido oPedido);

    }
}

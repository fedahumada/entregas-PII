using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.dominio
{
    internal class Detalle
    {
        public Producto Producto { get; set; }
        public double Cantidad { get; set; }

        public Detalle(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
        public double CalcularSubTotal()
        {
            return Producto.Precio_Vta * Cantidad;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.dominio
{
    internal class Producto
    {

        public int Id_Producto { get; set; }
        public string Descripcion { get; set; }
        public int Anio { get; set; }

        //public bool Stock { get; set; }
        public double Precio_Vta { get; set; }
        public int Id_marca { get; set; }
        public int Id_Tipo_Producto { get; set; }


        public Producto(int id_producto,string descripcion,int anio/*,bool stock*/,double precio_vta,int id_marca,int id_tipo_producto)
        {
            id_producto = Id_Producto;
            descripcion = Descripcion;
            anio = Anio;
            //stock = Stock;
            precio_vta = Precio_Vta;
            id_marca = Id_marca;
            id_tipo_producto = Id_Tipo_Producto;
            
        }

        public Producto()
        {
        }
    }
}

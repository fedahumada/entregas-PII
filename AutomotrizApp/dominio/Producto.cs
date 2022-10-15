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

    }
}

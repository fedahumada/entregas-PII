using AutomotrizApp.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizApp.servicios
{
    abstract class FabricaServicio
    {
        public abstract IServicio CrearServicio();
    }
}

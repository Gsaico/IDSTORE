using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Acceso
    {
        public String dni { get; set; }
        public DateTime fechaacceso { get; set; }
        public DateTime fechadesde { get; set; }
        public DateTime fechahasta { get; set; }
        public String observaciones { get; set; }
        public String estado { get; set; }
        public String idalmacen { get; set; }
      

        public CE_Acceso()
        {

        }

        public CE_Acceso(
         String dni,
         DateTime fechaacceso,
         DateTime fechadesde,
         DateTime fechahasta,
         String observaciones,
         String estado,
         String idalmacen)
        {
            this.dni = dni;
            this.fechaacceso = fechaacceso;
            this.fechadesde = fechadesde;
            this.fechahasta = fechahasta;
            this.observaciones = observaciones;
            this.estado = estado;
            this.idalmacen = idalmacen;
           
        }
    }
}

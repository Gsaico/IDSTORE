using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Area
    {
        public String nombrearea { get; set; }
        public int idarea { get; set; }

        public CE_Area()
        {

        }

        public CE_Area(
         String nombrearea,
            int idarea
            )
        {
            this.nombrearea = nombrearea;
            this.idarea = idarea;



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Registro
    {
        public String idregistro { get; set; }
        public String dni { get; set; }
        public DateTime timeentradasalida { get; set; }
        public String idestado_es { get; set; }
      
      

        public CE_Registro()
        {

        }

        public CE_Registro(
         String idregistro,
         String dni,
         DateTime timeentradasalida,
         String idestado_es
        )
        {
            this.idregistro = idregistro;
            this.dni = dni;
            this.timeentradasalida = timeentradasalida;
            this.idestado_es = idestado_es;
           
           
        }
    }
}

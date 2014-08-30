using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Servidor
    {
         public DateTime datetimeservidor { get; set; }
     
        
        public CE_Servidor()
        {

        }


        public CE_Servidor(DateTime Datetimeservidor)
        {
            this.datetimeservidor = Datetimeservidor;
          
        }
    }
}

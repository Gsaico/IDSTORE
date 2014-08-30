using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Tanque
    { 
        public String idtanque { get; set; }
        public Double volumenactual { get; set; }
        public Double volumenmaximo { get; set; }
    
      

        public CE_Tanque()
        {

        }

        public CE_Tanque(
         String idtanque,
         Double volumenactual,
         Double volumenmaximo)
      
        {
            this.idtanque = idtanque;
            this.volumenactual = volumenactual;
            this.volumenmaximo = volumenmaximo;
           
           
        }
    }
}

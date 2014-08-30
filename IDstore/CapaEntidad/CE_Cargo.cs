using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Cargo
    {
        public String nombrecargo { get; set; }
        public int idcargo { get; set; }

        public CE_Cargo()
        {

        }

        public CE_Cargo(
         String nombrecargo,
            int idcargo
            )
        {
            this.nombrecargo = nombrecargo;
            this.idcargo = idcargo;



        }
    }
}

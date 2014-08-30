using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Abastecimiento
    {
        public String codigo_abastecimiento { get; set; }
        public String dni { get; set; }
        public String idtanque { get; set; }
        public Double volumen_autorizado { get; set; }
        public String idplacavehiculo { get; set; }
        public String estado { get; set; }

        public CE_Abastecimiento()
        {

        }

        public CE_Abastecimiento(

         String codigo_abastecimiento,
            String dni,
         String idtanque,
      Double volumen_autorizado,
         String idplacavehiculo,
            String estado)
        {
           
            this.codigo_abastecimiento = codigo_abastecimiento;
            this.dni = dni;
            this.idtanque = idtanque;
            this.volumen_autorizado = volumen_autorizado;
            this.idplacavehiculo = idplacavehiculo;
            this.estado = estado;

        }
    }
}

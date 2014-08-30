using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias
using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
   public  class CN_Abastecimiento
    {
        public void NuevoAbastecimiento(CE_Abastecimiento objce_abastecimiento)
        {
            CD_Abastecimiento objcd_abastecimiento = new CD_Abastecimiento();

            objcd_abastecimiento.NuevoAbastecimiento(objce_abastecimiento);

        }
        public CE_Abastecimiento ListarAbastecimiento(CE_Abastecimiento objce_abastecimiento)
        {
            CD_Abastecimiento objcd_abastecimiento = new CD_Abastecimiento();
            CE_Abastecimiento objce_abastecimientotemp = new CE_Abastecimiento();

            objce_abastecimientotemp = objcd_abastecimiento.ListarAbastecimiento(objce_abastecimiento);

            return objce_abastecimientotemp;
        }
        public CE_Abastecimiento VolumenAutorizado(CE_Abastecimiento objce_abastecimiento)
        {
            CD_Abastecimiento objcd_abastecimiento = new CD_Abastecimiento();
            CE_Abastecimiento objce_abastecimientotemp = new CE_Abastecimiento();

            objce_abastecimientotemp = objcd_abastecimiento.VolumenAutorizado(objce_abastecimiento);

            return objce_abastecimientotemp;
        }
    }
}

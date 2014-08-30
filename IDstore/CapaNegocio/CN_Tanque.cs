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
    public class CN_Tanque
    {
        public void NuevoTanque(CE_Tanque objce_tanque)
        {
            CD_Tanque objcd_tanque = new CD_Tanque();

            objcd_tanque.NuevoTanque(objce_tanque);

        }
        public CE_Tanque BuscarTanqueXID(CE_Tanque objce_tanque)
        {
            CD_Tanque objcd_tanque = new CD_Tanque();
            CE_Tanque objce_tanquetemp = new CE_Tanque();

            objce_tanquetemp = objcd_tanque.BuscarTanqueXID(objce_tanque);

            return objce_tanquetemp;
        }
    }
}

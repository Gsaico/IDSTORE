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
    public class CN_Acceso
    {
        public void NuevoAcceso(CE_Acceso objce_acceso)
        {
            CD_Acceso objcd_acceso = new CD_Acceso();

            objcd_acceso.NuevoAcceso(objce_acceso);

        }

        public bool VerificarAutorizaciondeAcceso(CE_Acceso objce_acceso)
        {

            bool estado;

            CD_Acceso objcd_acceso = new CD_Acceso();

           return  estado = objcd_acceso.VerificarAutorizaciondeAcceso(objce_acceso);
          

        }

    }
}

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
   public  class CN_Servidor
    {
        public CE_Servidor FechayHoradelServidor()
        {
            CD_Servidor objcd_servidor = new CD_Servidor();
            CE_Servidor objce_servidortemp = new CE_Servidor();

            objce_servidortemp = objcd_servidor.FechayHoradelServidor();

            return objce_servidortemp;
        }
    }
}

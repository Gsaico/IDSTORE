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
    public class CN_Colaborador
    {
       
        public void NuevoColaboradorOracle(CE_Colaborador objce_Colaborador)
        {
            CD_Colaborador objcd_colaborador = new CD_Colaborador();

            objcd_colaborador.NuevoColaboradorOracle (objce_Colaborador);

        }
        public CE_Colaborador BuscarColaboradorXdni(CE_Colaborador objce_colaborador)
        {
            CD_Colaborador objcd_colaborador = new CD_Colaborador();
            CE_Colaborador objce_colaboradortemp = new CE_Colaborador();

            objce_colaboradortemp = objcd_colaborador.BuscarColaboradorXdni(objce_colaborador);

            return objce_colaboradortemp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias
using CapaEntidad;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class CN_TanqueDetalleMov
    {
        public void NuevoTanqueDetalleMov(CE_TanqueDetalleMov objce_tanquedetallemov)
        {
            CD_TanqueDetalleMov objcd_tanquedetallemov = new CD_TanqueDetalleMov();

            objcd_tanquedetallemov.NuevoTanqueDetalleMov(objce_tanquedetallemov);

        }

        public CE_TanqueDetalleMov SumarVolumenRetirado(CE_TanqueDetalleMov objce_tanquedetallemov)
        {
            CD_TanqueDetalleMov objcd_tanquedetallemov = new CD_TanqueDetalleMov();
            CE_TanqueDetalleMov objce_tanquedetallemovtemp = new CE_TanqueDetalleMov();

            objce_tanquedetallemovtemp = objcd_tanquedetallemov.SumarVolumenRetirado(objce_tanquedetallemov);

            return objce_tanquedetallemovtemp;
        }
        public DataTable sp_Busqueda_Captura_X_Nro_Tanque(string Nro_Tanque)
        {
            CD_TanqueDetalleMov objcd_tanquedetallemov = new CD_TanqueDetalleMov();

            return objcd_tanquedetallemov.sp_Busqueda_Captura_X_Nro_Tanque(Nro_Tanque);

        }
        public DataTable sp_Busqueda_Captura_X_Codigo_Abastecimiento(string codigo_abastecimiento)
        {
            CD_TanqueDetalleMov objcd_tanquedetallemov = new CD_TanqueDetalleMov();

            return objcd_tanquedetallemov.sp_Busqueda_Captura_X_Codigo_Abastecimiento(codigo_abastecimiento);

        }
        public DataTable sp_Busqueda_Captura_X_NombresyApellidos(string nombres, string apellidos)
        {
            CD_TanqueDetalleMov objcd_tanquedetallemov = new CD_TanqueDetalleMov();

            return objcd_tanquedetallemov.sp_Busqueda_Captura_X_NombresyApellidos(nombres, apellidos);

        }
        public DataTable sp_Busqueda_Captura_X_DNI(string dni)
        {
            CD_TanqueDetalleMov objcd_tanquedetallemov = new CD_TanqueDetalleMov();

            return objcd_tanquedetallemov.sp_Busqueda_Captura_X_DNI(dni);

        }

    }
}

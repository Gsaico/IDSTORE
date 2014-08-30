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
    public class CN_Registro
    {
        public void NuevoRegistroES(CE_Registro objce_registro)
        {
            CD_Registro objcd_registro = new CD_Registro();

            objcd_registro.NuevoRegistroES(objce_registro);

        }

        public bool UltimoRegistrodeIngresoSalida(string dni)
        {

            bool estado;

            CD_Registro objcd_registro = new CD_Registro();

            estado = objcd_registro.UltimoRegistrodeIngresoSalida(dni);
            return estado;

        }
        public CE_Registro UltimoRegistroXYeardni(CE_Registro objce_registro)
        {
            CD_Registro objcd_registro = new CD_Registro();
            CE_Registro objce_registrotemp = new CE_Registro();

            objce_registrotemp = objcd_registro.UltimoRegistroXYeardni(objce_registro);

            return objce_registrotemp;
        }
    }
}

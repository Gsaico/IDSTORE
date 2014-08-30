using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias para usar datatable y capa datos
using System.Data;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Cargo
    {
        public DataTable Listar_Cargos()
        {
            CD_Cargo objcd_Cargo = new CD_Cargo();

            return objcd_Cargo.ListarCargos();

        }
        public int  NuevoCargo(CE_Cargo objce_cargo)
        {
            int filasafectadas = 0;
            CD_Cargo objcd_cargo = new CD_Cargo();

            filasafectadas=objcd_cargo.NuevoCargo(objce_cargo);
            return filasafectadas;

        }

        public bool VerificarExisteCargo(CE_Cargo objce_cargo)
        {


            CD_Cargo objcd_cargo = new CD_Cargo();

            return objcd_cargo.VerificarExisteCargo(objce_cargo);


        }
    }
}

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
    public class CN_Area
    {
        public DataTable Listar_Areas()
        {
            CD_Area objcd_Area = new CD_Area();

            return objcd_Area.ListarAreas();

        }
        public  int NuevaArea(CE_Area objce_area)
        {
            int filasafectadas = 0;
            CD_Area objcd_area = new CD_Area();

            filasafectadas = objcd_area.NuevaArea(objce_area);

            return filasafectadas; 

        }

        public bool VerificarExisteArea(CE_Area objce_area)
        {

          
            CD_Area objcd_area = new CD_Area();

            return  objcd_area.VerificarExisteArea(objce_area);
           

        }
    }
}

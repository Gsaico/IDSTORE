using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencia para agregar utilizar el objeto image
using System.Drawing;
using System.Drawing.Imaging;
namespace CapaEntidad
{
    public class CE_TanqueDetalleMov
    {
        public String idtanque { get; set; }
        public String idregistro { get; set; }
        public String codigo_abastecimiento { get; set; }
        public Double volumen_retirado { get; set; }
        public String snapshotpicture { get; set; }
        public String snapshotvideo { get; set; }
        public String idtipooperacion { get; set; }

        public Double totalretirado { get; set; }


        public CE_TanqueDetalleMov()
        {

        }

        public CE_TanqueDetalleMov(

         String idtanque,
         String idregistro,
         String codigo_abastecimiento,
         Double volumen_retirado,
         String snapshotpicture,
         String snapshotvideo,
         String idtipooperacion,
              Double totalretirado
            )
        {

            this.idtanque = idtanque;
            this.idregistro = idregistro;
            this.codigo_abastecimiento = codigo_abastecimiento;
            this.volumen_retirado = volumen_retirado;
            this.snapshotpicture = snapshotpicture;
            this.snapshotvideo = snapshotvideo;
            this.idtipooperacion = idtipooperacion;
            this.totalretirado = totalretirado;
        }
    }
}

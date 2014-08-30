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
   public class CE_Colaborador
    {
       
        public String dni { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public DateTime fechanac { get; set; }
        public String email { get; set; }
        public String celular { get; set; }
        public DateTime fechacese { get; set; }
        public String idarea { get; set; }
        public String idcargo { get; set; }
        public Image foto { get; set; }
        public String estado { get; set; }


        public CE_Colaborador()
        {

        }

        public CE_Colaborador(
         String dni,
         String Nombres,
         String Apellidos,
         DateTime FechaNacimiento,
         String Email,
         String Celular,
         DateTime FechaCese,
         String Idarea,
         String Idcargo,
         Image Foto,
         String Estado)
        {
            this.dni = dni;
            this.nombres = Nombres;
            this.apellidos = Apellidos;
            this.fechanac = FechaNacimiento;
            this.email = Email;
            this.celular = Celular;
            this.fechacese = FechaCese;
            this.idarea = Idarea;
            this.idcargo = Idcargo;
            this.foto = Foto;
            this.estado = Estado;



        }
    }
}

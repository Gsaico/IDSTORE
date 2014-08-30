using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//referencias agregadas
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace CapaDatos
{
    class Imagenes
    {
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
    }
}

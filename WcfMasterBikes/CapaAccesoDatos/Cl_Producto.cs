using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WcfMasterBikes.CapaAccesoDatos
{
    public class Cl_Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string modelo { get; set; }
        public string descripcion { get; set; }
        public string rutaFoto { get; set; }
        public int precio { get; set; }
        public int descuento { get; set; }
        public int stock { get; set; }
        public int cantidad { get; set; }

        public byte[] imagen { get; set; }

        public int aro { get; set; }

        public int idProveedor { get; set; }

        public string proveedor { get; set; }

        public Cl_Producto()
        {

        }

        public byte[] ImgToByteArray(string ruta)
        {
            Image _imagen = Image.FromFile(HttpContext.Current.Server.MapPath(ruta));
            MemoryStream ms = new MemoryStream();
            _imagen.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}

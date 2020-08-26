using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using WcfMasterBikes.CapaAccesoDatos;
using WcfMasterBikes.CapaLogicaNegocios;

namespace WcfMasterBikes
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IServicio
    {
        public byte[] ImgToByteArray(string ruta)
        {
            Image _imagen = Image.FromFile(HttpContext.Current.Server.MapPath(ruta));
            MemoryStream ms = new MemoryStream();
            _imagen.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public List<Cl_Producto> obtenerProdProv()
        {
            DaoProveedor daoProveedor = new DaoProveedor();
            List<Cl_Producto> listaProd = daoProveedor.obtenerProductosProv();
            return listaProd;
        }

        public List<Cl_Producto> obtenerProductos()
        {
            DaoProducto daoProducto = new DaoProducto();
            List<Cl_Producto> listaProd = daoProducto.listarProductos();
            return listaProd;
        }

        public List<Cl_Municipalidad> obtenerMunicipalidades()
        {
            DaoMunicipalidad daoMunicipalidad = new DaoMunicipalidad();
            List<Cl_Municipalidad> listaMuni = daoMunicipalidad.listarMunicipalidades();
            return listaMuni;
        }
        

        public int obtenerConvenio(string municipalidad, string rut)
        {
            DaoMunicipalidad daoMunicipalidad = new DaoMunicipalidad();
            int convenio = daoMunicipalidad.obtenerConvenio(municipalidad, rut);
            return convenio;
        }

        public bool guardarImagen(byte[] imagen,string nombreArchivo)
        {
            string ruta = nombreArchivo;//+".jpg";
            byte[] imagenByte = imagen;
            Image image = Image.FromStream(new MemoryStream(imagenByte));
            image.Save(HttpContext.Current.Server.MapPath(ruta), ImageFormat.Jpeg);
            return true;
        }

        public int obtenerStock(int idProducto)
        {
            DaoProducto daoProducto = new DaoProducto();
            return daoProducto.obtenerStock(idProducto);
        }

        /*public Cl_Usuario ObtenerUsuario(int id, string user, string pass)
        {
            Cl_Operaciones op = new Cl_Operaciones();
            string sql = "SELECT * FROM USUARIO WHERE IDUSUARIO=" + id;
            OracleDataReader dr = op.sqlOperacion(sql);
            try
            {
                int idUser = Convert.ToInt32(dr[0]);
                string usuario = Convert.ToString(dr[1]);
                string contra = Convert.ToString(dr[2]);
                return new Cl_Usuario { idUsuario = idUser, user = usuario, pass = contra };
            }
            catch
            {
                return new Cl_Usuario
                {
                    idUsuario = 0,
                    user = "No existe",
                    pass = ""
                };
            }
            finally
            {
                op.cerrarConexion();
            }
    }*/
    }
}

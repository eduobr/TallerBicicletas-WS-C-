using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WcfMasterBikes.CapaAccesoDatos;
using WcfMasterBikes.CapaConexion;

namespace WcfMasterBikes.CapaLogicaNegocios
{
    public class DaoProducto
    {
        private Cl_Operaciones operaciones;

        public DaoProducto()
        {
            operaciones = new Cl_Operaciones();
        }

        public List<Cl_Producto> listarProductos()
        {
            List<Cl_Producto> listaProd;
            OracleDataReader dr;
            try
            {
                listaProd = new List<Cl_Producto>();
                object[] parametro = new object[1];
                parametro[0] = "V_PROD";
                //string parametro = "V_PROD";
                operaciones.abrirConexion();
                OracleCommand cmd = operaciones.execSP("PKG_PRODUCTOS.OBTENER_PRODUCTOS", parametro);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Cl_Producto producto = new Cl_Producto();
                        producto.idProducto = Convert.ToInt32(dr["IDPRODUCTO"]);
                        producto.nombre = dr["NOMBRE"].ToString();
                        producto.modelo = dr["MODELO"].ToString();
                        producto.descripcion = dr["DESCRIPCION"].ToString();
                        producto.rutaFoto = dr["FOTO"].ToString();
                        producto.precio = Convert.ToInt32(dr["PRECIO"]);
                        producto.descuento = Convert.ToInt32(dr["DESCUENTO"]);
                        producto.stock = Convert.ToInt32(dr["STOCK"]);
                        producto.imagen = producto.ImgToByteArray(producto.rutaFoto);
                        //Si la base de datos lo envia como null lo cambia a 0
                        producto.aro = Convert.ToInt32(dr["ARO"]);
                        listaProd.Add(producto);
                    }
                }
                dr.Dispose();
                return listaProd;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                operaciones.cerrarConexion();
            }
        }

        public int obtenerStock(int idProducto)
        {
            try
            {
                object[] parametro = new object[2];
                parametro[0] = idProducto;
                parametro[1] = "P_OUT_STOCK";
                operaciones.abrirConexion();
                OracleCommand cmd = operaciones.execSP("PKG_PRODUCTOS.OBTENER_STOCK",parametro);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["P_OUT_STOCK"].Value);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                operaciones.cerrarConexion();
            }
        }

    }
}

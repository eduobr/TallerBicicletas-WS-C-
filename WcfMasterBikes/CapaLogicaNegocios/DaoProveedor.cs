using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfMasterBikes.CapaAccesoDatos;
using WcfMasterBikes.CapaConexion;

namespace WcfMasterBikes.CapaLogicaNegocios
{
    public class DaoProveedor
    {
        private Cl_Operaciones operaciones;
        public DaoProveedor()
        {
            operaciones = new Cl_Operaciones();
        }

        public List<Cl_Producto> obtenerProductosProv()
        {
            List<Cl_Producto> listaProd;
            object[] parametro = new object[1];
            parametro[0] = "V_PROD_PROV";
            try
            {
                listaProd = new List<Cl_Producto>();
                operaciones.abrirConexion();
                OracleCommand cmd = operaciones.execSP("PKG_PROVEEDOR.OBTENER_PRODUCTOS_PROV", parametro);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Cl_Producto producto = new Cl_Producto();
                        producto.idProducto = Convert.ToInt32(dr[0]);
                        producto.nombre = dr[1].ToString();
                        producto.modelo = dr[2].ToString();
                        producto.descripcion = dr[3].ToString();
                        producto.rutaFoto = dr[4].ToString();
                        producto.imagen = producto.ImgToByteArray(producto.rutaFoto);
                        producto.precio = Convert.ToInt32(dr[5]);
                        producto.descuento = Convert.ToInt32(dr[6]);
                        producto.stock = Convert.ToInt32(dr[7]);
                        producto.aro = Convert.ToInt32(dr[8]);
                        producto.proveedor = dr[9].ToString();
                        producto.idProveedor = Convert.ToInt32(dr[10]);
                        listaProd.Add(producto);

                    }
                }
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
    }
}
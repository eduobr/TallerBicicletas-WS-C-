using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfMasterBikes.CapaConexion
{
    public class Cl_Conexion
    {
        private OracleConnection conn;
        private string cadena = "Data Source=XE;USER ID=MASTERBIKES; PASSWORD=MASTER123";

        public Cl_Conexion()
        {
            try
            {
                if (conn==null)
                {
                    conn = new OracleConnection(cadena);
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public OracleConnection obtenerConexion()
        {
            return conn;
        }
    }
}

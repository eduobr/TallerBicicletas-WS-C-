using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfMasterBikes.CapaAccesoDatos;
using WcfMasterBikes.CapaConexion;

namespace WcfMasterBikes.CapaLogicaNegocios
{
    public class DaoMunicipalidad
    {
        Cl_Operaciones operaciones;
        public DaoMunicipalidad()
        {
            operaciones = new Cl_Operaciones();
        }

        public List<Cl_Municipalidad> listarMunicipalidades()
        {
            List<Cl_Municipalidad> listaMunicipalidades;
            object[] parametro = new object[1];
            operaciones.abrirConexion();
            parametro[0] = "V_MUNICIPALIDAD";
            OracleCommand cmd = operaciones.execSP("PKG_MUNICIPALIDAD.OBTENER_MUNICIPALIDADES", parametro);
            OracleDataReader dr = cmd.ExecuteReader();
            listaMunicipalidades = new List<Cl_Municipalidad>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cl_Municipalidad muni = new Cl_Municipalidad();
                    muni.idMunicipalidad = Convert.ToInt32(dr[0]);
                    muni.municipalidad = dr[1].ToString();
                    listaMunicipalidades.Add(muni);
                }
            }
            return listaMunicipalidades;
        }

        public int obtenerConvenio(string municipalidad,string rut)
        {
            object[] parametros = new object[3];
            operaciones.abrirConexion();
            try
            {
                parametros[0] = municipalidad;
                parametros[1] = rut;
                parametros[2] = "P_OUT_CONVENIO";
                OracleCommand cmd = operaciones.execSP("PKG_MUNICIPALIDAD.OBTENER_CONVENIO", parametros);
                cmd.ExecuteNonQuery();
                int convenio = Convert.ToInt32(cmd.Parameters["P_OUT_CONVENIO"].Value);
                return convenio;
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
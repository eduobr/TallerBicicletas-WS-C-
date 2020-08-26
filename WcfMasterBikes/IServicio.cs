using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfMasterBikes.CapaAccesoDatos;

namespace WcfMasterBikes
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicio
    {

        [OperationContract]
        byte[] ImgToByteArray(string ruta);


        [OperationContract]
        List<Cl_Producto> obtenerProdProv();

        [OperationContract]
        List<Cl_Producto> obtenerProductos();

        [OperationContract]
        List<Cl_Municipalidad> obtenerMunicipalidades();

        [OperationContract]
        int obtenerConvenio(string municipalidad, string rut);

        [OperationContract]
        bool guardarImagen(byte[] imagen, string nombreArchivo);

        [OperationContract]
        int obtenerStock(int idProducto);

    }
}

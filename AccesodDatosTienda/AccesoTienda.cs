using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectarBd;

namespace AccesodDatosTienda
{
    public class AccesoTienda
    {
        Base b = new Base("Localhost","root", "", "tienda");

        public void Guardar(dynamic Entidad)
        {
            b.comando(String.Format("CALL insertarProducto({0},'{1}','{2}',{3})", Entidad.Idproducto,
                Entidad.Nombre, Entidad.Descripcion, Entidad.Precio));
        }
        public DataSet Mostrar(string filtro)
        {
            return b.Obtener(String.Format("CALL showproducto('%{0}%')", filtro), "producto");
        }
        public void Eliminar(dynamic Entidad)
        {
            b.comando(String.Format("CALL deleteproducto({0})", Entidad.Idproducto));
        }
    }
}

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
        Base b = new Base("Localhost", "Root", "", "Tienda");

        public void Guardar(dynamic Entidad)
        {
            b.comando(String.Format("call insertarProducto({0},'{1}','{2}',{3})", Entidad.Idproducto,
                Entidad.Nombre, Entidad.Descripcion, Entidad.Precio));
        }
        public DataSet Mostrar(dynamic Entidad)
        {
            return b.Obtener(String.Format("call showproducto('{0}')", Entidad.Nombre), "Producto");
        }
        public void Eliminar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteproducto({0})", Entidad.Idproducto));
        }
    }
}

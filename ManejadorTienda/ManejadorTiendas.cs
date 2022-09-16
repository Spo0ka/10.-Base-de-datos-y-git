using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesTienda;
using AccesodDatosTienda;
using System.Windows.Forms;
using System.Drawing;
using crud;

namespace ManejadorTienda
{
    public class ManejadorTiendas
    {
        AccesoTienda At = new AccesoTienda();
        Grafico g = new Grafico();
        public void GuardarProducto(dynamic Entidad)
        {
            At.Guardar(Entidad);
        }

        public void Mostrar(DataGridView Tabla, string Buscar)
        {
            Tabla.Columns.Clear();
            Tabla.RowTemplate.Height = 30;
            Tabla.DataSource = At.Mostrar(Buscar).Tables["producto"];
            Tabla.Columns.Insert(4,g.Boton("Editar",Color.Green));
            Tabla.Columns.Insert(5, g.Boton("Eliminar", Color.Red));
            Tabla.Columns[0].Visible = false;
        }

        public void eliminar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show( "Esta seguro de borrar?", "Atencion!", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                At.Eliminar(Entidad);
            }
        }
    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesTienda;
using AccesodDatosTienda;
using System.Windows.Forms;
using System.Drawing;

namespace ManejadorTienda
{
    public class ManejadorTienda
    {
        AccesoTienda At = new AccesoTienda();
        public void GuardarProducto(dynamic Entidad)
        {
            At.Guardar(Entidad);
        }

        public void Mostrar(DataGridView Tabla, string Buscar)
        {
            Tabla.Columns.Clear();
            Tabla.RowTemplate.Height = 30;
            Tabla.DataSource = At.Mostrar(Buscar).Tables["Producto"];
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.Text = "Eliminar"; bc.DefaultCellStyle.BackColor = Color.Red;
            DataGridViewButtonColumn be = new DataGridViewButtonColumn();
            bc.Text = "Editar"; be.DefaultCellStyle.BackColor = Color.Green;
            Tabla.Columns.Insert(4, be); Tabla.Columns.Insert(5, bc);
            Tabla.Columns[0].Visible = false;
        }

        public void eliminar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show("Atencion!", "Esta seguro de borrar?", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                At.Eliminar(Entidad);
            }
        }
    }

   
}

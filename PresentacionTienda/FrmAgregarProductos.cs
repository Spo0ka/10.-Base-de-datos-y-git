using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadorTienda;
using EntidadesTienda;

namespace PresentacionTienda
{
    public partial class FrmAgregarProductos : Form
    {
        ManejadorTiendas Mt;
        public FrmAgregarProductos()
        {
            InitializeComponent();
            Mt = new ManejadorTiendas();
            if (FrmProducto.tienda.Idproducto > 0)
            {
                txtNombre.Text = FrmProducto.tienda.Nombre;
                txtDescripcion.Text = FrmProducto.tienda.Descripcion;
                txtPrecio.Text = FrmProducto.tienda.Precio.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Tienda t = new Tienda(0,"","",0);
            t.Idproducto = FrmProducto.tienda.Idproducto;
            t.Descripcion = txtDescripcion.Text;
            t.Precio = double.Parse(txtPrecio.Text);
            t.Nombre = txtNombre.Text;
            
            Mt.GuardarProducto(t);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class FrmProducto : Form
    {
        public static Tienda tienda = new Tienda(0,"","",0);
        ManejadorTiendas Mt;
        int fila = 0, columna =0;
        public FrmProducto()
        {
            InitializeComponent();
            Mt = new ManejadorTiendas();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DtgAgregar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        private void DtgAgregar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tienda.Idproducto =int.Parse(DtgAgregar.Rows[fila].Cells[0].Value.ToString());
            tienda.Nombre = DtgAgregar.Rows[fila].Cells[1].Value.ToString();
            tienda.Descripcion = DtgAgregar.Rows[fila].Cells[2].Value.ToString();
            tienda.Precio = double.Parse(DtgAgregar.Rows[fila].Cells[3].Value.ToString());
            switch (columna)
            {
                
                case 4: {
                        FrmAgregarProductos frmAgregarProductos = new FrmAgregarProductos();
                            frmAgregarProductos.ShowDialog();
                            } break;
                case 5: { Mt.eliminar(tienda); } break;
                default:
                    break;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            tienda.Idproducto = -1;
            FrmAgregarProductos frm = new FrmAgregarProductos();
            frm.ShowDialog();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualiar();
        }

        void Actualiar()
        {
            Mt.Mostrar(DtgAgregar,TxtBuscar.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmVistaArticulo_Ingreso : Form
    {
        public FrmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }
        private void FrmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NArticulo.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = NArticulo.BuscarNombre(txtBuscar.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngreso form = FrmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            form.setArticulo(par1, par2);
            Hide();
        }
    }
}

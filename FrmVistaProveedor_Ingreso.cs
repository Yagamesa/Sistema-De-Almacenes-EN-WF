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
    public partial class FrmVistaProveedor_Ingreso : Form
    {
        public FrmVistaProveedor_Ingreso()
        {
            InitializeComponent();
        }
        private void FrmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NProveedor.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        }
        //Metodo BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            dataListado.DataSource = NProveedor.BuscarRazon_Social(txtBuscar.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        }
        //Metodo BuscarNumero_Documento
        private void BuscarNumero_Documento()
        {
            dataListado.DataSource = NProveedor.BuscarNum_Documento(txtBuscar.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNumero_Documento();
            }
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngreso form = FrmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);
            form.setProveedor(par1, par2);
            Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp.Reportes
{
    public partial class frmReporteTrabajadores : Form
    {
        public frmReporteTrabajadores()
        {
            InitializeComponent();
        }

        private void frmReporteTrabajadores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.sp_reporte_trabajadores' Puede moverla o quitarla según sea necesario.
            this.sp_reporte_trabajadoresTableAdapter.Fill(this.dsPrincipal.sp_reporte_trabajadores);

            this.reportViewer1.RefreshReport();
        }
    }
}

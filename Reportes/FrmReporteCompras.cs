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
    public partial class FrmReporteCompras : Form
    {
        private string _Texto;
        private string _Texto2;

        public string Texto { get => _Texto; set => _Texto = value; }
        public string Texto2 { get => _Texto2; set => _Texto2 = value; }
        public FrmReporteCompras()
        {
            InitializeComponent();
        }

        

        private void FrmReporteCompras_Load(object sender, EventArgs e)
        {
            
            this.spbuscar_ingreso_fechaTableAdapter.Fill(this.dsPrincipal.spbuscar_ingreso_fecha, Texto, Texto2);
            this.reportViewer1.RefreshReport();
        }
    }
}

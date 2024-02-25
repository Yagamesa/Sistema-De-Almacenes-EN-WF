using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class frmProveedor : Form
    {
        private bool isNuevo = false;

        public frmProveedor()
        {
            InitializeComponent();
            HabilitarCampos(false);
            MostrarProveedores();
            this.txtIdProveedor.Visible = false;
        }
        
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                EliminarProveedor();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor a eliminar.", "Eliminar Proveedor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (chkEditar.Checked)
            {
                HabilitarCampos(true);
                isNuevo = false;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor a editar.", "Editar Proveedor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            LimpiarCampos();
            isNuevo = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (isNuevo)
                {
                    NProveedor.Insertar(txtRazonSocial.Text, cbSectorComercial.Text, cbTipoDocumento.Text,
                        txtNumDocumento.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtUrl.Text);
                }
                else
                {
                    NProveedor.Editar(Convert.ToInt32(txtIdProveedor.Text), txtRazonSocial.Text,
                        cbSectorComercial.Text, cbTipoDocumento.Text, txtNumDocumento.Text,
                        txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtUrl.Text);
                }

                LimpiarCampos();
                MostrarProveedores();
                HabilitarCampos(false);
            }
        }
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            // Tu lógica para el evento chkEliminar_CheckedChanged
        }
        private void chkEditar_CheckedChanged(object sender, EventArgs e)
        {
            // Tu lógica para el evento chkEliminar_CheckedChanged
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);
        }

        private void MostrarProveedores()
        {
            dataListado.DataSource = NProveedor.Mostrar();
        }

        private void BuscarProveedor()
        {
            dataListado.DataSource = NProveedor.BuscarRazon_Social(txtBuscar.Text);
        }

        private void EliminarProveedor()
        {
            if (MessageBox.Show("¿Está seguro de eliminar el/los proveedor(es) seleccionado(s)?",
                "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                    {
                        NProveedor.Eliminar(Convert.ToInt32(row.Cells["idproveedor"].Value));
                    }
                }

                MostrarProveedores();
                chkEliminar.Checked = false;
            }
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtRazonSocial.Enabled = habilitar;
            cbSectorComercial.Enabled = habilitar;
            cbTipoDocumento.Enabled = habilitar;
            txtNumDocumento.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtUrl.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void LimpiarCampos()
        {
            txtIdProveedor.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            cbSectorComercial.SelectedIndex = -1;
            cbTipoDocumento.SelectedIndex = -1;
            txtNumDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUrl.Text = string.Empty;
        }

        private bool ValidarDatos()
        {
            // Puedes agregar lógica de validación según tus requisitos
            return true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            Reportes.frmReporteProveedores frm = new Reportes.frmReporteProveedores();
            frm.Show();
        }
    }
}


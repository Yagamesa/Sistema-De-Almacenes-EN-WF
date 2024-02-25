using System;
using System.Linq;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace PedidosApp
{
    public partial class frmTrabajador : Form
    {
        private bool isNuevo = false;

        public frmTrabajador()
        {
            InitializeComponent();
            HabilitarCampos(false);
            MostrarTrabajadores();
            this.txtIdTrabajador.Visible = false;
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
            BuscarTrabajador();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el checkbox de eliminación está marcado
            if (chkEliminar.Checked)
            {
                // Puedes agregar lógica adicional aquí si es necesario
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un trabajador a eliminar.", "Eliminar Trabajador",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool haySeleccionados = dataListado.Rows.Cast<DataGridViewRow>().Any(row =>
                Convert.ToBoolean(row.Cells["Eliminar"].Value));

            if (haySeleccionados)
            {
                EliminarTrabajador();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos un trabajador a eliminar.", "Eliminar Trabajador",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EliminarTrabajador()
        {
            if (MessageBox.Show("¿Está seguro de eliminar el/los trabajador(es) seleccionado(s)?",
                "Eliminar Trabajador", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                    {
                        NTrabajador.Eliminar(Convert.ToInt32(row.Cells["idtrabajador"].Value));
                    }
                }

                MostrarTrabajadores();
                chkEliminar.Checked = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            isNuevo = false;
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
                    NTrabajador.Insertar(txtNombre.Text, txtApellidos.Text, cbGenero.Text,
                        dtpFechaNac.Value, txtNumDocumento.Text, txtDireccion.Text,
                        txtTelefono.Text, txtEmail.Text, cbAcceso.Text, txtUsuario.Text, txtContraseña.Text);
                }
                else
                {
                    NTrabajador.Editar(Convert.ToInt32(txtIdTrabajador.Text), txtNombre.Text,
                        txtApellidos.Text, cbGenero.Text, dtpFechaNac.Value, txtNumDocumento.Text,
                        txtDireccion.Text, txtTelefono.Text, txtEmail.Text, cbAcceso.Text,
                        txtUsuario.Text, txtContraseña.Text);
                }

                LimpiarCampos();
                MostrarTrabajadores();
                HabilitarCampos(false);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);
        }

        private void MostrarTrabajadores()
        {
            dataListado.DataSource = NTrabajador.Mostrar();
        }
        private void BuscarTrabajador()
        {
            try
            {
                DTrabajador trabajador = new DTrabajador();
                trabajador.TextoBuscar = txtBuscar.Text;
                dataListado.DataSource = NTrabajador.BuscarApellidos(trabajador);
            }
            catch (Exception ex)
            {
                // Muestra la información de la excepción en la consola
                Console.WriteLine("Error: " + ex.Message);

                // También puedes mostrar un cuadro de mensaje con la información de la excepción
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellidos.Enabled = habilitar;
            cbGenero.Enabled = habilitar;
            dtpFechaNac.Enabled = habilitar;
            txtNumDocumento.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            cbAcceso.Enabled = habilitar;
            txtUsuario.Enabled = habilitar;
            txtContraseña.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void LimpiarCampos()
        {
            txtIdTrabajador.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            cbGenero.SelectedIndex = -1;
            dtpFechaNac.Value = DateTime.Now;
            txtNumDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cbAcceso.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
        }

        private bool ValidarDatos()
        {
            // Puedes agregar lógica de validación según tus requisitos
            return true;
        }

        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la columna clicada es la columna "Eliminar"
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.frmReporteTrabajadores frm = new Reportes.frmReporteTrabajadores();
            frm.Show();
        }
    }

}

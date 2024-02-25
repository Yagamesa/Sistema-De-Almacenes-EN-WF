using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmIngreso : Form
    {
        public int Idtrabajador = 1;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        private static FrmIngreso _instancia;

        public static FrmIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmIngreso();
            }
            return _instancia;
        }
        public void setProveedor(string idproveedor, string nombre)
        {
            txtIdproveedor.Text = idproveedor;
            txtProveedor.Text = nombre;
        }
        public void setArticulo(string idarticulo, string nombre)
        {
            txtIdarticulo.Text = idarticulo;
            txtArticulo.Text = nombre;
        }
        public FrmIngreso()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtProveedor, "Seleccione el Proveedor con el botón");
            ttMensaje.SetToolTip(txtSerie, "Ingrese número de serie del comprobante");
            ttMensaje.SetToolTip(txtCorrelativo, "Ingrese el número del comprobante");
            ttMensaje.SetToolTip(txtStock, "Ingrese la cantidad de compra");
            ttMensaje.SetToolTip(txtArticulo, "Seleccione el Artículo de compra con el botón");
            txtIdproveedor.Visible = false;
            txtIdarticulo.Visible = false;
            txtProveedor.ReadOnly = true;
            txtArticulo.ReadOnly = true;
        }
        //Mostrar Mensaje de Confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            txtIdarticulo.Text = string.Empty;
            txtIdproveedor.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            txtSerie.Text = string.Empty;
            txtCorrelativo.Text = string.Empty;
            txtIgv.Text = "0.03";
            lblTotal_Pagado.Text = "0.0";
            crearTabla();
        }
        private void LimpiarDetalle()
        {
            txtIdarticulo.Text = string.Empty;
            txtArticulo.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtPrecio_Compra.Text = string.Empty;
            txtPrecio_Venta.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            txtSerie.ReadOnly = !valor;
            txtCorrelativo.ReadOnly = !valor;
            txtIgv.ReadOnly = !valor;
            dtFecha.Enabled = valor;
            cbTipo_Comprobante.Enabled = valor;
            txtStock.ReadOnly = !valor;
            txtPrecio_Compra.ReadOnly = !valor;
            txtPrecio_Venta.ReadOnly = !valor;
            dtFecha_Produccion.Enabled = valor;
            dtFecha_Vencimiento.Enabled = valor;
            btnBuscarArticulo.Enabled = valor;
            btnBuscarProveedor.Enabled = valor;
            btnAgregar.Enabled = valor;
            btnQuitar.Enabled = valor;
        }
        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columnas del dataListado
        private void OcultarColumnas()
        {
            if (dataListado.RowCount > 0)
            {
                dataListado.Columns[0].Visible = false;
                dataListado.Columns[1].Visible = false;
            }
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NIngreso.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
            tabControl1.SelectedIndex = 0;
        }
        //Metodo BuscarFechas
        private void BuscarFechas()
        {
            dataListado.DataSource = NIngreso.BuscarFechas(dtFecha1.Value.ToString("MM/dd/yyyy"),
                dtFecha2.Value.ToString("MM/dd/yyyy"));
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.RowCount);
        }
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NIngreso.MostrarDetalle(txtIdingreso.Text);
        }
        private void crearTabla()
        {
            dtDetalle = new DataTable("Detalle");
            dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar el DataGridView con el DataTable
            dataListadoDetalle.DataSource = dtDetalle;
        }
        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostrar();
            Habilitar(false);
            Botones();
            crearTabla();
        }
        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }
        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor_Ingreso vista = new FrmVistaProveedor_Ingreso();
            vista.ShowDialog();
        }
        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Ingreso vista = new FrmVistaArticulo_Ingreso();
            vista.ShowDialog();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFechas();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("ESTA SEGURO DE ANULAR LOS REGISTROS?", "Sistema de Pedidos", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo, Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));
                            if (Rpta.Equals("OK"))
                            {
                                MensajeOK("Se anuló correctamente el ingreso");
                            }
                            else
                            {
                                MensajeError(Rpta);
                            }
                        }
                    }
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dataListado.Columns[0].Visible = true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
            }
        }
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = 
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            Botones();
            Limpiar();
            Habilitar(true);
            txtProveedor.Focus();
            LimpiarDetalle();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            Botones();
            Limpiar();
            Habilitar(false); 
            LimpiarDetalle();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (txtIdproveedor.Text == string.Empty || txtSerie.Text == string.Empty ||
                    txtCorrelativo.Text == string.Empty || txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdproveedor, "Ingrese un valor");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    errorIcono.SetError(txtIgv, "Ingrese un valor");
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NIngreso.Insertar(Idtrabajador, Convert.ToInt32(txtIdproveedor.Text),
                            dtFecha.Value, cbTipo_Comprobante.Text, txtSerie.Text, txtCorrelativo.Text,
                            Convert.ToDecimal(txtIgv.Text), "EMITIDO", dtDetalle);
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (IsNuevo)
                        {
                            MensajeOK("Se insertó de forma correcta los registros");
                        }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                    IsNuevo = false;
                    Botones();
                    Limpiar();
                    LimpiarDetalle();
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdarticulo.Text == string.Empty || txtStock.Text == string.Empty ||
                    txtPrecio_Compra.Text == string.Empty || txtPrecio_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un valor");
                    errorIcono.SetError(txtStock, "Ingrese un valor");
                    errorIcono.SetError(txtPrecio_Compra, "Ingrese un valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(txtIdarticulo.Text))
                        {
                            registrar = false;
                            MensajeError("Ya se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(txtStock.Text) * Convert.ToDecimal(txtPrecio_Compra.Text);
                        totalPagado += subTotal;
                        lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar el detalle al datalistadoDetalle
                        DataRow row = dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(txtIdarticulo.Text);
                        row["articulo"] = txtArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(txtPrecio_Compra.Text);
                        row["precio_venta"] = Convert.ToDecimal(txtPrecio_Venta.Text);
                        row["stock_inicial"] = Convert.ToDecimal(txtStock.Text);
                        row["fecha_produccion"] = dtFecha_Produccion.Value;
                        row["fecha_vencimiento"] = dtFecha_Vencimiento.Value;
                        row["subtotal"] = subTotal;
                        dtDetalle.Rows.Add(row);
                        LimpiarDetalle();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = dtDetalle.Rows[indiceFila];
                //Disminuir el totalPagado
                totalPagado -= Convert.ToDecimal(row["subtotal"]);
                lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                //Remover la fila
                dtDetalle.Rows.Remove(row);
            }
            catch (Exception)
            {
                MensajeError("No hay fila para remover");
            }
        }
        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {
            txtIdingreso.Text = Convert.ToString(dataListado.CurrentRow.Cells["idingreso"].Value);
            txtProveedor.Text = Convert.ToString(dataListado.CurrentRow.Cells["proveedor"].Value);
            dtFecha.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha"].Value);
            cbTipo_Comprobante.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            txtSerie.Text = Convert.ToString(dataListado.CurrentRow.Cells["serie"].Value);
            txtCorrelativo.Text = Convert.ToString(dataListado.CurrentRow.Cells["correlativo"].Value);
            lblTotal_Pagado.Text = Convert.ToString(dataListado.CurrentRow.Cells["total"].Value);
            txtIgv.Text = Convert.ToString(dataListado.CurrentRow.Cells["impuesto"].Value);
            MostrarDetalle();
            tabControl1.SelectedIndex = 1;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            //Reportes.FrmStockArticulo frm = new Reportes.FrmStockArticulo();
            Reportes.FrmReporteCompras frm = new Reportes.FrmReporteCompras();
            frm.Texto = dtFecha1.Value.ToString("MM/dd/yyyy");
            frm.Texto2= dtFecha2.Value.ToString("MM/dd/yyyy");
            frm.ShowDialog();
        }
    }
}

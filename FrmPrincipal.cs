using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace PedidosApp
{
    public partial class FrmPrincipal : Form
    {
        // Declaramos campos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private string _RolUsuario;

        public string RolUsuario { get => _RolUsuario; set => _RolUsuario = value; }

        // Constructor
        public FrmPrincipal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            // Código para quitar la barra de título del formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            // Para reducir el parpadeo
            this.DoubleBuffered = true;
            // Para evitar perder la barra de Windows al maximizar codificamos
            // solo hasta el área de trabajo
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Estructura para almacenar colores
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(24, 161, 251);
            public static Color color8 = Color.FromArgb(24, 161, 251);
            public static Color color9 = Color.FromArgb(24, 161, 251);
        }

        // Métodos
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                // Boton
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // Borde izquierdo del botón
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // Icono del formulario hijo actual
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        // Creamos formulario hijo y mostramos el título en la barra de título
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                // Abrimos solo un formulario
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            // OpenChildForm(new Dashboard());
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            if (RolUsuario == "admin" || RolUsuario == "almacen")
            {
                ActivateButton(sender, RGBColors.color2);
                OpenChildForm(FrmArticulo.GetInstancia());
            }
            else
            {
                MostrarMensajeError("Usuario no válido");
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {

            if (RolUsuario == "admin" || RolUsuario == "almacen")
            {
                ActivateButton(sender, RGBColors.color3);
                OpenChildForm(new FrmCategoria());
            }
            else
            {
                MostrarMensajeError("Usuario no válido");
            }
           
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            // OpenChildForm(new FrmCliente());
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            if (RolUsuario == "admin" || RolUsuario == "cajero")
            {
                ActivateButton(sender, RGBColors.color5);
                OpenChildForm(FrmIngreso.GetInstancia());
            }
            else
            {
                MostrarMensajeError("Usuario no válido");
            }

            
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            // OpenChildForm(new FrmPresentacion());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (RolUsuario == "admin" || RolUsuario == "almacen")
            {
                ActivateButton(sender, RGBColors.color7);
                OpenChildForm(new frmProveedor());
            }
            else
            {
                MostrarMensajeError("Usuario no válido");
            }

           
        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {
            if (RolUsuario == "admin" || RolUsuario == "almacen")
            {
                ActivateButton(sender, RGBColors.color8);
                OpenChildForm(new frmTrabajador());
            }
            else
            {
                MostrarMensajeError("Usuario no válido");
            }
            
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color9);
            // OpenChildForm(FrmVenta.GetInstancia());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Inicio";
        }

        // Código para arrastrar el formulario e importar librería System.Runtime.InteropServices
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}


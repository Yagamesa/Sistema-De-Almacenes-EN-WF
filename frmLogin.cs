using System;
using System.Windows.Forms;
using CapaDatos;

namespace PedidosApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string nombreUsuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Crear instancia de DLogin
            DLogin login = new DLogin
            {
                NombreUsuario = nombreUsuario,
                Contraseña = contraseña
            };

            // Verificar el login
            string rol = login.VerificarLogin(login);  

            // Verificar el rol y redirigir según corresponda
            if (!string.IsNullOrEmpty(rol) && (rol == "admin" || rol == "almacen" || rol == "cajero"))
            {
                // Abrir el formulario principal
                AbrirFormularioPrincipal(rol);
            }
            else
            {
                // Usuario no válido
                string mensajeError = $"Credenciales incorrectas. Inténtelo de nuevo";
                MessageBox.Show(mensajeError);
            }
        }


        private void AbrirFormularioPrincipal(string rol)
        {
            // Crear instancia del formulario principal
            FrmPrincipal formularioPrincipal = new FrmPrincipal();

            // Pasar el rol al formulario principal
            formularioPrincipal.RolUsuario = rol;

            // Mostrar el formulario principal
            formularioPrincipal.Show();

            // Ocultar el formulario de login si es necesario
            this.Hide();
        }

    }
}


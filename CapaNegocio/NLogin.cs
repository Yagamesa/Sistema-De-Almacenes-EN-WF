using CapaDatos;

namespace CapaNegocio
{
    public class NLogin
    {
        // Método para verificar el login y obtener el rol
        public static string VerificarLogin(string nombreUsuario, string contraseña)
        {
            DLogin login = new DLogin();
            login.NombreUsuario = nombreUsuario;
            login.Contraseña = contraseña;

            return login.VerificarLogin(login);
        }
    }
}

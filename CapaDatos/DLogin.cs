using CapaDatos;
using System.Data.SqlClient;
using System.Data;
using System;

public class DLogin : DbConecction
{
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }
    public string Rol { get; private set; } // Cambiado a Nullable<string>

    public DLogin()
    {
    }

    public DLogin(string nombreUsuario, string contraseña)
    {
        NombreUsuario = nombreUsuario;
        Contraseña = contraseña;
    }

    public string VerificarLogin(DLogin Login)
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = "spVerificarLogin";
                    command.CommandType = CommandType.StoredProcedure;

                    // Corregir aquí - utilizar Login.NombreUsuario y Login.Contraseña
                    command.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = Login.NombreUsuario;
                    command.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50).Value = Login.Contraseña;

                    // Parámetro de salida
                    command.Parameters.Add("@Rol", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    // Obtener el valor del parámetro de salida
                    Rol = (command.Parameters["@Rol"].Value != DBNull.Value)
                        ? Convert.ToString(command.Parameters["@Rol"].Value)
                        : null;

                    //// Imprimir para depuración
                    //Console.WriteLine("Valor del rol obtenido: " + Rol);
                    //Console.WriteLine($"Nombre de Usuario: {Login.NombreUsuario}");
                    //Console.WriteLine($"Contraseña: {Login.Contraseña}");
                    //Console.WriteLine($"Rol obtenido: {Rol}");
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según tus necesidades
                    Console.WriteLine("Excepción: " + ex.Message);
                }
            }
        }

        return Rol;
    }

}





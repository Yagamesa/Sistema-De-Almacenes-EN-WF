﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador : DbConecction
    {
        //Variables
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Genero;
        private DateTime _Fecha_Nac;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;
        //Propiedades
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Genero { get => _Genero; set => _Genero = value; }
        public DateTime Fecha_Nac { get => _Fecha_Nac; set => _Fecha_Nac = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        //Contructores
        public DTrabajador()
        {
            
        }
        public DTrabajador(int idtrabajador, string nombre, string apellidos, string genero, 
            DateTime fecha_Nac, string num_Documento, string direccion, string telefono, 
            string email, string acceso, string usuario, string password, string textoBuscar)
        {
            Idtrabajador = idtrabajador;
            Nombre = nombre;
            Apellidos = apellidos;
            Genero = genero;
            Fecha_Nac = fecha_Nac;
            Num_Documento = num_Documento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Acceso = acceso;
            Usuario = usuario;
            Password = password;
            TextoBuscar = textoBuscar;
        }
        //Metodos
        public string Insertar(DTrabajador Trabajador)
        {
            string rpta = string.Empty;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spinsertar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 50;
                        ParApellidos.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParGenero = new SqlParameter();
                        ParGenero.ParameterName = "@genero";
                        ParGenero.SqlDbType = SqlDbType.VarChar;
                        ParGenero.Size = 10;
                        ParGenero.Value = Trabajador.Genero;
                        command.Parameters.Add(ParGenero);

                        SqlParameter ParFecha_Nac = new SqlParameter();
                        ParFecha_Nac.ParameterName = "@fecha_nac";
                        ParFecha_Nac.SqlDbType = SqlDbType.Date;
                        ParFecha_Nac.Value = Trabajador.Fecha_Nac;
                        command.Parameters.Add(ParFecha_Nac);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 10;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 20;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 20;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 20;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 20;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }
            }
            return rpta;
        }
        //Metodo Editar
        public string Editar(DTrabajador Trabajador)
        {
            string rpta = string.Empty;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "speditar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 50;
                        ParApellidos.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParGenero = new SqlParameter();
                        ParGenero.ParameterName = "@genero";
                        ParGenero.SqlDbType = SqlDbType.VarChar;
                        ParGenero.Size = 10;
                        ParGenero.Value = Trabajador.Genero;
                        command.Parameters.Add(ParGenero);

                        SqlParameter ParFecha_Nac = new SqlParameter();
                        ParFecha_Nac.ParameterName = "@fecha_nac";
                        ParFecha_Nac.SqlDbType = SqlDbType.Date;
                        ParFecha_Nac.Value = Trabajador.Fecha_Nac;
                        command.Parameters.Add(ParFecha_Nac);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 10;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 20;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 20;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 20;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 20;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }
            }
            return rpta;
        }
        //Metodo Eliminar
        public string Eliminar(DTrabajador Trabajador)
        {
            string rpta = string.Empty;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "speliminar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdTrabajador = new SqlParameter();
                        ParIdTrabajador.ParameterName = "@idtrabajador";
                        ParIdTrabajador.SqlDbType = SqlDbType.Int;
                        ParIdTrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdTrabajador);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }
            }
            return rpta;
        }
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;
                        //Ejecutamos el comando
                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        //Metodo BuscarApellidos
        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_apellidos_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@apellidos";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Trabajador.TextoBuscar;

                        command.Parameters.Add(ParTextoBuscar);
                        //Ejecutamos el comando
                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception ex)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        //Metodo BuscarNum_Documento
        public DataTable BuscarNum_Documento(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_trabajador_num_documento";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);
                        //Ejecutamos el comando
                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        //Metodo Login
        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "splogin";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 20;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 20;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);
                        //Ejecutamos el comando
                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
    }
}

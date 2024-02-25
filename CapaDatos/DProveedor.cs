﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor : DbConecction
    {
        //Variables
        private int _Idproveedor;
        private string _Razon_Social;
        private string _Sector_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;
        //Propiedades
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Sector_Comercial { get => _Sector_Comercial; set => _Sector_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        //Constructores
        public DProveedor()
        {
            
        }
        public DProveedor(int idproveedor, string razon_Social, string sector_Comercial, string tipo_Documento, 
            string num_Documento, string direccion, string telefono, string email, string url, string textoBuscar)
        {
            Idproveedor = idproveedor;
            Razon_Social = razon_Social;
            Sector_Comercial = sector_Comercial;
            Tipo_Documento = tipo_Documento;
            Num_Documento = num_Documento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Url = url;
            TextoBuscar = textoBuscar;
        }
        //Metodos
        public string Insertar(DProveedor Proveedor)
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
                        command.CommandText = "spinsertar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor= new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdproveedor);

                        SqlParameter ParRazon_Social = new SqlParameter();
                        ParRazon_Social.ParameterName = "@razon_social";
                        ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                        ParRazon_Social.Size = 150;
                        ParRazon_Social.Value = Proveedor.Razon_Social;
                        command.Parameters.Add(ParRazon_Social);

                        SqlParameter ParSector_Comercial = new SqlParameter();
                        ParSector_Comercial.ParameterName = "@sector_comercial";
                        ParSector_Comercial.SqlDbType = SqlDbType.VarChar;
                        ParSector_Comercial.Size = 50;
                        ParSector_Comercial.Value = Proveedor.Sector_Comercial;
                        command.Parameters.Add(ParSector_Comercial);

                        SqlParameter ParTipo_Documento = new SqlParameter();
                        ParTipo_Documento.ParameterName = "@tipo_documento";
                        ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                        ParTipo_Documento.Size = 20;
                        ParTipo_Documento.Value = Proveedor.Tipo_Documento;
                        command.Parameters.Add(ParTipo_Documento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 10;
                        ParNum_Documento.Value = Proveedor.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Proveedor.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 20;
                        ParTelefono.Value = Proveedor.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Proveedor.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParUrl = new SqlParameter();
                        ParUrl.ParameterName = "@url";
                        ParUrl.SqlDbType = SqlDbType.VarChar;
                        ParUrl.Size = 100;
                        ParUrl.Value = Proveedor.Url;
                        command.Parameters.Add(ParUrl);
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
        public string Editar(DProveedor Proveedor)
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
                        command.CommandText = "speditar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Value = Proveedor.Idproveedor;
                        command.Parameters.Add(ParIdproveedor);

                        SqlParameter ParRazon_Social = new SqlParameter();
                        ParRazon_Social.ParameterName = "@razon_social";
                        ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                        ParRazon_Social.Size = 150;
                        ParRazon_Social.Value = Proveedor.Razon_Social;
                        command.Parameters.Add(ParRazon_Social);

                        SqlParameter ParSector_Comercial = new SqlParameter();
                        ParSector_Comercial.ParameterName = "@sector_comercial";
                        ParSector_Comercial.SqlDbType = SqlDbType.VarChar;
                        ParSector_Comercial.Size = 50;
                        ParSector_Comercial.Value = Proveedor.Sector_Comercial;
                        command.Parameters.Add(ParSector_Comercial);

                        SqlParameter ParTipo_Documento = new SqlParameter();
                        ParTipo_Documento.ParameterName = "@tipo_documento";
                        ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                        ParTipo_Documento.Size = 20;
                        ParTipo_Documento.Value = Proveedor.Tipo_Documento;
                        command.Parameters.Add(ParTipo_Documento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 10;
                        ParNum_Documento.Value = Proveedor.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Proveedor.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 20;
                        ParTelefono.Value = Proveedor.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Proveedor.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParUrl = new SqlParameter();
                        ParUrl.ParameterName = "@url";
                        ParUrl.SqlDbType = SqlDbType.VarChar;
                        ParUrl.Size = 100;
                        ParUrl.Value = Proveedor.Url;
                        command.Parameters.Add(ParUrl);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZO EL REGISTRO";
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
        public string Eliminar(DProveedor Proveedor)
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
                        command.CommandText = "speliminar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Value = Proveedor.Idproveedor;
                        command.Parameters.Add(ParIdproveedor);
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
            DataTable DtResultado = new DataTable("proveedor");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_proveedor";
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
        //Metodo BuscarNombre
        public DataTable BuscarRazon_Social(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_proveedor_razon_social";
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
        //Metodo BuscarNum_Documento
        public DataTable BuscarNum_Documento(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_proveedor_num_documento";
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
    }
}

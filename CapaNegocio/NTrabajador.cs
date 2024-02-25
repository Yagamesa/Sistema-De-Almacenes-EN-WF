using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTrabajador
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DTrabajador de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string genero, DateTime fecha_nac,
            string num_documento, string direccion, string telefono, string email, string acceso,
            string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Genero = genero;
            Obj.Fecha_Nac = fecha_nac;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la clase DTrabajador de la CapaDatos
        public static string Editar(int idtrabajador, string nombre, string apellidos, string genero, 
            DateTime fecha_nac, string num_documento, string direccion, string telefono, string email, 
            string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Genero = genero;
            Obj.Fecha_Nac = fecha_nac;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Eliminar de la clase DTrabajador de la CapaDatos
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la clase DTrabajador de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }
        //Metodo BuscarApellidos que llama al metodo BuscarApellidos de la clase DTrabajador de la CapaDatos
        public static DataTable BuscarApellidos(DTrabajador trabajador)
        {
            return trabajador.BuscarApellidos(trabajador);
        }


        //Metodo BuscarNum_Documento que llama al metodo BuscarNum_Documento de la clase DTrabajador de la CapaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
        //Metodo Login
        public static DataTable Login(string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}

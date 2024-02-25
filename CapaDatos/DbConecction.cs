using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class DbConecction
    {

        public static string cn = "Server=LAPTOP-8FO8KD0I\\SQLEXPRESS; DataBase=Dbventas; Integrated Security=true";
        private readonly string connectionString;

        public DbConecction()
        {
            connectionString = cn;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

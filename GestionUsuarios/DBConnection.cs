using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestionUsuarios
{
    public class DBConnection
    {
        private string ConnectionString = "Data Source=LAPTOP-SIB94PRS;Initial Catalog=GestionUsuarios;User ID=sa;Password=FAMhr200813@";


        public SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}

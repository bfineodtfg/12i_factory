using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _12i_factory
{
    public class databaseHandler
    {
        MySqlConnection connection;
        public databaseHandler() {
            string host = "localhost";
            string username = "root";
            string password = "";
            string database = "kolbasz";

            string connectionString = $"server={host};database={database};user={username};password={password}";

            connection = new MySqlConnection(connectionString);
        }



    }
}

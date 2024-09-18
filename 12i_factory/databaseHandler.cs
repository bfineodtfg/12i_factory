using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

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
        string tableName = "felhasznalok";
        public void readAll() {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string username = read.GetString(read.GetOrdinal("username"));
                    string password = read.GetString(read.GetOrdinal("password"));
                    int points = read.GetInt32(read.GetOrdinal("points"));
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    new user(username,password,points,id);
                }
                read.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Nem sikerült beolvasni az adatokat az adatbázisból");
            }
        }
        public void registerUser(string username, string password) {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tableName} (username,password) values ('{username}','{password}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Nem sikerült a regisztráció");
            }
        }

    }
}

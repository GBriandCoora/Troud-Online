using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Troud_Online
{
    class Database
    {
        public void Start()
        {
            //Connection to db
            var connection = new MySqlConnection(
               "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=db_thymio;SslMode=none");
            connection.Open();

            //Objects
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM t_player";

            MySqlDataReader tempReader = cmd.ExecuteReader();
            while (tempReader.Read())
            {
                
            }
            tempReader.Close();
        }
    }
}

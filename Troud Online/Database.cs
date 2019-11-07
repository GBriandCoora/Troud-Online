using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Troud_Online
{
    public class Database
    {
        public MySqlCommand cmd;

        public void Start()
        {
            //Connection to db
            MySqlConnection connection = new MySqlConnection(
               "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=db_troud;SslMode=none");
            connection.Open();
            cmd = connection.CreateCommand();

            Globals.connected = true;

            while (true)
            {
                switch (Globals.state)
                {
                    case 1:
                        break;
                }
            }
        }

        public bool CheckPlayer(string username, string password)
        {
            cmd.CommandText = "SELECT password FROM t_player WHERE username = '"+username+"';";

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(reader.GetString(0));
                if(reader.GetString(0) == password)
                {
                    Globals.username = username;
                    return true;
                }
            }
            reader.Close();
            return false;
        }

        public void AddPlayerToGame()
        {

        }
    }
}

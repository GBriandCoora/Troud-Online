using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Troud_Online
{
    public class Database
    {
        public MySqlCommand cmd;
        public MySqlDataReader reader;

        private int usrId = 0;

        /// <summary>
        /// Asynchronous method for the Game Update
        /// </summary>
        public void Start()
        {
            //Connection to db
            MySqlConnection connection = new MySqlConnection(
               "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=db_troud;SslMode=none");
            connection.Open();
            cmd = connection.CreateCommand();

            MySqlConnection loopConnection = new MySqlConnection(
                "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=db_troud;SslMode=none");
            loopConnection.Open();
            MySqlCommand loopCmd = loopConnection.CreateCommand();

            Globals.connected = true;

            //Game loop
            while (Globals.connected)
            {
                switch (Globals.state)
                {
                    case 1:
                        break;
                }
            }
        }

        /// <summary>
        /// Check if the player exists and update global variables
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <param name="password">Password to check</param>
        /// <returns></returns>
        public bool CheckPlayer(string username, string password)
        {
            cmd.CommandText = "SELECT password, id FROM t_player WHERE username = '"+username+"';";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == password)
                {
                    Globals.username = username;
                    usrId = reader.GetInt32(1);
                    reader.Close();
                    return true;
                }
            }
            reader.Close();
            
            return false;
        }

        /// <summary>
        /// Add the player to the current game
        /// </summary>
        public void AddPlayerToGame()
        {
            //Check if the link exists already
            cmd.CommandText = "SELECT fk_player FROM t_connected WHERE fk_player = "+usrId+";";
            reader = cmd.ExecuteReader();
            bool exist = false;
            while (reader.Read())
            {
                exist = true;
            }
            reader.Close();

            //Create a new connection if the link doesn't exist
            if (!exist)
            {
                cmd.CommandText = "INSERT INTO t_connected (fk_player, fk_game) VALUES ('"+usrId+"', '0');";
                cmd.ExecuteNonQuery();
            }

            //Check number of players already connected
            cmd.CommandText = "SELECT fk_player FROM t_connected WHERE lstCo > CURRENT_TIMESTAMP - 30/1440.0;";
            reader = cmd.ExecuteReader();
            byte nbr = 0;
            while (reader.Read())
            {
                nbr++;
            }
            reader.Close();

            //Change number of player
            cmd.CommandText = "UPDATE t_connected SET lstCo = CURRENT_TIMESTAMP, nbr = '" + nbr + "' WHERE fk_player = '" + usrId + "';";
            cmd.ExecuteNonQuery();

            Globals.state = 1;

            new Thread(UpdateConnection).Start();
        }

        /// <summary>
        /// Thread method which update the lstCo value every 10s
        /// </summary>
        private void UpdateConnection()
        {
            MySqlConnection loopConnection = new MySqlConnection(
                "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=db_troud;SslMode=none");
            loopConnection.Open();
            MySqlCommand loopCmd = loopConnection.CreateCommand();

            //Game loop
            while (Globals.connected)
            {
                loopCmd.CommandText = "UPDATE t_connected SET lstCo = CURRENT_TIMESTAMP WHERE fk_player = '"+usrId+"';";
                loopCmd.ExecuteNonQuery();
                Thread.Sleep(10000);
            }
        }
    }
}
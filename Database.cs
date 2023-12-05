using CounterStrikeSharp.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySqlConnector;
using CounterStrikeSharp.API;

namespace JailbreakPlugin
{
    public class Database
    {
        private JailbreakPlugin _plugin;

        private MySqlConnection _connection;

        public Database(JailbreakPlugin plugin)
        {
            _plugin = plugin;
        }

        public void Initialize()
        {
            // Declare variables to store values
            string dbHostname;
            string dbUsername;
            string dbPassword;
            string dbDatabase;

            // Read configuration from INI file
            bool configReadSuccessfully = readFromCfg(out dbHostname, out dbUsername, out dbPassword, out dbDatabase);

            var dbConnectionString = $"server={dbHostname};database={dbDatabase};uid={dbUsername};password={dbPassword};";
            //connect to database using mysql connector
            _connection = new MySqlConnection(dbConnectionString);
            _connection.Open();
        }

        protected bool readFromCfg(out string dbHostname, out string dbUsername, out string dbPassword, out string dbDatabase)
        {
            string iniFilePath = "/home/steam/cs2-dedicated/game/csgo/addons/counterstrikesharp/plugins/JailbreakPlugin/sql.ini";

            // Initialize output parameters
            dbHostname = string.Empty;
            dbUsername = string.Empty;
            dbPassword = string.Empty;
            dbDatabase = string.Empty;

            // Check if the file exists
            if (File.Exists(iniFilePath))
            {
                // Read the lines from the INI file
                string[] lines = File.ReadAllLines(iniFilePath);

                // Parse each line
                foreach (var line in lines)
                {
                    // Split the line into key and value
                    string[] parts = line.Split('=');

                    // Ensure the line has the correct format (key=value)
                    if (parts.Length == 2)
                    {
                        // Trim leading and trailing spaces
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        // Assign values based on the key
                        switch (key)
                        {
                            case "dbHostname":
                                dbHostname = value;
                                break;
                            case "dbUsername":
                                dbUsername = value;
                                break;
                            case "dbPassword":
                                dbPassword = value;
                                break;
                            case "dbDatabase":
                                dbDatabase = value;
                                break;
                        }
                    }
                }

                return true; // Return true if reading and setting values was successful
            }
            else
            {
                Console.WriteLine($"INI file not found: {iniFilePath}");
                return false; // Return false if the file is not found
            }
        }

        public int load_cash(JailPlayer player)
        {
            var steamid = player.SteamID;

            var query = $"SELECT cash FROM `dopecash` WHERE steamid = '{steamid}' LIMIT 1";
            var cmd = new MySqlCommand(query, _connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var cash = reader.GetInt32(0);
                //Server.PrintToConsole("cash:" + cash);
                return cash;
            }
            return 0;
        }

        public bool give_cash(CCSPlayerController player, int cashAmount, int cashReason) {
            var query = "SELECT * FROM `player` LIMIT 1";
            var cmd = new MySqlCommand(query, _connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var steamid = reader.GetString(1);
                var name = reader.GetString(5);
                Server.PrintToConsole("id:" + id);
                Server.PrintToConsole("name:" + name);
                Server.PrintToConsole("steamid:" + steamid);
            }
            player.announce(String.Empty, $"You have been given ${cashAmount}!");
            return false;
        }
    }
}
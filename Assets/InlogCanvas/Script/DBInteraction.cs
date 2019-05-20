using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DBConnection
{
    class DBInteraction
    {
        // any random numbers use random.org
        private protected const string AES_KEY = "";
        // connection to DB server fill in data
        private protected const string connString = "server=;user=;password=;database=;";

        public static void SendDataLogin(string FirstInsert, string SecondInsert, string TableName)
        {
            // dit veranderen wanneer naar echt server
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                string sql = "INSERT INTO login (`username`, `password`) VALUES (AES_ENCRYPT('"+FirstInsert+ "','"+AES_KEY+"'), AES_ENCRYPT('"+SecondInsert+"','"+AES_KEY+"'));";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {  
                TestScript.Debugging(ex.ToString());
            }
        }
        
        public static void SendNewPassword(string Username, string NewPass,string TableName)
        {
            //later afmaken met Jesse

            try
            {               
                MySqlConnection conn = new MySqlConnection(connString);
                string sql = "UPDATE LOGIN SET password = aes_encrypt('"+NewPass+"','"+AES_KEY+"') where username = aes_encrypt('"+Username+"','"+AES_KEY+"');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                TestScript.Debugging(ex.ToString());               
            }
        }
        public static string ReceiveDataLogin(string Username, string Tablename)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                // Verbeteren wanneer ik mijn laptop terug heb
                string sql = "select AES_DECRYPT(`password`, '" + AES_KEY + "') AS pass FROM login WHERE username = aes_encrypt('" + Username + "', '" + AES_KEY + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string PassName = dataReader.GetString(0);
                    //TestScript.Debugging(PassName);
                    return PassName;
                }
                dataReader.Close();
                conn.Close();
                return null;
            }
            catch (Exception ex)
            {
                TestScript.Debugging(ex.ToString());
                return null;
            }
        }
        public static void DeleteUser(string Username, string Tablename)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                string sql = "DELETE FROM '" + Tablename + "' where username = aes_encrypt('" + Username + "','" + AES_KEY + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                }
                dataReader.Close();
                conn.Close();
            }catch(Exception ex)
            {
                TestScript.Debugging(ex.ToString());
            }
        }
    }
}

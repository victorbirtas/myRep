using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataLayer
{
   public class UsersDAO
    {
        private MySqlConnection conn;
        String connectionString;
        public UsersDAO()
        {
            //connectionString = "server=127.0.0.1;uid=root;" +
            // "pwd=root;database=login;";
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "login");
            conn = new MySqlConnection(connectionString);
        }

        public string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public String getUser(String username, String password)
        {
            String u = "";
            String sql = "SELECT * FROM users WHERE username= '" + username + "' AND password='" + getMd5Hash(password) + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    u = reader["role"].ToString();
                }
                else
                {
                    u = "";
                }
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }
            return u;
        }

        public void insertAngajat(String nume, String username, String password, String role)
        {
            String sql = "INSERT into users(nume,username,password,role) values('" + nume + "','" + username + "','" + password +  "','" + role +  "');";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }

        }


        public void resetPassword(String username,String newPassword)
        {
            String sql = "update users set password ='" + newPassword  + "' WHERE username ='" + username + "';";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }

        }
    }

}

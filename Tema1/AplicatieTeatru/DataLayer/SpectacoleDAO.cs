using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataLayer
{
   public class SpectacoleDAO
    {

        private MySqlConnection conn;
        String connectionString;
         public SpectacoleDAO()
        {
            //connectionString = "server=127.0.0.1;uid=root;" +
            // "pwd=root;database=login;";
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "login");
            conn = new MySqlConnection(connectionString);
        }
        public void insertSpectacol(String titlu, String regia, String distributia, DateTime premiera, int nrbilete)
        {
            String sql = "INSERT into spectacole(titlul,regia,distributia,premiera,nrbilete) values('" + titlu + "','" + regia + "','" + distributia + "','" + premiera + "','" + nrbilete + "');";

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

        public void updateSpectacol(String titlu, String regia, String distributia,DateTime premiera, int nrbilete)
        {
            String sql = "update spectacole set titlul ='" + titlu + "', regia ='" + regia
            + "', distributia ='" + distributia + "', premiera ='" + premiera + "', nrbilete ='" + nrbilete + "' WHERE titlul ='" + titlu + "';";

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


        public DataTable getSpectacole()
        {
            DataTable dt = new DataTable();
            String sql = "SELECT titlul,regia,distributia,nrbilete FROM spectacole";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }
        }

       public void deleteSpectacol(String titlu)
        {
            String sql = "delete FROM spectacole WHERE titlul= '" + titlu + "'";
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

       public int getNrBileteSpectacol(String titlu)
       {
          String sql =  "SELECT nrbilete FROM bilete where titlul='" + titlu + "';";
          int nr = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                reader.Read();
                if (reader.HasRows)
                {
                    nr = int.Parse(reader["nrbilete"].ToString());
                    return nr;
                }
                else
                {
                    nr = 0;
                }
                conn.Close();
                return nr;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return 0;
            }
       }

    }
}

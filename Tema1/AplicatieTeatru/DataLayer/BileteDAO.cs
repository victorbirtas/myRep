using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataLayer
{
    public class BileteDAO
    {

        private MySqlConnection conn;
        String connectionString;
         public BileteDAO()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "login");
            conn = new MySqlConnection(connectionString);
        }
        public void insertBilet(String spectacol, int rand,int numar)
        {
            String sql = "INSERT into bilete(spectacol,rand,numar) values('" + spectacol + "','" + rand + "','" + numar + "');";

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

        public DataTable getBilete(String titlu)
        {
            DataTable dt = new DataTable();
            String sql = "SELECT * FROM bilete where spectacol ='" + titlu + "';";
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

    }
}

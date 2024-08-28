using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectionInloggning
{
    public static class Program
    {
        public static string connString = "Server=127.0.0.1;Port=3306;Database=testdb;User=root;Password=root;";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool Inloggning(string user, string pass)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            //Bygger upp SQL querry
            string sqlQuerry = $"SELECT * FROM users WHERE users_username = @username AND users_password = @password;";


            MySqlCommand cmd = new MySqlCommand(sqlQuerry, conn);

            //Exekverar querry
            try
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@password", pass);

                MySqlDataReader reader = cmd.ExecuteReader();

                //Kontrollerar resultatet
                if (reader.Read())
                {
                    /*MessageBox.Show("Inloggad");*/
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return false;
        }
    }
}

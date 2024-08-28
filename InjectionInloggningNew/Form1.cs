using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectionInloggning
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            InitDB(Program.connString);
        }

        private void InitDB(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var createTableCmd = new MySqlCommand(@"
                    CREATE TABLE IF NOT EXISTS users (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        users_username VARCHAR(255) NOT NULL UNIQUE,
                        users_password CHAR(60) NOT NULL,
                        auth_level TINYINT(3) DEFAULT 0
                    );", connection);
                createTableCmd.ExecuteNonQuery();

                var insertCmd = new MySqlCommand(@"
                    INSERT INTO users (users_username, users_password, auth_level)
                    VALUES ('Ture', '123', 0)
                    ON DUPLICATE KEY UPDATE users_username = users_username;", connection);
                insertCmd.ExecuteNonQuery();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Program.Inloggning(txtUser.Text, txtPass.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

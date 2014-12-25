using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StudentEntryDB_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;

            string connectionString = @"Data Source = (local)\SQLEXPRESS ; Database = UniversityDB ; Integrated Security = true";

            SqlConnection connection = new SqlConnection(connectionString);
 
            connection.Open();
            string query = "INSERT INTO t_Students VALUES ('"+name+"','"+address+"','"+email+"','"+phone+"')";
            SqlCommand command = new SqlCommand(query, connection);

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            
            if (rowAffected > 0) 
            {
                MessageBox.Show("successfully data save");
            }
            else 
            {
                MessageBox.Show("coulden't save");
            }
                                    
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}

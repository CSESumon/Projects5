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

namespace StudentApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // take user input

            string name = nameTextBox.Text;
            string adress = addressTextBox.Text;
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;


            // connect with db

            //1. connection string


            string connectionString = @"Data Source = (local)\SQLExpress; Database = UniversityDB; Integrated Security = true";

            //2.build a connection with connection string

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();



            // insert data into database

            string query = "INSERT INTO tStudent VALUES ('" + name + "','" + adress + "','" + phone + "','" + email + "')";

            //OR ata bt ata ta prblm hy-------  string query = String.Format("INSERT INTO tStudents VALUES('{0}','{1}','{2}','{3}'",name,adress,phone,email);


            SqlCommand command = new SqlCommand(query, connection);

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("Successfully Saved");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}

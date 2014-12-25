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
    public partial class ViewUI : Form
    {
        public ViewUI()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Student> aStudents = new List<Student>();
            string inputId = idTextBox.Text;

            string connectionString = @"Data Source = (local)\SQLExpress; Database = UniversityDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM tStudent";
            if (!string.IsNullOrEmpty(inputId))
            {
                query = "SELECT * FROM tStudent WHERE ID='" + inputId + "'";
            }
            
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

           
            studentListView.Items.Clear();
            while (reader.Read())
            {
                ListViewItem aListViewItem = new ListViewItem();
                Student student = new Student();

                student.id= (int)reader["ID"];
                student.name = reader["Name"].ToString();
                student.email = reader["EmailAddress"].ToString();
                student.address = reader["Address"].ToString();
                student.phoneNo = reader["PhoneNumber"].ToString();
                aStudents.Add(student);
            }

            
            foreach (var student in aStudents)
            {
                ListViewItem li = new ListViewItem();
                li.Text = Convert.ToString(student.id);
                li.SubItems.Add(student.name);
                li.SubItems.Add(student.address);
                li.SubItems.Add(student.phoneNo);
                li.SubItems.Add(student.email);

                li.Tag = student;
                studentListView.Items.Add(li);
            }

            connection.Close();
        }


        private void studentListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = studentListView.SelectedItems[0];
            Student selectedStudent = (Student) selectedItem.Tag;

            idLabel.Text = selectedStudent.id.ToString();
            nameTextBox.Text = selectedStudent.name;
            emailTextBox.Text = selectedStudent.email;
            addressTextBox.Text = selectedStudent.address;
            phoneTextBox.Text = selectedStudent.phoneNo;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (local)\SQLExpress; Database = UniversityDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // insert data into database
            //string name = nameTextBox.Text;
            //string address = addressTextBox.Text;
            //string phone = phoneTextBox.Text;
            //string email = emailTextBox.Text;
            string query = "UPDATE tStudent set Name= '" + nameTextBox.Text + "', EmailAddress = '" + emailTextBox.Text + "',  PhoneNumber = '" + phoneTextBox.Text + "', Address ='" + emailTextBox.Text + "' where Id = '" + idLabel.Text + "'";

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

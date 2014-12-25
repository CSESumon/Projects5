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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string search = searchTextBox.Text;
            string connectionString = @"Data Source = (local)\SQLEXPRESS ; Database = UniversityDB ; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT *FROM t_Students";
            if (!string.IsNullOrEmpty(search))
            {
                query = "SELECT *FROM t_Students  Where ID ='"+search+"'";
               
            }
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            List<Student> students = new List<Student>();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Student student = new Student();
                student.id = (int) reader["id"];
                student.name = reader["Name"].ToString();
                student.address = reader["Address"].ToString();
                student.email = reader["Email Address"].ToString();
                student.phone = reader["Phone Number"].ToString();


                students.Add(student);
                ListViewItem myViewItem = new ListViewItem();
                myViewItem.Tag = student;
                showlistView.Items.Add(myViewItem);
                myViewItem.Text = (student.id).ToString();
                myViewItem.SubItems.Add(student.name);
                myViewItem.SubItems.Add(student.address);
                myViewItem.SubItems.Add(student.email);
                myViewItem.SubItems.Add(student.phone);
               
                
                
            }
            
          connection.Close();

        }

        

        private void showlistView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem student = showlistView.SelectedItems[0];
            Student selectStudent = (Student) student.Tag;

            idlabel.Text = selectStudent.id.ToString();
            nameTextBox.Text = selectStudent.name;
            addressTextBox.Text =selectStudent.address;
            emailTextBox.Text = selectStudent.email;
            phoneTextBox.Text = selectStudent.phone;

            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (local)\SQLEXPRESS ; Database = UniversityDB ; Integrated Security = true";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE t_Students SET ('" +nameTextBox.Text+ "','" + addressTextBox.Text + "','" + emailTextBox.Text + "','" + phoneTextBox.Text + "')";
            SqlCommand command = new SqlCommand(query,connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("Successfully Update");
            }
            else
            {
                MessageBox.Show("Please try Again");
            }
        }

        private void View_Load(object sender, EventArgs e)
        {

        }
    }
}

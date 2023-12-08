using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Grocery_Store
{
    public partial class userLogIn : Form
    {
        public userLogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Zxshx\OneDrive\Desktop\Grocery Store MTP Project.accdb""";
                OleDbConnection conn = new OleDbConnection(connectionString);

                conn.Open();

                string query = $"Select * from Users where Username = '{userName}' and User_Password = '{password}'";
                DbCommand cmd = new OleDbCommand(query, conn);

                DbDataReader dbDataReader = cmd.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                   // string loggedInUser = userName;
                    Form1 form1 = new Form1(userName);
                    this.Hide();
                    form1.ShowDialog();
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Please Check your Entered Information");
                }

                dbDataReader.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Error occurred" + ex.Message);
            }
        }
    }
}

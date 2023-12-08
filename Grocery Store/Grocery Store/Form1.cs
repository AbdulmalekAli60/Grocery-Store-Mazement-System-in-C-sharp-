using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;

namespace Grocery_Store
{
    public partial class Form1 : Form
    {
        public string username;
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Zxshx\OneDrive\Desktop\Grocery Store MTP Project.accdb""";
        OleDbConnection conn = new OleDbConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
            addUserPanel.Hide();
            DeletingPanle.Hide();
            QueringPanel.Hide();
            BuyPanel.Hide();
            payPanel.Hide();
        }

        public Form1(string userName)
        {
            InitializeComponent();
            addUserPanel.Hide();
            DeletingPanle.Hide();
            QueringPanel.Hide();
            BuyPanel.Hide();
            payPanel.Hide();
            this.username = userName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void insertUserBtn_Click(object sender, EventArgs e)
        {
            addUserPanel.Show();
        }

        private void panel1Close_Click(object sender, EventArgs e)
        {
            addUserPanel.Visible = false;
        }

        private void CrestNewUser_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            if (userSignUpRadioBtn.Checked)
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO Users (Username, User_Password) VALUES ('" + userName + "', '" + password + "')";
                    DbCommand cmd = new OleDbCommand(query, conn);

                    cmd.ExecuteNonQuery();


                    //retrieve the last inserted user id
                    cmd.CommandText = "SELECT @@IDENTITY";
                    int lastInsertedUser = (int)cmd.ExecuteScalar();

                    MessageBox.Show("User Added Successfully And the User ID is: " + lastInsertedUser);
                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";

                }
                catch (Exception ex)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Error Occurred " + ex.Message);
                }
            }
            else if (CustomerSignUpRadioBtn.Checked)
            {
                {

                    string phoneNumber = textBox2.Text;
                    try
                    {
                        conn.Open();

                        string query = "INSERT INTO Customers (Customer_Name, Customer_Phone_Number) VALUES ('" + userName + "', '" + phoneNumber + "')";
                        DbCommand cmd = new OleDbCommand(query, conn);

                        cmd.ExecuteNonQuery();

                        //retrieve the last inserted customer
                        cmd.CommandText = "SELECT @@IDENTITY";
                        int lastInsertedCustomer = (int)cmd.ExecuteScalar();

                        MessageBox.Show("User Added Successfully and the Customer ID is: " + lastInsertedCustomer);
                        conn.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    catch (Exception ex)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        MessageBox.Show("Error Occurred " + ex.Message);
                    }

                }
            }

            else if (addingProductRaidoBtn.Checked)
            {
                string productDescription = textBox1.Text;
                string productPrice = textBox2.Text;
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Products (Product_Description, Price) VALUES ('" + productDescription + "', '" + productPrice + "')";

                    DbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    //retrieve the last inserted product
                    cmd.CommandText = "SELECT @@IDENTITY";
                    int lastInsertedProduct = (int)cmd.ExecuteScalar();

                    MessageBox.Show("Product Inserted Successfully and the Product ID is: " + lastInsertedProduct);

                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                catch (Exception ex)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Error Occurred " + ex.Message);
                }
            }

        } // Everything about adding 

        private void CustomerSignUpRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomerSignUpRadioBtn.Checked)
            {
                label1.Text = "Customer Name";
                label2.Text = "Phone Number";
            }

        }

        private void Deleting_Click(object sender, EventArgs e) // showing the Delete Panel
        {
            DeletingPanle.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DeletingPanle.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (addingProductRaidoBtn.Checked)
            {
                label1.Text = "Product Details";
                label2.Text = "Product's price";
            }
        }

        private void userSignUpRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (userSignUpRadioBtn.Checked)
            {
                label1.Text = "Username";
                label2.Text = "Password";
            }
        }

        private void button1_Click(object sender, EventArgs e) // Everything about delete
        {
            int ID = Int32.Parse(textBox3.Text);

            if (DeleteUserRaidioBtn.Checked)
            {
                try
                {
                    conn.Open();

                    string query = $"Delete from Users Where User_id = {ID}";
                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User Deleted Successfully");
                    conn.Close();

                    textBox3.Text = "";

                }
                catch (Exception ex)
                {

                    textBox3.Text = "";
                    MessageBox.Show("Error Occurred " + ex.Message);
                }
            }
            else if (DeleteCustomerRaidoBtn.Checked)
            {
                try
                {
                    conn.Open();

                    string query = $"Delete from Customers Where Customer_id = {ID}";
                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer Deleted Successfully");
                    conn.Close();

                    textBox3.Text = "";

                }
                catch (Exception ex)
                {

                    textBox3.Text = "";
                    MessageBox.Show("Error Occurred " + ex.Message);
                }
            }

            if (DeleteProductRaidoBtn.Checked)
            {
                try
                {
                    conn.Open();

                    string query = $"Delete from Products Where Product_id = {ID}";
                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Product Deleted Successfully");
                    conn.Close();

                    textBox3.Text = "";

                }
                catch (Exception ex)
                {

                    textBox3.Text = "";
                    MessageBox.Show("Error Occurred " + ex.Message);
                }
            }
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            QueringPanel.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            QueringPanel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e) // General Query
        {

            if (QueryOnUserRaidioBtn.Checked)
            {
                ExecuteGeneralQuery("Users");
            }

            if (QueryOnCustomerRaidoBtn.Checked)
            {
                ExecuteGeneralQuery("Customers");
            }

            if (QueryOnProductRadioBtn.Checked)
            {
                ExecuteGeneralQuery("Products");
            }
            if (QueryingOnSalestRadioBtn.Checked)
            {
                ExecuteGeneralQuery("Pays");
            }

        }
        private void ExecuteGeneralQuery(string tableName) // general method for general quiring
        {
            try
            {
                string query = $"SELECT * FROM {tableName}";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                textBox4.Text = "";
                MessageBox.Show("Error Occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e) // specific Query 
        {
            int ID = Int32.Parse(textBox4.Text);

            if (QueryOnUserRaidioBtn.Checked)
            {
                executesSpecificQuerying(ID, "Users", "User_id");
            }

            if (QueryOnCustomerRaidoBtn.Checked)
            {
                executesSpecificQuerying(ID, "Customers", "Customer_id");
            }

            if (QueryOnProductRadioBtn.Checked)
            {
                executesSpecificQuerying(ID, "Products", "Product_id");
            }
            if (QueryingOnDeptRadioBtn.Checked)
            {
                executesSpecificQuerying(ID, "Pays", "Customer_id");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuyPanel.Show();
            getProducts(); //to add products in ComboBox on buy btn
        }

        private void getProducts()
        {
            try
            {
                conn.Open();
                string query = "select Product_Description from Products";
                DbCommand cmd = new OleDbCommand(query, conn);

                DbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string product = reader.GetString(0);
                    ProductsComboBox.Items.Add(product);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BuyPanel.Visible = false;
            ProductsComboBox.Items.Clear();
        }

        private void executesSpecificQuerying(int ID, string tableName, string attributeName)
        {
            try
            {
                if (tableName == "Pays")
                {
                    conn.Open();
                    string query2 = $"Select Max(debt) from {tableName} where {attributeName} = {ID}";

                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(query2, conn);

                    DataTable dataTable2 = new DataTable();

                    adapter2.Fill(dataTable2);

                    dataGridView1.DataSource = dataTable2;

                    conn.Close();
                }
                else
                {
                    conn.Open();
                    string query = $"Select * from {tableName} where {attributeName} = {ID}";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                textBox4.Text = "";
                MessageBox.Show("Error Occurred " + ex);
            }
            finally
            {
                conn.Close();
            }
        } //general method for specific querying 

        private void UpdatingPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = ProductsComboBox.SelectedItem.ToString();
            try
            {
                conn.Open();
                string query = $"select Price from Products where Product_Description = '{selectedProduct}'";
                DbCommand cmd = new OleDbCommand(query, conn);

                object returnedPrice = cmd.ExecuteScalar(); //ExecuteScalar is used to retrieve a single value form DB

                if (returnedPrice != null)
                {
                    int price = Convert.ToInt32(returnedPrice);
                    priceTextBox.Text = price.ToString();
                }
                else
                {
                    MessageBox.Show("Price not available");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void StorePurchaseBtn_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(UserIDtextBox.Text);
            int quantity = Int32.Parse(QuantityComboBox.SelectedItem.ToString());
            int price = Int32.Parse(priceTextBox.Text);

            string selectedProduct = ProductsComboBox.SelectedItem.ToString();
            int totalAmount = (quantity * price);

            try
            {
                conn.Open();
                string getProductsId = $"select Product_id from Products where Product_Description = '{selectedProduct}'";
                string currentDebt = $"select debt from Pays where Customer_id = {userID}";
                string getCurrentUser = $"select User_id from Users where Username = '{this.username}'";

                DbCommand cmd = new OleDbCommand(getProductsId, conn);
                DbCommand cmd2 = new OleDbCommand(currentDebt, conn);
                DbCommand cmd4 = new OleDbCommand(getCurrentUser, conn);

                object returendProductID = cmd.ExecuteScalar();
                object returendCurrentDebt = cmd2.ExecuteScalar();
                object CurrentUserID = cmd4.ExecuteScalar();


                int newDebt = Convert.ToInt32(returendCurrentDebt) + totalAmount;

                string query = $"insert into Pays (Customer_id,Product_id,Quantity,debt,currentUser,currentUserName) values ({userID},{returendProductID},{quantity},{newDebt},'{CurrentUserID}','{this.username}')";

                DbCommand cmd3 = new OleDbCommand(query, conn);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred " + ex);
            }
            finally
            {
                conn.Close();
            }

        }

        private void QueryingOnDeptRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (QueryingOnDeptRadioBtn.Checked)
            {
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            payPanel.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(textBox5.Text);

            try
            {
                conn.Open();
                string query = $"update Pays set debt = 0 where Customer_id = {userID} ";
                DbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment made successfully ");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            payPanel.Show();
        }

        private void AdvacnedQuery_Click(object sender, EventArgs e)
        {
            if (QueryOnUserRaidioBtn.Checked)
            {
                advanced("Users","Username");
            }

            if (QueryOnCustomerRaidoBtn.Checked)
            {
                advanced("Customers", "Customer_Name");
            }

            if (QueryOnProductRadioBtn.Checked)
            {
                advanced("Products","Product_Description");
            }
            if (QueryingOnSalestRadioBtn.Checked)
            {
                advanced("Pays","Customer_id");
            }
        }

        private void advanced(string tableName, string attribute)
        {
            string inputText = textBox4.Text;
            try
            {
                string query = $"SELECT * FROM {tableName} where {attribute} like '%{inputText}%'";


                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    textBox4.Text = "";
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                textBox4.Text = "";
                MessageBox.Show("Error Occurred: " + ex.Message);
            }
            finally
            {
            }
        }

        private void QueryingOnSalestRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (QueryingOnSalestRadioBtn.Checked)
            {
                AdvacnedQueryBtn.Visible = false;

            }
            else
            {
                AdvacnedQueryBtn.Visible = true;

            }

        }

        private void addUserPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    } //class

} //namespace

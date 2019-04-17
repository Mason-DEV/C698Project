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

namespace C698Project
{
    public partial class MainScreen : Form
    {

        public MainScreen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void partsAddButton_Click(object sender, EventArgs e)
        {
            Form addPart = new AddPart();
            addPart.Owner = this;
            addPart.Show();
            this.Hide();
        }

        private void partsModifyButton_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = this.partsDataGridView.SelectedRows[0];
            int selectedID;
            try { selectedID = (int)row.Cells["partID"].Value; } catch { selectedID = (int)row.Cells["Part ID"].Value; }
            Part partToModify = new Part();
            partToModify.setPartID(selectedID);
            Console.WriteLine("Setting id to" + selectedID);

            Form modifyPart = new ModifyPart(selectedID);
            modifyPart.Owner = this;
            modifyPart.Show();
            this.Hide();

           

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productsAddButton_Click(object sender, EventArgs e)
        {
            Form addProduct = new AddProduct();
            addProduct.Owner = this;
            addProduct.Show();
            this.Hide();
        }

        private void productsModifyButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.productsDataGridView.SelectedRows[0];
            int selectedID;
            try { selectedID = (int)row.Cells["productID"].Value; } catch { selectedID = (int)row.Cells["Product ID"].Value; }
            Products productToModify = new Products();
            productToModify.setProductID(selectedID);

            
            Form modifyProduct = new ModifyProduct(selectedID);
            modifyProduct.Owner = this;
            modifyProduct.Show();
            this.Hide();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit' from partTable";
           // cmd.CommandText = "Select * from partTable";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            sqlDataAdap.Update(dtRecord);
            partsDataGridView.DataSource = dtRecord;
            con.Close();

            SqlConnection con2 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select productID AS 'Product ID', name AS 'Product Name', inStock AS 'Inventory Level',  price AS 'Price per Unit' from productTable";
            // cmd.CommandText = "Select * from partTable";
            SqlDataAdapter sqlDataAdap2 = new SqlDataAdapter(cmd2);

            DataTable dtRecord2 = new DataTable();
            sqlDataAdap2.Fill(dtRecord2);
            sqlDataAdap2.Update(dtRecord2);
            //partsDataGridView.DataSource = dtRecord;
            productsDataGridView.DataSource = dtRecord2;
            con2.Close();



        }

        private void partsDeleteButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure to delete this part?",
                                      "Part Deletion",
                                      MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                DataGridViewRow row = this.partsDataGridView.SelectedRows[0];
                int selectedID;
                try { selectedID = (int)row.Cells["partID"].Value; } catch { selectedID = (int)row.Cells["Part ID"].Value; }
                Inventory lookup = new Inventory();
                Part toDelete = lookup.LookupPart(selectedID);
                bool deleted = lookup.deletePart(toDelete);
                if (deleted) {

                    SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit' from partTable";

                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);
                    

                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Update(dtRecord);
                    sqlDataAdap.Fill(dtRecord);
                    
                    partsDataGridView.DataSource = dtRecord;
                }
            
            }
            else
            {
                //Dont do anything
            }
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
        {

            String search = partsSearchText.Text;
            
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit' from partTable";
            if (search == null || search == "")
            {
                cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit'  FROM dbo.partTable";
            }
            else {
                cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit'  FROM dbo.partTable WHERE partID LIKE @Search OR name LIKE  @Search OR price LIKE @Search  OR min LIKE @Search  ";
            }
            
            cmd.Parameters.AddWithValue("@Search", search);

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);


            DataTable dtRecord = new DataTable();
            sqlDataAdap.Update(dtRecord);
            sqlDataAdap.Fill(dtRecord);

            partsDataGridView.DataSource = dtRecord;
           
        }

        private void productsDeleteButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure to delete this Product?",
                                    "Product Deletion",
                                    MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                DataGridViewRow row = this.productsDataGridView.SelectedRows[0];
                int selectedID;
                try { selectedID = (int)row.Cells["productID"].Value; } catch { selectedID = (int)row.Cells["Product ID"].Value; }
                Inventory lookup = new Inventory();
                Products toDelete = lookup.lookupProduct(selectedID);
                int productID = toDelete.getProductID();
                bool deleted = lookup.removeProduct(productID);
                if (deleted)
                {

                    SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select productID AS 'Product ID', name AS 'Product Name', inStock AS 'Inventory Level',  price AS 'Price per Unit' from productTable";

                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);


                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Update(dtRecord);
                    sqlDataAdap.Fill(dtRecord);

                    productsDataGridView.DataSource = dtRecord;
                }

            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}

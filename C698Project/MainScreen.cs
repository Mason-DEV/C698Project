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
            Form modifyProduct = new ModifyProduct();
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
                // If 'No', do something here.
            }
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit' from partTable";
            cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit'  FROM dbo.partTable WHERE partID LIKE @Search OR name LIKE  @Search OR price LIKE @Search  OR min LIKE @Search  ";
            cmd.Parameters.AddWithValue("@Search", partsSearchText.Text);

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);


            DataTable dtRecord = new DataTable();
            sqlDataAdap.Update(dtRecord);
            sqlDataAdap.Fill(dtRecord);

            partsDataGridView.DataSource = dtRecord;
           
        }
    }
}

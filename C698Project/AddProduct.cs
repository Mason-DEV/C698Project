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

    
    public partial class AddProduct : Form
    {
        Products productToAdd = new Products();
        int productID;

        public AddProduct()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }


        

        private void AddProduct_Load(object sender, EventArgs e)
        {
            Console.Write("loading");
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit' from partTable";
            // cmd.CommandText = "Select * from partTable";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            sqlDataAdap.Update(dtRecord);
            //partsDataGridView.DataSource = dtRecord;
            partsAvaliableDataGrid.DataSource = dtRecord;
            con.Close();


            SqlConnection con2 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con2.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT MAX(productID) FROM productTable;";

            try{
                productID = (int)cmd2.ExecuteScalar();
            }
            catch
            {
               productID = 0;
            }
            Console.WriteLine("product grabbed "+productID);
            con2.Close();


        }

      

        private void saveButton_Click(object sender, EventArgs e)
        {

            //Add Prodocut then add associatedPart
            String productName = productNameTextbox.Text;

            Double productPrice = Convert.ToDouble(priceTextbox.Text);

            int productInStock = Convert.ToInt32(invTextbox.Text);

            int productMin = Convert.ToInt32(minTextbox.Text);

            int productMax = Convert.ToInt32(maxTextbox.Text);



            productID = productID + 1;
            Console.WriteLine("product set" + productID);
            productToAdd.setProductID(productID);
            productToAdd.setName(productName);
            productToAdd.setPrice(productPrice);
            productToAdd.setinStock(productInStock);
            productToAdd.setMin(productMin);
            productToAdd.setMax(productMax);

            Inventory newProduct = new Inventory();
            newProduct.addProduct(productToAdd);

            foreach (DataGridViewRow item in partsAssociatedDataGrid.Rows)
            {
                
                Part assocPart = new Part();
                assocPart.setPartID(Convert.ToInt32(partsAvaliableDataGrid.CurrentRow.Cells[0].Value));
                assocPart.setName(Convert.ToString(partsAvaliableDataGrid.CurrentRow.Cells[1].Value));
                assocPart.setinStock(Convert.ToInt32(partsAvaliableDataGrid.CurrentRow.Cells[2].Value));
                assocPart.setPrice(Convert.ToDouble(partsAvaliableDataGrid.CurrentRow.Cells[3].Value));

                productToAdd.addAssociatedPart(assocPart);

            }


            this.Close();
            MainScreen main = new MainScreen();
            main.Show();


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Going to have a part selected
            try {
                DataGridViewRow row = (DataGridViewRow)this.partsAvaliableDataGrid.SelectedRows[0].Clone();
            
            

            int numRows = partsAssociatedDataGrid.Rows.Count;
            List<string> list = new List<string>();
            bool isDup = false;
            if (numRows > 0)
            {
                foreach (DataGridViewRow item in partsAssociatedDataGrid.Rows)
                {
                    list.Add(item.Cells[0].Value.ToString());
                }

                for (int i = 0; i < list.Count; i++)
                {
                    string compareID = list[i];
                    if (compareID == this.partsAvaliableDataGrid.CurrentRow.Cells[0].Value.ToString())
                    {
                        isDup = true;
                        break;
                    }
                }
                if (isDup)
                {
                    MessageBox.Show("This part is already assoicated with this product", "Error Adding Part");
                }
                else {
                    //add the row to the associated product row to hold for adding to product on save
                    partsAssociatedDataGrid.Rows.Add(this.partsAvaliableDataGrid.CurrentRow.Cells[0].Value, this.partsAvaliableDataGrid.CurrentRow.Cells[1].Value,
                        this.partsAvaliableDataGrid.CurrentRow.Cells[2].Value, this.partsAvaliableDataGrid.CurrentRow.Cells[3].Value);
                }
                
            }
            else {
                //add the row to the associated product row to hold for adding to product on save
                partsAssociatedDataGrid.Rows.Add(this.partsAvaliableDataGrid.CurrentRow.Cells[0].Value, this.partsAvaliableDataGrid.CurrentRow.Cells[1].Value,
                    this.partsAvaliableDataGrid.CurrentRow.Cells[2].Value, this.partsAvaliableDataGrid.CurrentRow.Cells[3].Value);
            }

            }
            catch
            {
                MessageBox.Show("No part selected");
            }



        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)this.partsAssociatedDataGrid.SelectedRows[0];
            partsAssociatedDataGrid.Rows.Remove(row);

        }
    }
}

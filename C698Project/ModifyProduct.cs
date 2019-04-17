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
    public partial class ModifyProduct : Form
    {
        Products modifyProduct = new Products();
        int productID;
        double totalPriceParts;
        public ModifyProduct(int productID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from productTable WHERE productID = @productID";
            cmd.Parameters.AddWithValue("@productID", productID);

            String ID;
            String name;
            String price;
            String inStock;
            String min;
            String max;

            SqlDataReader rdr = cmd.ExecuteReader();
            // Fill the strings with the values retrieved, convert to types as needed
            while (rdr.Read())
            {

                ID = rdr["productID"].ToString();
                modifyProduct.setProductID(Convert.ToInt32(ID));
                idTextbox.Text = ID;

                name = rdr["name"].ToString();
                modifyProduct.setName(name);
                productNameTextbox.Text = name;

                price = rdr["price"].ToString();
                modifyProduct.setPrice(Convert.ToDouble(price));
                priceTextbox.Text = price;

                inStock = rdr["inStock"].ToString();
                modifyProduct.setinStock(Convert.ToInt32(inStock));
                invTextbox.Text = inStock;

                min = rdr["min"].ToString();
                modifyProduct.setMin(Convert.ToInt32(min));
                minTextbox.Text = min;

                max = rdr["max"].ToString();
                modifyProduct.setMax(Convert.ToInt32(max));
                maxTextbox.Text = max;

            }

            con.Close();
            //Now grab all avaliable parts
            SqlConnection con2 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con2.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price per Unit' from partTable";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd2);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            sqlDataAdap.Update(dtRecord);
            allPartsDataGridView.DataSource = dtRecord;
            con2.Close();

            //Now grab assoicated parts
            SqlConnection con3 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con3.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price per Unit' from associatedParts where productID = @productID";
            cmd3.Parameters.AddWithValue("@productID", modifyProduct.getProductID());
            SqlDataAdapter sqlDataAdap2 = new SqlDataAdapter(cmd3);

            DataTable dtRecord2 = new DataTable();
            sqlDataAdap2.Fill(dtRecord2);
            sqlDataAdap2.Update(dtRecord2);
            assocPartsDataGridView.DataSource = dtRecord2;
            con3.Close();


        }

            private void cancelButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure to cancel modifying this product?",
                                      "Part Deletion",
                                      MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                this.Owner.Show();
                this.Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure to delete this associated part?",
                                    "Part Deletion",
                                    MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                int selectedID = Convert.ToInt32(this.assocPartsDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                modifyProduct.removeAssociatedPart(selectedID);

                //Now grab assoicated parts
                SqlConnection con3 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
                con3.Open();

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con3;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price per Unit' from associatedParts where productID = @productID";
                cmd3.Parameters.AddWithValue("@productID", modifyProduct.getProductID());
                SqlDataAdapter sqlDataAdap2 = new SqlDataAdapter(cmd3);

                DataTable dtRecord2 = new DataTable();
                sqlDataAdap2.Fill(dtRecord2);
                sqlDataAdap2.Update(dtRecord2);
                assocPartsDataGridView.DataSource = dtRecord2;
                con3.Close();
            }
           
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool pass = validation();

            if (pass)
            {
                //Add Prodocut then add associatedPart
                String productName = productNameTextbox.Text;

                Double productPrice = Convert.ToDouble(priceTextbox.Text);

                int productInStock = Convert.ToInt32(invTextbox.Text);

                int productMin = Convert.ToInt32(minTextbox.Text);

                int productMax = Convert.ToInt32(maxTextbox.Text);



                productID = productID + 1;
                Console.WriteLine("product set" + productID);
                modifyProduct.setProductID(productID);
                modifyProduct.setName(productName);
                modifyProduct.setPrice(productPrice);
                modifyProduct.setinStock(productInStock);
                modifyProduct.setMin(productMin);
                modifyProduct.setMax(productMax);

                Inventory newProduct = new Inventory();
                newProduct.updateProduct(productID, modifyProduct);

                //first we want to delete all assoicated parts for this product
                SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
                SqlCommand command = con.CreateCommand();
                con.Open();
                SqlTransaction transaction;
                // Start a local transaction.
                transaction = con.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = con;
                command.Transaction = transaction;
                command.CommandText =
                  "DELETE FROM[dbo].[associatedParts] WHERE productID = @productID";
                command.Parameters.AddWithValue("@productID", productID);
       
                command.ExecuteNonQuery();
                transaction.Commit();
                con.Close();



                foreach (DataGridViewRow row in assocPartsDataGridView.Rows)
                {


                    Part assocPart = new Part();
                    assocPart.setPartID(Convert.ToInt32(row.Cells[0].Value));
                    modifyProduct.removeAssociatedPart(Convert.ToInt32(row.Cells[0].Value));
                    assocPart.setName(Convert.ToString(row.Cells[1].Value));
                    assocPart.setinStock(Convert.ToInt32(row.Cells[2].Value));
                    assocPart.setPrice(Convert.ToDouble(row.Cells[3].Value));
                    //First remove all assoc parts from associatedParts table
                    modifyProduct.addAssociatedPart(assocPart);

                }


                this.Close();
                MainScreen main = new MainScreen();
                main.Show();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)this.allPartsDataGridView.SelectedRows[0].Clone();



            int numRows = assocPartsDataGridView.Rows.Count;
            List<string> list = new List<string>();
            bool isDup = false;
            if (numRows > 0)
            {
                foreach (DataGridViewRow item in assocPartsDataGridView.Rows)
                {
                    list.Add(item.Cells[0].Value.ToString());
                }

                for (int i = 0; i < list.Count; i++)
                {
                    string compareID = list[i];
                    if (compareID == this.allPartsDataGridView.CurrentRow.Cells[0].Value.ToString())
                    {
                        isDup = true;
                        break;
                    }
                }
                if (isDup)
                {
                    MessageBox.Show("This part is already assoicated with this product", "Error Adding Part");
                }
                else
                {
                    //add the row to the associated product row to hold for adding to product on save
                    // assocPartsDataGridView.Rows.Add(this.allPartsDataGridView.CurrentRow.Cells[0].Value, this.allPartsDataGridView.CurrentRow.Cells[1].Value,
                    // this.allPartsDataGridView.CurrentRow.Cells[2].Value, this.allPartsDataGridView.CurrentRow.Cells[3].Value);

                    DataTable dataTable = (DataTable)assocPartsDataGridView.DataSource;
                    DataRow drToAdd = dataTable.NewRow();

                    drToAdd["Part ID"] = this.allPartsDataGridView.CurrentRow.Cells[0].Value;
                    drToAdd["Part Name"] = this.allPartsDataGridView.CurrentRow.Cells[1].Value;
                    drToAdd["Inventory Level"] = this.allPartsDataGridView.CurrentRow.Cells[2].Value;
                    drToAdd["Price per Unit"] = this.allPartsDataGridView.CurrentRow.Cells[3].Value;

                    dataTable.Rows.Add(drToAdd);
                    dataTable.AcceptChanges();
                }

            }
            else
            {
                //add the row to the associated product row to hold for adding to product on save

                DataTable dataTable = (DataTable)assocPartsDataGridView.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                drToAdd["Part ID"] = this.allPartsDataGridView.CurrentRow.Cells[0].Value;
                drToAdd["Part Name"] = this.allPartsDataGridView.CurrentRow.Cells[1].Value;
                drToAdd["Inventory Level"] = this.allPartsDataGridView.CurrentRow.Cells[2].Value;
                drToAdd["Price per Unit"] = this.allPartsDataGridView.CurrentRow.Cells[3].Value;

                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
            }
        }

        public bool validation()
        {
            totalPriceParts = 0;
            Console.WriteLine("checking correct field types");
            if (System.Text.RegularExpressions.Regex.IsMatch(minTextbox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers for " + minLabel.Text);
                minTextbox.Text = minTextbox.Text.Remove(minTextbox.Text.Length - 1);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(maxTextbox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers for " + maxLabel.Text);
                maxTextbox.Text = maxTextbox.Text.Remove(maxTextbox.Text.Length - 1);
                return false;
            }

            if (Convert.ToInt32(minTextbox.Text) > Convert.ToInt32(maxTextbox.Text))
            {
                MessageBox.Show("The minimum value can not be less than the maximum value");
                return false;

            }

            if (System.Text.RegularExpressions.Regex.IsMatch(invTextbox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers for " + invLabel.Text);
                invTextbox.Text = invTextbox.Text.Remove(invTextbox.Text.Length - 1);
                return false;
            }
            
            //total of all parts
            foreach (DataGridViewRow row in assocPartsDataGridView.Rows)
            {
                
                double price = Convert.ToDouble(row.Cells[3].Value);
                totalPriceParts =  totalPriceParts  + price;

            }

            if (totalPriceParts > Convert.ToDouble(priceTextbox.Text))
            {
                MessageBox.Show("The price of a product cannot be less than the cost of the parts");
                return false;
            }

            return true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String search = searchTextbox.Text;

            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit' from partTable";
            if (search == null || search == "")
            {
                cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost Unit'  FROM dbo.partTable";
            }
            else
            {
                cmd.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost Unit'  FROM dbo.partTable WHERE partID LIKE @Search OR name LIKE  @Search OR price LIKE @Search  OR inStock LIKE @Search  ";
            }

            cmd.Parameters.AddWithValue("@Search", search);

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);


            DataTable dtRecord = new DataTable();
            sqlDataAdap.Update(dtRecord);
            sqlDataAdap.Fill(dtRecord);

            allPartsDataGridView.DataSource = dtRecord;
        }
    }
}

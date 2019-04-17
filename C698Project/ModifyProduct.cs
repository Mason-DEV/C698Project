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
            cmd2.CommandText = "Select partID AS 'Part ID', name AS 'Part Name', inStock AS 'Inventory Level',  price AS 'Price Cost per Unit' from partTable";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd2);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            sqlDataAdap.Update(dtRecord);
            allPartsDataGridView.DataSource = dtRecord;
            con2.Close();

            //Now grab assoicated parts


        }

            private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}

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
    public partial class ModifyPart : Form
    {
        Part modifyPart = new Part();


        public ModifyPart(int partID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            variableChange();

            modifyPart.setPartID(partID);


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mason\Documents\GitHub\C698Project\C698Project\DB.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select partID, name, inStock, price, min, max from partTable WHERE partID = @partID";
            cmd.Parameters.AddWithValue("@partID", partID);

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

                ID = rdr["partID"].ToString();
                modifyPart.setPartID(Convert.ToInt32(ID));
                idTextbox.Text = ID;

                name = rdr["name"].ToString();
                modifyPart.setName(name);
                partNameTextbox.Text = name;

                price = rdr["price"].ToString();
                modifyPart.setPrice(Convert.ToDouble(price));
                priceCostTextbox.Text = price;

                inStock = rdr["inStock"].ToString();
                modifyPart.setinStock(Convert.ToInt32(inStock));
                invTextbox.Text = inStock;
               
                min = rdr["min"].ToString();
                modifyPart.setMin(Convert.ToInt32(min));
                minTextbox.Text = min;
            
                max = rdr["max"].ToString();
                modifyPart.setMax(Convert.ToInt32(max));
                maxTextbox.Text = max;


            }
            con.Close();




        }

        private void outsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            variableChange();
        }

        private void inHouseRadio_CheckedChanged(object sender, EventArgs e)
        {

            variableChange();
        }

        private void variableChange() {
            if (outsourcedRadio.Checked == true)
            {
                variableLabel.Text = "Company Name";
                variableTextbox.Text = "Comp Nm";
            }
            else
            {
                variableLabel.Text = "Machine ID";
                variableTextbox.Text = "Mach ID";

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int id = modifyPart.getParttID();
            Console.WriteLine("Modify part id " +id);
        }
    }
}

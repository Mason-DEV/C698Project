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
        Inhouse modifyInHouse = new Inhouse();
        String inHouseValue;
        String outSourceValue;
        String machineID;
        String companyName;

        public ModifyPart(int partID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            variableChange();

            modifyPart.setPartID(partID);


            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from partTable WHERE partID = @partID";
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

                inHouseValue = rdr["inHouse"].ToString();
                modifyInHouse.setInhouse(Convert.ToInt32(inHouseValue));
                inHouseRadio.Checked = Convert.ToBoolean(Convert.ToInt32(inHouseValue));

                outSourceValue = rdr["outSourced"].ToString();
                modifyInHouse.setInhouse(Convert.ToInt32(outSourceValue));
                outsourcedRadio.Checked = Convert.ToBoolean(Convert.ToInt32(outSourceValue));

                if (inHouseRadio.Checked == true)
                {
                    machineID = rdr["machineID"].ToString();
                    modifyInHouse.setMachineID(Convert.ToInt32(machineID));
                    variableTextbox.Text = machineID;

                }
                else {
                    
                }

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
               // variableTextbox.Text = "Comp Nm";
            }
            else
            {
                variableLabel.Text = "Machine ID";
                //variableTextbox.Text = "Mach ID";

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Grab ID for the part we are changing
            int id = modifyPart.getParttID();
            //Grab fields on form and set those to Modify Part
            String partName = partNameTextbox.Text;

            Double partPrice = Convert.ToDouble(priceCostTextbox.Text);

            int partInStock = Convert.ToInt32(invTextbox.Text);

            int partMin = Convert.ToInt32(minTextbox.Text);

            int partMax = Convert.ToInt32(maxTextbox.Text);

            modifyPart.setMax(partMax);
            modifyPart.setMin(partMin);
            modifyPart.setinStock(partInStock);
            modifyPart.setName(partName);
            modifyPart.setPrice(partPrice);
            
            
            //Call updatePart passing in ID and modifyPart
            Inventory modify = new Inventory();
            modifyInHouse.setInhouse(Convert.ToInt32(inHouseValue));
            modifyInHouse.setMachineID(Convert.ToInt32(machineID));
            modifyInHouse.setInhouse(Convert.ToInt32(outSourceValue));
            modify.updatePart(id, modifyPart);
            
            this.Close();
            MainScreen main = new MainScreen();
            main.Show();

        }
    }
}

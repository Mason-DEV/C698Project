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
        Outsourced modifyOutSource = new Outsourced();
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
                //modifyInHouse.setInhouse(Convert.ToInt32(inHouseValue));
                inHouseRadio.Checked = Convert.ToBoolean(Convert.ToInt32(inHouseValue));

                outSourceValue = rdr["outSourced"].ToString();
               // modifyInHouse.setInhouse(Convert.ToInt32(outSourceValue));
                outsourcedRadio.Checked = Convert.ToBoolean(Convert.ToInt32(outSourceValue));

                if (inHouseRadio.Checked == true)
                {
                    machineID = rdr["machineID"].ToString();
                    modifyInHouse.setMachineID(Convert.ToInt32(machineID));
                    variableTextbox.Text = machineID;
                    

                }
                else {
                    companyName = rdr["companyName"].ToString();
                    //modifyInHouse.setMachineID(Convert.ToInt32(machineID));
                    variableTextbox.Text = companyName;
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
            var confirm = MessageBox.Show("Are you sure to cancel modifying this part?",
                                      "Part Deletion",
                                      MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                this.Owner.Show();
                this.Close();
            }
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            bool pass = validation();
            if (pass)
            {
                //Grab ID for the part we are changing
                int id = modifyPart.getParttID();
                //Grab fields on form and set those to Modify Part
                String partName = partNameTextbox.Text;

                Double partPrice = Convert.ToDouble(priceCostTextbox.Text);

                int partInStock = Convert.ToInt32(invTextbox.Text);

                int partMin = Convert.ToInt32(minTextbox.Text);

                int partMax = Convert.ToInt32(maxTextbox.Text);

                bool inHouse = inHouseRadio.Checked;

                bool outsourced = outsourcedRadio.Checked;

                if (inHouse)
                {
                    Console.WriteLine("Updateding inHouse");

                    modifyOutSource.setInhouse(1);
                    modifyOutSource.setoutsourced(0);

                    modifyInHouse.setInhouse(1);
                    modifyInHouse.setoutsourced(0);
                    modifyInHouse.setMachineID(Convert.ToInt32(variableTextbox.Text));

                }
                else
                {
                    Console.WriteLine("Updateding outSourced");

                    modifyInHouse.setInhouse(0);
                    modifyInHouse.setoutsourced(1);

                    modifyOutSource.setInhouse(0);
                    modifyOutSource.setoutsourced(1);
                    modifyOutSource.setCompanyName(Convert.ToString(variableTextbox.Text));
                }

                modifyPart.setMax(partMax);
                modifyPart.setMin(partMin);
                modifyPart.setinStock(partInStock);
                modifyPart.setName(partName);
                modifyPart.setPrice(partPrice);


                //Call updatePart passing in ID and modifyPart
                Inventory modify = new Inventory();
                //adds inhouse or outsourced info
                if (inHouse)
                {
                    modify.houseInfo(modifyInHouse);
                }
                else
                {
                    modify.outSourceInfo(modifyOutSource);
                }

                modify.updatePart(id, modifyPart);

                this.Close();
                MainScreen main = new MainScreen();
                main.Show();
            }

        }
        public bool validation()
        {
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

            return true;
        }
    }
}

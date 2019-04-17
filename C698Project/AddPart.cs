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
    public partial class AddPart : Form
    {

        int inHouseValue;
        int outSourcedValue;
        String companyName;
        int machineID;
        public AddPart()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            variableChange();
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
            var confirm = MessageBox.Show("Are you sure to cancel adding this part?",
                                      "Part Deletion",
                                      MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                this.Owner.Show();
                this.Close();
            };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool pass = validation();

            if (pass)
            {

                String partName = partNameTextbox.Text;

                Double partPrice = Convert.ToDouble(priceCostTextbox.Text);

                int partInStock = Convert.ToInt32(invTextbox.Text);

                int partMin = Convert.ToInt32(minTextbox.Text);

                int partMax = Convert.ToInt32(maxTextbox.Text);

                bool inHouse = inHouseRadio.Checked;

                bool outsourced = outsourcedRadio.Checked;
                //Need to set inHouse&outsource to 0 or 1 depending if T or F


                if (inHouse)
                {
                    inHouseValue = 1;
                    outSourcedValue = 0;
                    machineID = Convert.ToInt32(variableTextbox.Text);
                }
                else
                {
                    inHouseValue = 0;
                    outSourcedValue = 1;
                    companyName = variableTextbox.Text;
                }



                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT MAX(partID) FROM partTable;";
                con.Open();
                int partID;
                try
                {
                    partID = (Int32)cmd.ExecuteScalar();
                }
                catch
                {
                    partID = 0;
                }

                Console.WriteLine("sql  " + partID);
                partID = partID + 1;
                con.Close();
                Console.WriteLine("Setting partID to " + partID);
                Part newPart = new Part();
                newPart.setName(partName);
                newPart.setPrice(partPrice);
                newPart.setinStock(partInStock);
                newPart.setMin(partMin);
                newPart.setMax(partMax);
                newPart.setPartID(partID);
                if (inHouse)
                {
                    newPart.getPartINFO(inHouseValue, outSourcedValue, companyName, machineID);
                    //Inhouse mach = new Inhouse();
                    //mach.setMachineID(machineID);
                    //mach.setInhouse(inHouseValue);
                    //mach.setoutsourced(outSourcedValue);

                }
                else
                {

                    newPart.getPartINFO(inHouseValue, outSourcedValue, companyName, machineID);
                }


                newPart.addThePart();

                this.Close();
                MainScreen main = new MainScreen();
                main.Show();

            }
        }

        public bool validation() {
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

            if (Convert.ToInt32(minTextbox.Text) > Convert.ToInt32(maxTextbox.Text)) {
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

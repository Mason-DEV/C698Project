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
            this.Owner.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String partName = partNameTextbox.Text;

            Double partPrice = Convert.ToDouble(priceCostTextbox.Text);

            int partInStock = Convert.ToInt32(invTextbox.Text);

            int partMin = Convert.ToInt32(minTextbox.Text);

            int partMax = Convert.ToInt32(maxTextbox.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) partID FROM partTable;";
            con.Open();
            int partID = (Int32)cmd.ExecuteScalar() + 1;
            con.Close();
            Console.WriteLine("Setting partID to " + partID);
            Part newPart = new Part();
            newPart.setName(partName);
            newPart.setPrice(partPrice);
            newPart.setinStock(partInStock);
            newPart.setMin(partMin);
            newPart.setMax(partMax);                  
            newPart.setPartID(partID);
            newPart.addThePart();

            this.Close();
            MainScreen main = new MainScreen();
            main.Show();


        }
    }
}

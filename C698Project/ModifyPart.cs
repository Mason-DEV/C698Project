using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C698Project
{
    public partial class ModifyPart : Form
    {
        public ModifyPart()
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
    }
}

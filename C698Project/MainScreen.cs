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
            //For modify add code that makes it so the user has to select an item from the dropdown
            //After item selected, allow them to modify
            //Pull in data from selected item
            Form modifyPart = new ModifyPart();
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
    }
}

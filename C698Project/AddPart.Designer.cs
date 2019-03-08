namespace C698Project
{
    partial class AddPart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPart));
            this.addPartLabel = new System.Windows.Forms.Label();
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.invLabel = new System.Windows.Forms.Label();
            this.priceCostLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.minTextbox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.variableLabel = new System.Windows.Forms.Label();
            this.inHouseRadio = new System.Windows.Forms.RadioButton();
            this.outsourcedRadio = new System.Windows.Forms.RadioButton();
            this.partNameTextbox = new System.Windows.Forms.TextBox();
            this.priceCostTextbox = new System.Windows.Forms.TextBox();
            this.invTextbox = new System.Windows.Forms.TextBox();
            this.variableTextbox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPartLabel
            // 
            this.addPartLabel.AutoSize = true;
            this.addPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPartLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.addPartLabel.Location = new System.Drawing.Point(46, 23);
            this.addPartLabel.Name = "addPartLabel";
            this.addPartLabel.Size = new System.Drawing.Size(79, 20);
            this.addPartLabel.TabIndex = 0;
            this.addPartLabel.Text = "Add Part";
            // 
            // idTextbox
            // 
            this.idTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.idTextbox.Enabled = false;
            this.idTextbox.Location = new System.Drawing.Point(188, 70);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(130, 20);
            this.idTextbox.TabIndex = 3;
            this.idTextbox.Text = "Auto Gen - Disabled";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(90, 73);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 4;
            this.idLabel.Text = "ID";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(90, 112);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name";
            // 
            // invLabel
            // 
            this.invLabel.AutoSize = true;
            this.invLabel.Location = new System.Drawing.Point(90, 150);
            this.invLabel.Name = "invLabel";
            this.invLabel.Size = new System.Drawing.Size(25, 13);
            this.invLabel.TabIndex = 6;
            this.invLabel.Text = "INV";
            // 
            // priceCostLabel
            // 
            this.priceCostLabel.AutoSize = true;
            this.priceCostLabel.Location = new System.Drawing.Point(90, 182);
            this.priceCostLabel.Name = "priceCostLabel";
            this.priceCostLabel.Size = new System.Drawing.Size(57, 13);
            this.priceCostLabel.TabIndex = 7;
            this.priceCostLabel.Text = "Price/Cost";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(90, 218);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(27, 13);
            this.maxLabel.TabIndex = 8;
            this.maxLabel.Text = "Max";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(291, 218);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(24, 13);
            this.minLabel.TabIndex = 9;
            this.minLabel.Text = "Min";
            // 
            // minTextbox
            // 
            this.minTextbox.Location = new System.Drawing.Point(324, 215);
            this.minTextbox.Name = "minTextbox";
            this.minTextbox.Size = new System.Drawing.Size(63, 20);
            this.minTextbox.TabIndex = 10;
            this.minTextbox.Text = "Min";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 215);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(97, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Min";
            // 
            // variableLabel
            // 
            this.variableLabel.AutoSize = true;
            this.variableLabel.Location = new System.Drawing.Point(90, 254);
            this.variableLabel.Name = "variableLabel";
            this.variableLabel.Size = new System.Drawing.Size(82, 13);
            this.variableLabel.TabIndex = 12;
            this.variableLabel.Text = "Company Name";
            // 
            // inHouseRadio
            // 
            this.inHouseRadio.AutoSize = true;
            this.inHouseRadio.Checked = true;
            this.inHouseRadio.Location = new System.Drawing.Point(188, 26);
            this.inHouseRadio.Name = "inHouseRadio";
            this.inHouseRadio.Size = new System.Drawing.Size(68, 17);
            this.inHouseRadio.TabIndex = 13;
            this.inHouseRadio.TabStop = true;
            this.inHouseRadio.Text = "In-House";
            this.inHouseRadio.UseVisualStyleBackColor = true;
            this.inHouseRadio.CheckedChanged += new System.EventHandler(this.inHouseRadio_CheckedChanged);
            // 
            // outsourcedRadio
            // 
            this.outsourcedRadio.AutoSize = true;
            this.outsourcedRadio.Location = new System.Drawing.Point(277, 26);
            this.outsourcedRadio.Name = "outsourcedRadio";
            this.outsourcedRadio.Size = new System.Drawing.Size(80, 17);
            this.outsourcedRadio.TabIndex = 14;
            this.outsourcedRadio.Text = "Outsourced";
            this.outsourcedRadio.UseVisualStyleBackColor = true;
            this.outsourcedRadio.CheckedChanged += new System.EventHandler(this.outsourcedRadio_CheckedChanged);
            // 
            // partNameTextbox
            // 
            this.partNameTextbox.Location = new System.Drawing.Point(188, 112);
            this.partNameTextbox.Name = "partNameTextbox";
            this.partNameTextbox.Size = new System.Drawing.Size(130, 20);
            this.partNameTextbox.TabIndex = 15;
            this.partNameTextbox.Text = "Part Name";
            // 
            // priceCostTextbox
            // 
            this.priceCostTextbox.Location = new System.Drawing.Point(188, 179);
            this.priceCostTextbox.Name = "priceCostTextbox";
            this.priceCostTextbox.Size = new System.Drawing.Size(130, 20);
            this.priceCostTextbox.TabIndex = 16;
            this.priceCostTextbox.Text = "Price/Cost";
            // 
            // invTextbox
            // 
            this.invTextbox.Location = new System.Drawing.Point(188, 147);
            this.invTextbox.Name = "invTextbox";
            this.invTextbox.Size = new System.Drawing.Size(130, 20);
            this.invTextbox.TabIndex = 17;
            this.invTextbox.Text = "INV";
            // 
            // variableTextbox
            // 
            this.variableTextbox.Location = new System.Drawing.Point(188, 251);
            this.variableTextbox.Name = "variableTextbox";
            this.variableTextbox.Size = new System.Drawing.Size(110, 20);
            this.variableTextbox.TabIndex = 18;
            this.variableTextbox.Text = "Company Nm";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(247, 288);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(67, 29);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(320, 288);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(67, 29);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 353);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.variableTextbox);
            this.Controls.Add(this.invTextbox);
            this.Controls.Add(this.priceCostTextbox);
            this.Controls.Add(this.partNameTextbox);
            this.Controls.Add(this.outsourcedRadio);
            this.Controls.Add(this.inHouseRadio);
            this.Controls.Add(this.variableLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.minTextbox);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.priceCostLabel);
            this.Controls.Add(this.invLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.addPartLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPart";
            this.Text = "AddPart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addPartLabel;
        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label invLabel;
        private System.Windows.Forms.Label priceCostLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.TextBox minTextbox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label variableLabel;
        private System.Windows.Forms.RadioButton inHouseRadio;
        private System.Windows.Forms.RadioButton outsourcedRadio;
        private System.Windows.Forms.TextBox partNameTextbox;
        private System.Windows.Forms.TextBox priceCostTextbox;
        private System.Windows.Forms.TextBox invTextbox;
        private System.Windows.Forms.TextBox variableTextbox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
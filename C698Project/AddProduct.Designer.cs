namespace C698Project
{
    partial class AddProduct
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.addProductLabel = new System.Windows.Forms.Label();
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.invLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.minTextbox = new System.Windows.Forms.TextBox();
            this.maxTextbox = new System.Windows.Forms.TextBox();
            this.productNameTextbox = new System.Windows.Forms.TextBox();
            this.priceTextbox = new System.Windows.Forms.TextBox();
            this.invTextbox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.partsAssociatedDataGrid = new System.Windows.Forms.DataGridView();
            this.PartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partsAvaliableDataGrid = new System.Windows.Forms.DataGridView();
            this.dBDataSet = new C698Project.DBDataSet();
            this.partTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partTableTableAdapter = new C698Project.DBDataSetTableAdapters.partTableTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsAssociatedDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsAvaliableDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addProductLabel
            // 
            this.addProductLabel.AutoSize = true;
            this.addProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.addProductLabel.Location = new System.Drawing.Point(61, 40);
            this.addProductLabel.Name = "addProductLabel";
            this.addProductLabel.Size = new System.Drawing.Size(108, 20);
            this.addProductLabel.TabIndex = 0;
            this.addProductLabel.Text = "Add Product";
            // 
            // idTextbox
            // 
            this.idTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.idTextbox.Enabled = false;
            this.idTextbox.Location = new System.Drawing.Point(172, 103);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(130, 20);
            this.idTextbox.TabIndex = 3;
            this.idTextbox.Text = "Auto Gen - Disabled";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(74, 106);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 4;
            this.idLabel.Text = "ID";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(74, 145);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name";
            // 
            // invLabel
            // 
            this.invLabel.AutoSize = true;
            this.invLabel.Location = new System.Drawing.Point(74, 183);
            this.invLabel.Name = "invLabel";
            this.invLabel.Size = new System.Drawing.Size(25, 13);
            this.invLabel.TabIndex = 6;
            this.invLabel.Text = "INV";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(74, 215);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 7;
            this.priceLabel.Text = "Price";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(74, 251);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(27, 13);
            this.maxLabel.TabIndex = 8;
            this.maxLabel.Text = "Max";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(275, 251);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(24, 13);
            this.minLabel.TabIndex = 9;
            this.minLabel.Text = "Min";
            // 
            // minTextbox
            // 
            this.minTextbox.Location = new System.Drawing.Point(308, 248);
            this.minTextbox.Name = "minTextbox";
            this.minTextbox.Size = new System.Drawing.Size(63, 20);
            this.minTextbox.TabIndex = 5;
            this.minTextbox.Text = "Min";
            // 
            // maxTextbox
            // 
            this.maxTextbox.Location = new System.Drawing.Point(172, 248);
            this.maxTextbox.Name = "maxTextbox";
            this.maxTextbox.Size = new System.Drawing.Size(97, 20);
            this.maxTextbox.TabIndex = 4;
            this.maxTextbox.Text = "Max";
            // 
            // productNameTextbox
            // 
            this.productNameTextbox.Location = new System.Drawing.Point(172, 145);
            this.productNameTextbox.Name = "productNameTextbox";
            this.productNameTextbox.Size = new System.Drawing.Size(130, 20);
            this.productNameTextbox.TabIndex = 1;
            this.productNameTextbox.Text = "Product Name";
            // 
            // priceTextbox
            // 
            this.priceTextbox.Location = new System.Drawing.Point(172, 212);
            this.priceTextbox.Name = "priceTextbox";
            this.priceTextbox.Size = new System.Drawing.Size(130, 20);
            this.priceTextbox.TabIndex = 3;
            this.priceTextbox.Text = "Price";
            // 
            // invTextbox
            // 
            this.invTextbox.Location = new System.Drawing.Point(172, 180);
            this.invTextbox.Name = "invTextbox";
            this.invTextbox.Size = new System.Drawing.Size(130, 20);
            this.invTextbox.TabIndex = 2;
            this.invTextbox.Text = "INV";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(729, 380);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(810, 380);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(536, 37);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 21;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(618, 39);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(167, 20);
            this.searchTextbox.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.partsAssociatedDataGrid);
            this.panel1.Controls.Add(this.partsAvaliableDataGrid);
            this.panel1.Controls.Add(this.searchTextbox);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.invTextbox);
            this.panel1.Controls.Add(this.priceTextbox);
            this.panel1.Controls.Add(this.productNameTextbox);
            this.panel1.Controls.Add(this.maxTextbox);
            this.panel1.Controls.Add(this.minTextbox);
            this.panel1.Controls.Add(this.minLabel);
            this.panel1.Controls.Add(this.maxLabel);
            this.panel1.Controls.Add(this.priceLabel);
            this.panel1.Controls.Add(this.invLabel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.idTextbox);
            this.panel1.Controls.Add(this.addProductLabel);
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 431);
            this.panel1.TabIndex = 23;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(810, 351);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(810, 196);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 25;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // partsAssociatedDataGrid
            // 
            this.partsAssociatedDataGrid.AllowUserToAddRows = false;
            this.partsAssociatedDataGrid.AllowUserToDeleteRows = false;
            this.partsAssociatedDataGrid.AllowUserToResizeColumns = false;
            this.partsAssociatedDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsAssociatedDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.partsAssociatedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.partsAssociatedDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartID,
            this.PartName,
            this.InventoryLevel,
            this.PricePerUnit});
            this.partsAssociatedDataGrid.Location = new System.Drawing.Point(455, 235);
            this.partsAssociatedDataGrid.Name = "partsAssociatedDataGrid";
            this.partsAssociatedDataGrid.RowHeadersVisible = false;
            this.partsAssociatedDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsAssociatedDataGrid.Size = new System.Drawing.Size(430, 110);
            this.partsAssociatedDataGrid.TabIndex = 24;
            // 
            // PartID
            // 
            this.PartID.HeaderText = "Part ID";
            this.PartID.Name = "PartID";
            // 
            // PartName
            // 
            this.PartName.HeaderText = "Part Name";
            this.PartName.Name = "PartName";
            // 
            // InventoryLevel
            // 
            this.InventoryLevel.HeaderText = "Inventory Level";
            this.InventoryLevel.Name = "InventoryLevel";
            // 
            // PricePerUnit
            // 
            this.PricePerUnit.HeaderText = "Price per Unit";
            this.PricePerUnit.Name = "PricePerUnit";
            // 
            // partsAvaliableDataGrid
            // 
            this.partsAvaliableDataGrid.AllowUserToAddRows = false;
            this.partsAvaliableDataGrid.AllowUserToDeleteRows = false;
            this.partsAvaliableDataGrid.AllowUserToResizeColumns = false;
            this.partsAvaliableDataGrid.AllowUserToResizeRows = false;
            this.partsAvaliableDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsAvaliableDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.partsAvaliableDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.partsAvaliableDataGrid.Location = new System.Drawing.Point(456, 75);
            this.partsAvaliableDataGrid.Name = "partsAvaliableDataGrid";
            this.partsAvaliableDataGrid.ReadOnly = true;
            this.partsAvaliableDataGrid.RowHeadersVisible = false;
            this.partsAvaliableDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsAvaliableDataGrid.ShowCellErrors = false;
            this.partsAvaliableDataGrid.ShowCellToolTips = false;
            this.partsAvaliableDataGrid.ShowEditingIcon = false;
            this.partsAvaliableDataGrid.ShowRowErrors = false;
            this.partsAvaliableDataGrid.Size = new System.Drawing.Size(430, 107);
            this.partsAvaliableDataGrid.TabIndex = 23;
            // 
            // dBDataSet
            // 
            this.dBDataSet.DataSetName = "DBDataSet";
            this.dBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // partTableBindingSource
            // 
            this.partTableBindingSource.DataMember = "partTable";
            this.partTableBindingSource.DataSource = this.dBDataSet;
            // 
            // partTableTableAdapter
            // 
            this.partTableTableAdapter.ClearBeforeFill = true;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 457);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsAssociatedDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsAvaliableDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label addProductLabel;
        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label invLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.TextBox minTextbox;
        private System.Windows.Forms.TextBox maxTextbox;
        private System.Windows.Forms.TextBox productNameTextbox;
        private System.Windows.Forms.TextBox priceTextbox;
        private System.Windows.Forms.TextBox invTextbox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView partsAvaliableDataGrid;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView partsAssociatedDataGrid;
        private DBDataSet dBDataSet;
        private System.Windows.Forms.BindingSource partTableBindingSource;
        private DBDataSetTableAdapters.partTableTableAdapter partTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePerUnit;
    }
}